using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndChat.Models
{
    public class FriendFile
    {
        public int Id { get; set; }
        public File File { get; set; }
        public Friend Friend {get; set; }
    }
}
