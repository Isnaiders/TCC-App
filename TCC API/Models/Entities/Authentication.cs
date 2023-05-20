﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TCC_API.Models.Entities
{
    [Index("UserId", Name = "IX_UserId")]
    public partial class Authentication
    {
        [Key]
        public Guid AuthenticationId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string UserName { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime WhenCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WhenUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WhenRemoved { get; set; }
        public int SystemStatus { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Authentication")]
        public virtual User User { get; set; }
    }
}