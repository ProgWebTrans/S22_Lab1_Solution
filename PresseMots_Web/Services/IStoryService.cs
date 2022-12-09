using PresseMots_DataAccess.Services;
using PresseMots_DataModels.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresseMots_Web.Services
{
    public interface IStoryService : IServiceBase<Story>
    {
        public List<Story> SearchByTagName(string tagName);
    }


}
