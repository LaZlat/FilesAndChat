
namespace FilesAndChat.ViewModels
{
    using FilesAndChat.Commands;
    using FilesAndChat.Models;
    using FilesAndChat.Views;
    using GalaSoft.MvvmLight.Command;
    using Microsoft.Win32;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
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
                return user.Files;
            }
        }

        public ObservableCollection<Friend> Friends
        {
            get
            {
                return user.Friends;
            }
        }

        public ObservableCollection<string> Chat
        {
            get
            {
                return user.Chat;
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

        /*NEBEREIKIA
        public bool CanAdd
        {
            get
            {
                if (FilePath == null)
                    return false;

                return !string.IsNullOrWhiteSpace(FilePath);
            }
        }*/


        public void AddFileToList()
        {
            Files.Add(file);
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

        /*NEBEREIKIA
        public bool CanSend
        {
            get
            {
                if (Message == null)
                    return false;

                return !string.IsNullOrWhiteSpace(Message);
            }
        }*/

        public void SendMessage()
        {
            Chat.Add(Username + ": " + Message);
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
