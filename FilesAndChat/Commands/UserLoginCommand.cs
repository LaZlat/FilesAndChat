namespace FilesAndChat.Commands
{
    using FilesAndChat.ViewModels;
    using System;
    using System.Windows.Input;
    internal class UserLoginCommand : ICommand
    {
        private UserViewModel _ViewModel;
        public UserLoginCommand(UserViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged
        { 
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return string.IsNullOrWhiteSpace(_ViewModel.Error);
        }

        public void Execute(object parameter)
        {
            _ViewModel.LoginUser(parameter);
        }
    }
}
