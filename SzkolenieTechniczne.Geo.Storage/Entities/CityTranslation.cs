using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage.Entities
{
    [Index(nameof(Name), IsUnique = false)]
    [Table("CityTranslactions", Schema = "Geo")]
    public class CityTranslation : BaseTranslation
    {
        [ForeignKey("City")]
        public Guid Cityid { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
