using BulkyAPI.Models.Domain;

namespace BulkyAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
