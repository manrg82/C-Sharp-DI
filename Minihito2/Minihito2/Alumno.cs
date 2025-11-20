using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minihito2.persistence.manages;

namespace Minihito2
{
    internal class Alumno
    {
        private int id;
        private String nombre;
        private String apellidos;
        private int especialidad;
        private String grupo;
        //private List<Alumno> listaAlumnos;
        public AlumnoManage pm;
        int Id_;

        public Alumno(int id, string nombre, string apellidos, int especialidad, String grupo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.especialidad = especialidad;
            this.grupo = grupo;
            pm = new AlumnoManage();
        }

        public Alumno() {
            pm = new AlumnoManage();
        }

        public Alumno(int id)
        {
            pm = new AlumnoManage();
            Id_ = id;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellidos { get { return apellidos; } set { apellidos = value; } }
        public int Especialidad { get { return especialidad; } set { especialidad = value; } }
        public String Grupo { get { return grupo; } set { grupo = value; } }


        //Devuelve la lista de alumnos de la base de datos de forma simulada
        public List<Alumno> GetAlumnos()
        {
            return pm.LeerAlumnos();
        }

        public List<Alumno> GetEspecialidad(int especialidadCmb)
        {
            return pm.LeerEspecialidad(especialidadCmb);
        }

        public void Insertar(){
            pm.InsertarAlumno(this);
        }

        public void Modificar()
        {
            pm.UpdateAlumno(this);
        }

        public void Eliminar()
        {
            pm.DeleteAlumno(this);
        }
        /*
        public void Last()
        {
            pm.LastId(this);
        }
        */
    }
}