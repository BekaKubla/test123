using HtmlAgilityPack;
using MimeKit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Repositories.ScrapperRepos
{
    public class ScrapperRepository : IScrapperRepository
    {
        private readonly ScrapperDbContext _dbContext;
        public ScrapperRepository(ScrapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ScrapperModel> GetAll()
        {
            var resut = _dbContext.Scrapper;

            return resut;
        }
        public void ScrapperJob()
        {
            var links = _dbContext.ScrapperLink.ToList();

            var myHomeHtmls = GetHtmlDocumentWithThreads(Site.MyHome, links);
            AddMyHomeHouse(myHomeHtmls, (int)Site.MyHome);

            var ssHtmls = GetHtmlDocumentWithThreads(Site.SS, links);
            AddSSHouse(ssHtmls, (int)Site.SS);

            #region Place.Ge JOB
            //var placeGeUrl = "https://place.ge/ge/ads?object_type=flat&mode=list&nearest=0&type=for_sale&condition=&project=&agency_id=&city_id=1&region_id=4&district_id=44&street_id=&commercial_type=&commercial_type2=&status=&rooms_from=-%E1%83%93%E1%83%90%E1%83%9C&rooms_to=-%E1%83%9B%E1%83%93%E1%83%94&living_space_from=40&living_space_to=-%E1%83%9B%E1%83%93%E1%83%94&price_from=-%E1%83%93%E1%83%90%E1%83%9C&price_to=125000&currency_id=1&with_photos=0&owner=0";
            //var loadplaceGehtmlDocument = await GetHtmlDocument(placeGeUrl);

            //var placeGeProductsHtml = loadplaceGehtmlDocument.DocumentNode.Descendants("div")
            //    .Where(node => node.GetAttributeValue("class", "")
            //    .Equals("infoFilter")).ToList();

            //AddPlaceHouse(placeGeProductsHtml);

            #endregion
        }


        #region MethodForJob


        public ConcurrentStack<HtmlDocument> GetHtmlDocumentWithThreads(Site site, List<ScrapperLinkModel> links)
        {
            var htmlList = new ConcurrentStack<HtmlDocument>();

            Parallel.ForEach(links.Where(x => x.SiteType == site && x.IsDeleted == false), new ParallelOptions { MaxDegreeOfParallelism = 20 },
                  link =>
                  {
                      for (var i = 1; i <= link.PageCount; i++)
                      {
                          var url = $"{link.ScrapperUrl}";
                          if (!url.Contains("Page=1") && i > 1)
                          {
                              url = url.Replace("Page=1", $"Page={i}");
                          }

                          HtmlWeb web = new HtmlWeb();
                          HtmlDocument htmlDocument = new HtmlDocument();

                          if (site == Site.SS)
                          {
                              htmlDocument = web.Load(url);
                          }

                          else if (site == Site.MyHome)
                          {
                              var loadHtml = web.Load(url);
                              htmlDocument = DecodeUnicode(loadHtml);
                          }

                          htmlList.Push(htmlDocument);

                      }
                  });

            return htmlList;
        }
        public void AddMyHomeHouse(ConcurrentStack<HtmlDocument> htmlDocument, int statementType)
        {
            var webSiteUrl = "https://www.myhome.ge/ka/pr/";
            List<ScrapperModel> house = new List<ScrapperModel>();
            Parallel.ForEach(htmlDocument, new ParallelOptions { MaxDegreeOfParallelism = 20 },
                  html =>
                  {
                      var customStatement = html.DocumentNode.InnerHtml.Split("[{")[1].Split(",{");

                      Parallel.ForEach(customStatement, new ParallelOptions { MaxDegreeOfParallelism = 20 },
                               statement =>
                               {
                                   var properties = statement.Split(",");

                                   var createDate = properties.Where(x => x.Contains("order_date")).FirstOrDefault().Replace("order_date", "").Replace(":", "").Replace("/", "").Replace("\"", "").Substring(0, 10);
                                   var address = properties.Where(x => x.Contains("name_json")).FirstOrDefault().Replace("name_json", "").Replace(":", "").Replace("/", "").Replace("\"", "").Replace("{", "").Replace(@"\", "").Replace("ka", "");
                                   var price = properties.Where(x => x.Contains("price")).FirstOrDefault().Replace("price", "").Replace(":", "").Replace("/", "").Replace("\"", "");
                                   var houseId = properties.Where(x => x.Contains("product_id")).FirstOrDefault().Replace("product_id", "").Replace(":", "").Replace("/", "").Replace("\"", "");
                                   var areaSize = properties.Where(x => x.Contains("area_size_value")).FirstOrDefault().Replace("area_size_value", "").Replace(":", "").Replace("/", "").Replace("\"", "");

                                   house.Add(new ScrapperModel()
                                   {
                                       CreateDate = createDate,
                                       HouseId = houseId,
                                       Address = address,
                                       PriceInUsd = price,
                                       SquareMeter = areaSize,
                                       PriceOneSquareMeter = (double.Parse(price) / double.Parse(areaSize)).ToString(),
                                       WebSiteName = "MYHOME.GE",
                                       JobCreate = DateTime.Now,
                                       StatementType = statementType
                                   });

                               });
                  });

            var toDayHouse = house.Where(x => x.CreateDate == DateTime.Now.ToString("yyyy-MM-dd")).ToList();
            var checkStatementIfAlreadyExist = CheckStatementIfAlreadyExist(toDayHouse, "MYHOME.GE");

            if (checkStatementIfAlreadyExist.Any())
            {
                _dbContext.Scrapper.AddRange(toDayHouse);
                _dbContext.SaveChanges();

                var subjectInBody = CreateEmailSubject(toDayHouse, webSiteUrl);

                SendEmailData($"MYHOME.GE (ბინები რაოდენობა {toDayHouse.Count()})", subjectInBody);
            }
        }

        public void AddPlaceHouse(List<HtmlNode> prodsctHtml)
        {

            var webSiteUrl = "https://place.ge/ge/ads/view/";
            List<ScrapperModel> house = new List<ScrapperModel>();


            foreach (var item in prodsctHtml)
            {
                var priceHtml = item.Descendants("span")
                                       .Where(node => node.GetAttributeValue("class", "")
                                       .Equals("price")).ToList();

                var address = item.InnerText.ToString().Trim();

                var urlHtml = item.Descendants("div")
                                       .Where(node => node.GetAttributeValue("class", "")
                                       .Equals("item-bt")).ToList();

                var houseId = urlHtml[0].InnerHtml.Substring(59, 7);

                house.Add(new ScrapperModel()
                {
                    WebSiteName = "PLACE.GE",
                    HouseId = houseId,
                    Address = address,
                    CreateDate = DateTime.Now.ToString("dd.MM.yyyy"),
                    PriceInUsd = priceHtml[0].InnerText.ToString() + "ლარი"
                });

            }

            var checkStatementIfAlreadyExist = CheckStatementIfAlreadyExist(house, "PLACE.GE");

            if (checkStatementIfAlreadyExist.Any())
            {

                _dbContext.Scrapper.AddRange(house);

                _dbContext.SaveChanges();

                var subjectInBody = CreateEmailSubject(house, webSiteUrl);

                SendEmailData($"PLACE.GE (ბინები რაოდენობა {house.Count()})", subjectInBody);
            }
        }

        public void AddSSHouse(ConcurrentStack<HtmlDocument> htmlDocs, int statemetnType)
        {
            var webSiteUrl = "https://ss.ge/ka/udzravi-qoneba";
            List<ScrapperModel> house = new List<ScrapperModel>();

            Parallel.ForEach(htmlDocs, new ParallelOptions { MaxDegreeOfParallelism = 20 },
                  htmlDoc =>
                  {

                      var document = htmlDoc.DocumentNode.SelectNodes("//div[@class = 'DesktopArticleLayout']");

                      Parallel.ForEach(document, new ParallelOptions { MaxDegreeOfParallelism = 20 },
                  doc =>
                  {
                      #region GetPrice
                      var priceHtml = doc.Descendants("div")
                                          .Where(node => node.GetAttributeValue("class", "")
                                          .Equals("latest_price")).ToList();
                      var price = priceHtml[1].InnerText.Replace(" ", "").Trim().ToString();
                      #endregion

                      #region GetDataId
                      var dataIdHtml = doc.Descendants("div")
                                           .Where(node => node.GetAttributeValue("class", "")
                                           .Equals("latest_mark_delete_block")).ToList();
                      var dataId = dataIdHtml[0].InnerHtml.Split("data-id=", 20)[1].Substring(1, 7);
                      #endregion

                      #region CreateDate
                      var CreateDateHtml = doc.Descendants("div")
                                               .Where(node => node.GetAttributeValue("class", "")
                                               .Equals("add_time")).ToList();
                      var createDate = CreateDateHtml[0].InnerText.Trim().Substring(0, 10).ToString();
                      #endregion

                      #region SquareMeter
                      var SquareMeterDateHtml = doc.Descendants("div")
                                                    .Where(node => node.GetAttributeValue("class", "")
                                                    .Equals("latest_flat_km")).ToList();
                      var squareMeter = SquareMeterDateHtml[0].InnerText.Trim().Substring(0, 4).Trim().ToString();
                      #endregion

                      #region PriceOneSquareMeter
                      var priceOneSquareMeterHtml = doc.Descendants("div")
                                                         .Where(node => node.GetAttributeValue("class", "")
                                                         .Equals("latest_km_price")).ToList();

                      var priceOneSquareMeter = "0";

                      if (priceOneSquareMeterHtml.Count == 2)
                      {
                          priceOneSquareMeter = priceOneSquareMeterHtml[1].InnerText.Trim().Replace("1 m&#xB2; - ", "").ToString();
                      }
                      #endregion

                      #region Address
                      var addressHtml = doc.Descendants("span")
                                                        .Where(node => node.GetAttributeValue("class", "")
                                                        .Equals("TiTleSpanList")).ToList();
                      var address = addressHtml[0].InnerHtml.Trim().ToString();
                      #endregion

                      house.Add(new ScrapperModel()
                      {
                          WebSiteName = "SS.GE",
                          HouseId = dataId,
                          CreateDate = createDate,
                          PriceInUsd = price,
                          SquareMeter = squareMeter,
                          PriceOneSquareMeter = priceOneSquareMeter,
                          Address = address,
                          JobCreate = DateTime.Now,
                          StatementType = statemetnType
                      });

                  });
                  });


            var toDayHouse = house.Where(x => x.CreateDate == DateTime.Now.ToString("dd.MM.yyyy")).ToList();
            var checkStatementIfAlreadyExist = CheckStatementIfAlreadyExist(toDayHouse, "SS.GE");
            if (checkStatementIfAlreadyExist.Any())
            {
                _dbContext.Scrapper.AddRange(toDayHouse);
                _dbContext.SaveChanges();

                var subjectInBody = CreateEmailSubject(toDayHouse, webSiteUrl);

                SendEmailData($"SS.GE (ბინები რაოდენობა {toDayHouse.Count()})", subjectInBody);
            }

        }

        public string CreateEmailSubject(List<ScrapperModel> house, string webSiteUrl)
        {
            var subjectInBody = $"განახლებულია {DateTime.Now} \n \n \n";

            foreach (var item in house)
            {
                subjectInBody = subjectInBody + $"ID - {item.HouseId}\n თარიღი - {item.CreateDate}\n ფასი - {item.PriceInUsd}\n ფასი 1 კვადრატულის - {item.PriceOneSquareMeter}\n საერთო ფართი - {item.SquareMeter}\n მისამართი - {item.Address}\n {webSiteUrl}/{item.HouseId} \n \n \n";
            }

            return subjectInBody;
        }

        public void SendEmailData(string subject, string subjectInBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress($"{subject}", $"test"));
            message.To.Add(new MailboxAddress($"{subject}", $"binebiscrapper@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = subjectInBody
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("binebiscrapper@gmail.com", "ijhdtguxqkqwgsbg");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public List<ScrapperModel> CheckStatementIfAlreadyExist(List<ScrapperModel> houses, string webSiteName)
        {
            var houseInDb = GetAll().Where(x => x.WebSiteName == $"{webSiteName}" && x.CreateDate == DateTime.Now.ToString("dd.MM.yyyy")).ToList();
            if (webSiteName == "MYHOME.GE")
            {
                houseInDb = GetAll().Where(x => x.WebSiteName == $"{webSiteName}" && x.CreateDate == DateTime.Now.ToString("yyyy-MM-dd")).ToList();
            }

            Parallel.ForEach(houseInDb, new ParallelOptions { MaxDegreeOfParallelism = 20 },
                  house =>
                  {
                      if (houses.FirstOrDefault(x => x.HouseId == house.HouseId) != null)
                      {
                          houses.Remove(houses.Where(x => x.HouseId == house.HouseId).FirstOrDefault());
                      }
                  });

            return houses;
        }

        public async Task<HtmlDocument> GetHtmlDocument(string url)
        {
            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            return htmlDocument;
        }

        public HtmlDocument DecodeUnicode(HtmlDocument htmlDocument)
        {
            var htmlToString = htmlDocument.DocumentNode.InnerHtml;
            var splitted = Regex.Split(htmlToString, @"\\u([a-fA-F\d]{4})");
            string outString = "";
            foreach (var s in splitted)
            {
                try
                {
                    if (s.Length == 4)
                    {
                        var decoded = ((char)Convert.ToUInt16(s, 16)).ToString();
                        outString += decoded;
                    }
                    else
                    {
                        outString += s;
                    }
                }
                catch (Exception e)
                {
                    outString += s;
                }
            }

            htmlDocument.DocumentNode.InnerHtml = outString;

            return htmlDocument;
        }

        #endregion
    }
}
