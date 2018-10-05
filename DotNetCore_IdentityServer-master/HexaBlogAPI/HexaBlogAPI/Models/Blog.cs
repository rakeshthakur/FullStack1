using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HexaBlogAPI.Models
{
    public class Blog:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }

        [Required]        
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string AddedBy { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }
    }
}
