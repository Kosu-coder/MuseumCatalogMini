using System.ComponentModel.DataAnnotations;

namespace MuseumCatalogMini.Data.Entities;

public class Curator
{
    public Guid CuratorId { get; set; }

    [Required, MaxLength(120)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Position { get; set; } = string.Empty;

    [EmailAddress, MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    public Guid MuseumId { get; set; }
    public Museum Museum { get; set; } = null!;
}
