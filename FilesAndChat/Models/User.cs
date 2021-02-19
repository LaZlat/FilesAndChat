namespace FilesAndChat.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    class User
    {
        private ObservableCollection<File> files;
        private ObservableCollection<Friend> friends;
        private ObservableCollection<string> chat;

        public User()
        {
            files = new ObservableCollection<File>();
            friends = new ObservableCollection<Friend>();
            chat = new ObservableCollection<string>();
        }
        public String Username { get; set; }
        public ObservableCollection<File> Files { get => files; set => files = value; }
        public ObservableCollection<Friend> Friends { get => friends; set => friends = value; }
        public ObservableCollection<string> Chat { get => chat; set => chat = value; }

    }

}
