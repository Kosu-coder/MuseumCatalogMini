using Microsoft.EntityFrameworkCore;
using MuseumCatalogMini.Data;
using MuseumCatalogMini.Services.Contracts;
using MuseumCatalogMini.Services.DTOs.Museums;

namespace MuseumCatalogMini.Services;

public class MuseumService : IMuseumService
{
    private readonly MuseumDbContext _db;

    public MuseumService(MuseumDbContext db)
    {
        _db = db;
    }

    public Task<List<MuseumListDto>> GetAll()
    {
        return _db.Museums
            .OrderBy(m => m.Name)
            .Select(m => new MuseumListDto
            {
                MuseumId = m.MuseumId,
                Name = m.Name,
                Region = m.Region,
                Type = m.Type,
                EntryTax = m.EntryTax,
                ExhibitCount = m.Exhibits.Count,
                CuratorCount = m.Curators.Count,
                ExhibitionCount = m.Exhibitions.Count
            })
            .ToListAsync();
    }
}
