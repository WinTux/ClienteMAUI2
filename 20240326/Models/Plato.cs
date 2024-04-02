using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240326.Models
{
    public class Plato : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _Id;
        public int Id {
            get { return _Id; }
            set {
                if (_Id == value)
                    return;
                _Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        private string _Nombre;
        public string Nombre {
            get { return _Nombre; }
            set
            {
                if (_Nombre == value)
                    return;
                _Nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }
    }
}
