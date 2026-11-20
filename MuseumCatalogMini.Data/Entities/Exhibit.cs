using System.ComponentModel.DataAnnotations;

using MuseumCatalogMini.Data.Enums;

namespace MuseumCatalogMini.Data.Entities;

public class Exhibit
{
    public Guid ExhibitId { get; set; }

    [Required, MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(80)]
    public string Period { get; set; } = string.Empty;

    public int? CreationYear { get; set; }

    public ExhibitCategory Category { get; set; } = ExhibitCategory.Other;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public Guid MuseumId { get; set; }
    public Museum Museum { get; set; } = null!;

    public Guid? ExhibitionId { get; set; }
    public Exhibition? Exhibition { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
