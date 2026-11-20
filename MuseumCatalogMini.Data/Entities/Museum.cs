using System.ComponentModel.DataAnnotations;

namespace MuseumCatalogMini.Data.Entities;

public class Museum
{
    public Guid MuseumId { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Region { get; set; } = string.Empty;

    [Required, MaxLength(80)]
    public string Type { get; set; } = string.Empty;

    [Range(0, 10000)]
    public decimal EntryTax { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
    public ICollection<Curator> Curators { get; set; } = new List<Curator>();
    public ICollection<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}
