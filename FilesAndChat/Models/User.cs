namespace FilesAndChat.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {

        }
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public String Username { get; set; }
        public ICollection<File> Files { get; set; } = new Collection<File>();
        public ICollection<Friend> Friends { get; set; } = new Collection<Friend>();
        public ICollection<Message> Msg { get; set; } = new Collection<Message>();
    }

}
