using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories.ScrapperRepos
{
    public interface IScrapperRepository
    {
        IEnumerable<ScrapperModel> GetAll();
        void ScrapperJob();
    }
}
