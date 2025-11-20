using System.Data;
using System.Diagnostics;


namespace Minihito2.persistence.manages
{
    internal class AlumnoManage
    {
        private static DBBroker dBBroker = DBBroker.obtenerAgente();

        public AlumnoManage()
        {
            table = new DataTable();
        }

        private DataTable table { get; set; } //TODO Revisar
        List<Alumno> listaAlumnos {  get; set; }

        //Simulación lectura de datos

        public List<Alumno> LeerAlumnos()
        {
            Alumno alumno = null;
            List<object> aux = DBBroker.obtenerAgente().leer("SELECT a.idAlumnado, a.nombre, a.apellidos, a.especialidad, g.nombre FROM aceptasreto.alumnado a INNER JOIN aceptasreto.grupo g ON a.grupo = g.idgrupo");
            listaAlumnos = new List<Alumno>();
            foreach(List<object> c in aux)
            {
                alumno = new Alumno(Convert.ToInt32(c[0]), Convert.ToString(c[1]), Convert.ToString(c[2]), Convert.ToInt32(c[3]), Convert.ToString(c[4]));
                listaAlumnos.Add(alumno);
            }

            return listaAlumnos;
        }

        public List<Alumno> LeerEspecialidad(int especialidadCmb)
        {
            Alumno alumno = null;
            List<object> aux = dBBroker.leer($"SELECT * FROM aceptasreto.alumnado WHERE ESPECIALIDAD = {especialidadCmb}");
            listaAlumnos = new List<Alumno>();
            foreach (List<object> c in aux)
            {
                alumno = new Alumno(Convert.ToInt32(c[0]), Convert.ToString(c[1]), Convert.ToString(c[2]), Convert.ToInt32(c[3]), Convert.ToString(c[4]));
                listaAlumnos.Add(alumno);
            }

            return listaAlumnos;
        }

        /*
        public void LastId(alumno alumno)
        {
            List<Object> listaalumnos;
            listaalumnos = DBBroker.obtenerAgente().leer("SELECT MAX(IDalumno) FROM mydb.alumno");
            foreach(List<Object> aux in listaalumnos)
            {
                alumno.Id = Convert.ToInt32(aux[0]) + 1;
            }
        }
        */

        public void InsertarAlumno(Alumno alumno)
        {
            string sql = $"INSERT INTO aceptasreto.alumnado VALUES (null, '{alumno.Nombre}', '{alumno.Apellidos}', '{alumno.Especialidad}', '{alumno.Grupo}')";
            dBBroker.modificar(sql);
        }

        public void UpdateAlumno(Alumno alumno)
        {
            string sql = $"UPDATE alumnado SET nombre = '{alumno.Nombre}', apellidos = '{alumno.Apellidos}', especialidad = '{alumno.Especialidad}' WHERE idAlumnado = '{alumno.Id}'";
            dBBroker.modificar(sql);
        }

        public void DeleteAlumno(Alumno alumno)
        {
            string sql = $"DELETE FROM alumno WHERE idAlumno = '{alumno.Id}'";
            dBBroker.modificar(sql);
        }
    }
}