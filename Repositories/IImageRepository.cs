using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
