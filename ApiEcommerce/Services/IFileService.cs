using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerce.Services
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file);
    }
}
