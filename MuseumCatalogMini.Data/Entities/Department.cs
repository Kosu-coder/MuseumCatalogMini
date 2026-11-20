using System.ComponentModel.DataAnnotations;

namespace MuseumCatalogMini.Data.Entities;

public class Department
{
    public Guid DepartmentId { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public Guid MuseumId { get; set; }
    public Museum Museum { get; set; } = null!;

    public ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
