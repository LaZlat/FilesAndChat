using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndChat.Models
{
    public class Friend
    {
        public int Id { get; set; }
        [Required]
        public int FriendsId { get; set; }
        public ICollection<FriendFile> FriendFiles { get; set; }
    }
}
