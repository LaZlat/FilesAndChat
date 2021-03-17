using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public String Msg { get; set; }
    }
}
