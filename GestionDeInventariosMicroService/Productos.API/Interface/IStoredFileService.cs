using Productos.API.Entity;

namespace Productos.API.Interface
{
    public interface IStoredFileService
    {
        Task<StoredFile> SaveAsync(IFormFile file);

    }
}
