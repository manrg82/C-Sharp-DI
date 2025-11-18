using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruiz_Gutierrez_Manuel_MiniHito2.domain
{
    class Alumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Especialidad { get; set; }
        public int Grupo { get; set; }

        public Alumno(String nm,String ap,int es,int gr) {
            {
                this.Nombre = nm;
                this.Apellidos = ap;
                this.Especialidad = es;
                this.Grupo = gr;
            } 
        }

    }
}
