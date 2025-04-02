using Productos.API.Entity;
using Productos.API.Interface;

namespace Productos.API.Services
{
    public class StoredFileService : IStoredFileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public StoredFileService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<StoredFile> SaveAsync(IFormFile file)
        {
            var fileId = Guid.NewGuid();
            var extension = Path.GetExtension(file.FileName);
            var newFileName = $"{fileId}{extension}";
            var folder = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var storedFile = new StoredFile
            {
                Id = fileId,
                FileName = file.FileName,
                ContentType = file.ContentType ?? "application/octet-stream",
                SizeInBytes = file.Length,
                Url = $"/uploads/{newFileName}"
            };

            _context.StoredFiles.Add(storedFile);
            await _context.SaveChangesAsync();

            return storedFile;
        }
    }
}
