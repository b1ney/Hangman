using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected void Set<T>(ref T property, T value, [CallerMemberName]string name = null)
        {
            if (!EqualityComparer<T>.Default.Equals(property, value))
            {
                property = value;
                UpdatePropertyChanged(name);
            }
        }

        protected void UpdatePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
