using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minihito2
{
    class Empresa
    {
        List<Empresa> lista;
        private int id_empresa { get { return id_empresa; } set { id_empresa = value;} }
        private string ciudad { get { return ciudad; } set { ciudad = value; } }
        private string direccion { get { return direccion; } set { direccion = value; } }
        private string correo { get { return correo; } set { correo = value; } }
        private string telefono { get { return correo; } set { correo = value; } }
        private string razonsoc { get { return correo; } set { correo = value; } }
        public Empresa(int id, string ciud, string dir, string cor, string tel, string rac) {
            this.id_empresa = id;
            this.ciudad = ciud;
            this.direccion = dir;
            this.correo = cor;
            this.telefono = tel;
            this.razonsoc = rac;
        }
        public Empresa() { }
        public List<Empresa> getEmpresas() {
            return lista;
        }
        public string getRazon() {

            return razonsoc;
            } 

    }
}
