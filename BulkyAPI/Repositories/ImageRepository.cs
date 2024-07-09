using BulkyAPI.Data;
using BulkyAPI.Models.Domain;

namespace BulkyAPI.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment host;
        private readonly IHttpContextAccessor httpContext;
        private readonly NZWalksDbContext db;

        public ImageRepository(IWebHostEnvironment host, IHttpContextAccessor httpContext, NZWalksDbContext db)
        {
            this.host = host;
            this.httpContext = httpContext;
            this.db = db;
        }


        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(host.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // https://localhost:1234/images/image.jpg
            var urlFilePath =
                $"{httpContext.HttpContext.Request.Scheme}://" +
                $"{httpContext.HttpContext.Request.Host}" +
                $"{httpContext.HttpContext.Request.PathBase}/Images/" +
                $"{image.FileName}" +
                $"{image.FileExtension}";
            image.FilePath = urlFilePath; 

            await db.Images.AddAsync(image);
            await db.SaveChangesAsync();
            return image; 
        }
    }
}
