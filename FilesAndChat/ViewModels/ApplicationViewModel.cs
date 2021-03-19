
namespace FilesAndChat.ViewModels
{
    using FilesAndChat.Commands;
    using FilesAndChat.DataContext;
    using FilesAndChat.Models;
    using FilesAndChat.Views;
    using GalaSoft.MvvmLight.Command;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Win32;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;

    internal class ApplicationViewModel : DefaultViewMode, IDataErrorInfo
    {
        private User user;
        private File file = new File();

        public ApplicationViewModel(User _user)
        {
            user = _user;
            ChooseCommand = new DelegateCommand(ChooseFile);
            AddCommand = new ApplicationAddCommand(this);
            SendCommand = new ApplicationSendCommand(this);
            LogOffCommand = new DelegateCommand(LogOff);
        }

        public string Message { get; set; } = "";

        public string FileName
        {
            get
            {
                return file.FileName;
            }
            set
            {
                file.FileName = value;
            }
        }

        public string FilePath
        {
            get
            {
                return file.FilePath;
            }
            set
            {
                file.FilePath = value;
            }
        }

        public ObservableCollection<File> Files
        {
            get
            {
                var cont = new TheContext();

                var smth = cont.Users.Where(a => a.Username == user.Username).Select(a => a.Files).SingleOrDefault();
                ObservableCollection < File > newOne = new ObservableCollection<File>(smth);
                cont.Dispose();

                return newOne;
            }
        }

        public ObservableCollection<User> People
        {
            get
            {
                var cont = new TheContext();

                var smth = cont.Users.Where(a => a.Id != user.Id).ToList();
                ObservableCollection<User> newOne = new ObservableCollection<User>(smth);
                cont.Dispose();

                return newOne;
            }
        }

        public ObservableCollection<string> Msg
        {
            get
            {
                var cont = new TheContext();

                var smth = cont.Messages.Select(a => a.Msg).ToList();
                ObservableCollection<string> newOne = new ObservableCollection<string>(smth);
                cont.Dispose();
;
                return newOne;
            }
        }

        public ObservableCollection<File> FriendFiles
        {
            get
            {
                var cont = new TheContext();

                //var smth = cont.Messages.Select(a => a.Msg).ToList();
                ObservableCollection<File> newOne = new ObservableCollection<File>();
                cont.Dispose();
                ;
                return newOne;
            }
        }

        public string Username
        {
            get
            {
                return user.Username;
            }
        }

        public ICommand ChooseCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SendCommand { get; private set; }
        public ICommand LogOffCommand { get; private set; }


        public void AddFileToList()
        {
            var cont = new TheContext();
            user.Files.Add(file);
            cont.Users.Update(user);

            cont.SaveChanges();
            cont.Dispose();

            OnPropertyChanged("Files");
            OnPropertyChanged("FilePath");
        }

        public void ChooseFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                FileName = openFileDialog.SafeFileName;
                OnPropertyChanged("FilePath");
            }
        }


        public void SendMessage()
        {
            var cont = new TheContext();

            user.Msg.Add(new Message{ Msg = user.Username + ": " + Message});
            cont.Users.Update(user);

            cont.SaveChanges();
            cont.Dispose();
            OnPropertyChanged("Msg");
            Message = "";
            OnPropertyChanged("Message");
        }

        public void LogOff(object parameter)
        {
            if (parameter is System.Windows.Window)
            {
                MainWindow view = new MainWindow();
                view.DataContext = new UserViewModel();
                view.Show();
                (parameter as System.Windows.Window).Close();
            }
        }

        private RelayCommand<File> _deleteCommand;
        public RelayCommand<File> DeleCommand
        {
            get
            {
                return _deleteCommand
                  ?? (_deleteCommand = new RelayCommand<File>(
                    _file =>
                    {
                        var cont = new TheContext();
                        cont.Files.Remove(_file);
                        //cont.Users.Update(user);

                        cont.SaveChanges();
                        cont.Dispose();
                        OnPropertyChanged("Files");
                    }));
            }
        }

        private RelayCommand<User> _addFriendCommand;
        public RelayCommand<User> AddFriendCommand
        {
            get
            {
                return _addFriendCommand
                  ?? (_addFriendCommand = new RelayCommand<User>(
                    _friend =>
                    {
                        var cont = new TheContext();

                        Friend newFriend = new Friend();

                        newFriend.FriendsId = _friend.Id;
                        //newFriend.FriendFiles.Add(cont.Users.Where(a => a.Id == _friend.Id).Select(b => b.Files).ToList());

                        user.Friends.Add(new Friend { FriendsId = _friend.Id });
                        cont.Users.Update(user);

                        cont.SaveChanges();
                        cont.Dispose();
                        OnPropertyChanged("FriendFiles");
                    }));
            }
        }
        public string Error { get; private set; }

        public string this[string columnName]
        {
            get
            {
                Error = null;
                switch (columnName)
                {
                    case "Message": if (string.IsNullOrWhiteSpace(Message)) Error = "You can't spam with empty messages"; break;
                    case "FilePath": if (string.IsNullOrWhiteSpace(FilePath)) Error = "Must provide file path"; break;
                }
                return Error;
            }
        }
    }
}
