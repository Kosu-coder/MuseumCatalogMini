using System.ComponentModel.DataAnnotations;

namespace MuseumCatalogMini.Data.Entities;

public class Exhibition
{
    public Guid ExhibitionId { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public Guid MuseumId { get; set; }
    public Museum Museum { get; set; } = null!;

    public ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
