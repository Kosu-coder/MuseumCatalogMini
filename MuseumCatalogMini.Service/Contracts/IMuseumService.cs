using MuseumCatalogMini.Services.DTOs.Museums;

namespace MuseumCatalogMini.Services.Contracts;

public interface IMuseumService
{
    Task<List<MuseumListDto>> GetAll();
}
