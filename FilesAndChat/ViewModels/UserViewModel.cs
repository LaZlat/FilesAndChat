namespace FilesAndChat.ViewModels
{
    using FilesAndChat.Commands;
    using FilesAndChat.DataContext;
    using FilesAndChat.Models;
    using FilesAndChat.Views;
    using System.ComponentModel;
    using System.Linq;
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
            var cont = new TheContext();

            var existingUser = cont.Users.Where(s => s.Username == user.Username).FirstOrDefault<User>();
            if (existingUser == null)
            {
                cont.Add(user);
                cont.SaveChanges();
                existingUser = user;
                cont.Dispose();
            } 

            if (parameter is System.Windows.Window)
            {
                ApplicationWindow view = new ApplicationWindow();
                applicationViewModel = new ApplicationViewModel(existingUser);

                view.DataContext = applicationViewModel;
                view.Show();

                (parameter as System.Windows.Window).Close();
            }
        }

    }
}
