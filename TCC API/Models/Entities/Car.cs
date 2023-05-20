﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TCC_API.Models.Entities
{
    public partial class Car
    {
        public Car()
        {
            ParkingReservation = new HashSet<ParkingReservation>();
            ParkingReservationHistory = new HashSet<ParkingReservationHistory>();
        }

        [Key]
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Plate { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Model { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime WhenCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WhenUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WhenRemoved { get; set; }
        public int SystemStatus { get; set; }

        [InverseProperty("Car")]
        public virtual ICollection<ParkingReservation> ParkingReservation { get; set; }
        [InverseProperty("Car")]
        public virtual ICollection<ParkingReservationHistory> ParkingReservationHistory { get; set; }
    }
}