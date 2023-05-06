using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_App.Models.Parkings
{
    public class ParkingReservation
    {
        public Guid Id { get; set; }
        public Guid ParkingId { get; set; }
        public Guid CartId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
