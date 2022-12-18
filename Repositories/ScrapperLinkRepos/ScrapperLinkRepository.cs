using System.Collections.Generic;
using System.Linq;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Repositories.ScrapperLinkRepos
{
    public class ScrapperLinkRepository : IScrapperLinkRepository
    {
        private readonly ScrapperDbContext _context;
        public ScrapperLinkRepository(ScrapperDbContext context)
        {
            _context = context;
        }
        public void AddLink(ScrapperLinkModel model)
        {
            _context.ScrapperLink.Add(model);
            _context.SaveChanges();
        }

        public void DeleteLink(int id)
        {
            var link = _context.ScrapperLink.FirstOrDefault(x => x.Id == id);
            link.IsDeleted = true;

            _context.ScrapperLink.Update(link);
            _context.SaveChanges();
        }

        public IEnumerable<ScrapperLinkModel> GetLinks()
        {
            var result = _context.ScrapperLink.Where(x => x.IsDeleted == false);
            return result;
        }
    }
}
