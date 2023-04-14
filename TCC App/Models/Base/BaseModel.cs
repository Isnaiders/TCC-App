using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_App.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenRemoved { get; set; }

        //[NotMapped]
        //[NonSerialized]
        public ValidationResult ValidationResult;
    }
}
