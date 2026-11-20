namespace MuseumCatalogMini.Services.DTOs.Museums;

public class MuseumListDto
{
    public Guid MuseumId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal EntryTax { get; set; }
    public int ExhibitCount { get; set; }
    public int CuratorCount { get; set; }
    public int ExhibitionCount { get; set; }
}
