































































































































.



























............................................................................................................
    



























































.......................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WPF_LoginForm.Model;

namespace WPF_LoginForm.DAL
{
    public class DbBroker
    {
        private static DbBroker? _instance;
        private readonly string _connectionString;

        private DbBroker()
        {
            _connectionString = "Server=localhost;Database=minihito2;User=root;Password=;";
        }

        public static DbBroker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbBroker();
                }
                return _instance;
            }
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public List<Alumnado> GetAllAlumnos()
        {
            var alumnos = new List<Alumnado>();

            using var connection = GetConnection();
            connection.Open();

            string query = "SELECT idalumnado, nombre, apellidos, curso, grupo FROM alumnado";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                alumnos.Add(new Alumnado
                {
                    IdAlumnado = reader.GetInt32("idalumnado"),
                    Nombre = reader.GetString("nombre"),
                    Apellidos = reader.GetString("apellidos"),
                    Curso = reader.GetString("curso"),
                    GrupoId = reader.IsDBNull(reader.GetOrdinal("grupo")) ? null : reader.GetInt32("grupo")
                });
            }

            return alumnos;
        }

        public List<Alumnado> GetAlumnosSinAsignar()
        {
            var alumnos = new List<Alumnado>();

            using var connection = GetConnection();
            connection.Open();

            string query = "SELECT idalumnado, nombre, apellidos, curso, grupo FROM alumnado WHERE grupo IS NULL";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                alumnos.Add(new Alumnado
                {
                    IdAlumnado = reader.GetInt32("idalumnado"),
                    Nombre = reader.GetString("nombre"),
                    Apellidos = reader.GetString("apellidos"),
                    Curso = reader.GetString("curso"),
                    GrupoId = null
                });
            }

            return alumnos;
        }

        public List<Alumnado> GetAlumnosByGrupo(int grupoId)
        {
            var alumnos = new List<Alumnado>();

            using var connection = GetConnection();
            connection.Open();

            string query = "SELECT idalumnado, nombre, apellidos, curso, grupo FROM alumnado WHERE grupo = @grupo";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@grupo", grupoId);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                alumnos.Add(new Alumnado
                {
                    IdAlumnado = reader.GetInt32("idalumnado"),
                    Nombre = reader.GetString("nombre"),
                    Apellidos = reader.GetString("apellidos"),
                    Curso = reader.GetString("curso"),
                    GrupoId = reader.GetInt32("grupo")
                });
            }

            return alumnos;
        }

        public bool InsertAlumno(Alumnado alumno)
        {
            using var connection = GetConnection();
            connection.Open();

            string query = "INSERT INTO alumnado (nombre, apellidos, curso, grupo) VALUES (@nombre, @apellidos, @curso, @grupo)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", alumno.Nombre);
            command.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
            command.Parameters.AddWithValue("@curso", alumno.Curso);
            command.Parameters.AddWithValue("@grupo", alumno.GrupoId.HasValue ? (object)alumno.GrupoId.Value : DBNull.Value);

            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateAlumno(Alumnado alumno)
        {
            using var connection = GetConnection();
            connection.Open();

            string query = "UPDATE alumnado SET nombre=@nombre, apellidos=@apellidos, curso=@curso, grupo=@grupo WHERE idalumnado=@id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", alumno.IdAlumnado);
            command.Parameters.AddWithValue("@nombre", alumno.Nombre);
            command.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
            command.Parameters.AddWithValue("@curso", alumno.Curso);
            command.Parameters.AddWithValue("@grupo", alumno.GrupoId.HasValue ? (object)alumno.GrupoId.Value : DBNull.Value);

            return command.ExecuteNonQuery() > 0;
        }

        public bool DeleteAlumno(int id)
        {
            using var connection = GetConnection();
            connection.Open();

            string query = "DELETE FROM alumnado WHERE idalumnado=@id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;
        }

        public List<Grupo> GetAllGrupos()
        {
            var grupos = new List<Grupo>();

            using var connection = GetConnection();
            connection.Open();

            string query = "SELECT idgrupo, nombre FROM grupo";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                grupos.Add(new Grupo
                {
                    IdGrupo = reader.GetInt32("idgrupo"),
                    Nombre = reader.GetString("nombre")
                });
            }

            return grupos;
        }

        public int InsertGrupo(Grupo grupo)
        {
            using var connection = GetConnection();
            connection.Open();

            string query = "INSERT INTO grupo (nombre) VALUES (@nombre); SELECT LAST_INSERT_ID();";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", grupo.Nombre);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool UpdateGrupo(Grupo grupo)
        {
            using var connection = GetConnection();
            connection.Open();

            string query = "UPDATE grupo SET nombre=@nombre WHERE idgrupo=@id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", grupo.IdGrupo);
            command.Parameters.AddWithValue("@nombre", grupo.Nombre);

            return command.ExecuteNonQuery() > 0;
        }

        public bool DeleteGrupo(int id)
        {
            using var connection = GetConnection();
            connection.Open();

            string queryAlumnos = "UPDATE alumnado SET grupo=NULL WHERE grupo=@id";
            using var commandAlumnos = new MySqlCommand(queryAlumnos, connection);
            commandAlumnos.Parameters.AddWithValue("@id", id);
            commandAlumnos.ExecuteNonQuery();

            string query = "DELETE FROM grupo WHERE idgrupo=@id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;
        }

        public bool TestConnection()
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
