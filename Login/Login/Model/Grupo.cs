using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_LoginForm.Model
{
    public class Grupo : INotifyPropertyChanged
    {
        private int _idGrupo;
        private string _nombre = string.Empty;

        public int IdGrupo
        {
            get => _idGrupo;
            set
            {
                _idGrupo = value;
                OnPropertyChanged();
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
