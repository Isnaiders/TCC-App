using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TCC_App.Models.Enum.Parking;

namespace TCC_API.Models.DTOs
{
    public class ParkingDetailedDTO : BaseDTO
    {
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string PostalCode { get; set; }
        public Guid CountryId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string CountryName { get; set; }
        public Guid StateId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string StateName { get; set; }
        public Guid CityId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string CityName { get; set; }
        public Guid NeighborhoodId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string NeighborhoodName { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string AddressComplement { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Longitude { get; set; }
        public ParkingLocationType LocationType { get; set; }
    }
}
