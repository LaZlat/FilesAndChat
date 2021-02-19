using FilesAndChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilesAndChat.Commands
{
    internal class ApplicationAddCommand : ICommand
    {
        private ApplicationViewModel _ViewModel;
        public ApplicationAddCommand(ApplicationViewModel viewModel)
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
            _ViewModel.AddFileToList();
        }
    }
}
