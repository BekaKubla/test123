using System.ComponentModel;

namespace WebApplication5.Models
{
    public class ScrapperLinkModel
    {
        public int Id { get; set; }
        [DisplayName("ლინკი")]
        public string ScrapperUrl { get; set; }

        [DisplayName("ქალაქის სახელი")]
        public string CityName { get; set; }

        [DisplayName("საიტი")]
        public Site SiteType { get; set; }

        public bool IsDeleted { get; set; }

        [DisplayName("განცხადების ტიპი")]
        public StatementType StatementType { get; set; }
        [DisplayName("გვერდების რაოდენობა")]
        public short PageCount { get; set; }
    }

    public enum Site
    {
        MyHome = 1,
        SS = 2
    }
}
