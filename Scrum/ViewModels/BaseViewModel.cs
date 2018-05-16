using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Scrum.Annotations;
using Scrum.Common;
using Scrum.SQL;

namespace Scrum.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            SaveCommand = ReactiveUI.ReactiveCommand.Create(() =>
            {
                Context.SaveChanges();
            });
        }

        public IContext Context { get; protected set; }
        public ICommand SaveCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
