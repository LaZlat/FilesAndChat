
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
                ///var smth = cont.Users.Select(d => d.Files);
                ObservableCollection < File > newOne = new ObservableCollection<File>(smth);

                //cont.SaveChanges();
                cont.Dispose();
                //ObservableCollection<File> newOne = new ObservableCollection<File>(user.Files);
                //ObservableCollection<File> newOne = new ObservableCollection<File>();
                return newOne;
            }
        }

        public ObservableCollection<Friend> Friends
        {
            get
            {
                ObservableCollection<Friend> newOne = new ObservableCollection<Friend>();
                return newOne;
            }
        }

        public ObservableCollection<Message> Msg
        {
            get
            {
                ObservableCollection<Message> newOne = new ObservableCollection<Message>();
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
            //Message.Add(Username + ": " + Message);
            OnPropertyChanged("Chat");
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
                        Files.Remove(_file);
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
