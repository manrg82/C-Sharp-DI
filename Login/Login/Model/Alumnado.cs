using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_LoginForm.Model
{
    public class Alumnado : INotifyPropertyChanged
    {
        private int _idAlumnado;
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _curso = string.Empty;
        private int? _grupoId;

        public int IdAlumnado
        {
            get => _idAlumnado;
            set
            {
                _idAlumnado = value;
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

        public string Apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                OnPropertyChanged();
            }
        }

        public string Curso
        {
            get => _curso;
            set
            {
                _curso = value;
                OnPropertyChanged();
            }
        }

        public int? GrupoId
        {
            get => _grupoId;
            set
            {
                _grupoId = value;
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
