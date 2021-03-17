namespace FilesAndChat.ViewModels
{
    using FilesAndChat.Commands;
    using FilesAndChat.Models;
    using FilesAndChat.Views;
    using System.ComponentModel;
    using System.Windows.Input;

    internal class UserViewModel : DefaultViewMode, IDataErrorInfo
    {
        private User user;
        private ApplicationViewModel applicationViewModel;

        public UserViewModel()
        {
            user = new User();
            LoginCommand = new UserLoginCommand(this);
        }

        public string this[string columnName]
        {
            get
            {
                Error = null;
                if (columnName == "Username")
                    if (string.IsNullOrWhiteSpace(Username))
                    {
                        Error = "Username is a must!";
                    }
                return Error;
            }
        }

        public string Username
        {
            get
            {
                return user.Username;
            }
            set
            {
                user.Username = value;
            }
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }


        public string Error { get; private set; }

        public void LoginUser(object parameter)
        {

            if (parameter is System.Windows.Window)
            {
                ApplicationWindow view = new ApplicationWindow();
                applicationViewModel = new ApplicationViewModel(user);

                view.DataContext = applicationViewModel;
                view.Show();

                (parameter as System.Windows.Window).Close();
            }
        }

    }
}
