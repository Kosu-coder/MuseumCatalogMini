using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCatalogMini.Data.Entities
{
    internal class Museum
    {
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        [Range(0, int.MaxValue)]
        public decimal EntryTax { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
