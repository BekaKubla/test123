using System.Collections.Generic;
using WebApplication5.Models;

namespace WebApplication5.Repositories.ScrapperLinkRepos
{
    public interface IScrapperLinkRepository
    {
        void AddLink(ScrapperLinkModel model);
        IEnumerable<ScrapperLinkModel> GetLinks();
        void DeleteLink(int id);
    }
}
