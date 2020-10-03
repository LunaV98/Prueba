using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DTrabajador
    {

        private int _idTrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nac;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        public int IdTrabajador { get => _idTrabajador; set => _idTrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nac { get => _Fecha_Nac; set => _Fecha_Nac = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DTrabajador()
        {

        }

        public DTrabajador(int idtrabajador, string nombre,string apellidos, string sexo, DateTime fecha_nac,
            string num_documento, string direccion, string telefono,string email, string acceso,
            string usuario, string password,string textobuscar
            )
        {
            this.IdTrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nac = fecha_nac;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DTrabajador trabajador)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_TRABAJOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paridTrabajador = new SqlParameter();
                paridTrabajador.ParameterName = "@idtrabajador";
                paridTrabajador.SqlDbType = SqlDbType.Int;
                paridTrabajador.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paridTrabajador);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = trabajador.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 50;
                parApellidos.Value = trabajador.Apellidos;
                cmd.Parameters.Add(parApellidos);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = trabajador.Sexo;
                cmd.Parameters.Add(parSexo);


                SqlParameter parFecha_Nac = new SqlParameter();
                parFecha_Nac.ParameterName = "@fecha_nac";
                parFecha_Nac.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 50;
                parFecha_Nac.Value = trabajador.Fecha_Nac;
                cmd.Parameters.Add(parFecha_Nac);

                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 8;
                parNum_documento.Value = trabajador.Num_Documento;
                cmd.Parameters.Add(parNum_documento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = trabajador.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = trabajador.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 100;
                parEmail.Value = trabajador.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parAcceso = new SqlParameter();
                parAcceso.ParameterName = "@acceso";
                parAcceso.SqlDbType = SqlDbType.VarChar;
                parAcceso.Size = 20;
                parAcceso.Value = trabajador.Acceso;
                cmd.Parameters.Add(parAcceso);

                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 20;
                parUsuario.Value = trabajador.Usuario;
                cmd.Parameters.Add(parUsuario);

                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 20;
                parPassword.Value = trabajador.Password;
                cmd.Parameters.Add(parPassword);



                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return rpta;
        }




        //MÉTODO MODIFICAR
        public string Modificar(DTrabajador trabajador)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdTrabajador = new SqlParameter();
                parIdTrabajador.ParameterName = "@idtrabajador";
                parIdTrabajador.SqlDbType = SqlDbType.Int;
                parIdTrabajador.Value = trabajador.IdTrabajador;
                cmd.Parameters.Add(parIdTrabajador);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = trabajador.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 50;
                parApellidos.Value = trabajador.Apellidos;
                cmd.Parameters.Add(parApellidos);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = trabajador.Sexo;
                cmd.Parameters.Add(parSexo);


                SqlParameter parFecha_Nac = new SqlParameter();
                parFecha_Nac.ParameterName = "@fecha_nac";
                parFecha_Nac.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 50;
                parFecha_Nac.Value = trabajador.Fecha_Nac;
                cmd.Parameters.Add(parFecha_Nac);

                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 8;
                parNum_documento.Value = trabajador.Num_Documento;
                cmd.Parameters.Add(parNum_documento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = trabajador.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = trabajador.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 100;
                parEmail.Value = trabajador.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parAcceso = new SqlParameter();
                parAcceso.ParameterName = "@acceso";
                parAcceso.SqlDbType = SqlDbType.VarChar;
                parAcceso.Size = 20;
                parAcceso.Value = trabajador.Acceso;
                cmd.Parameters.Add(parAcceso);

                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 20;
                parUsuario.Value = trabajador.Usuario;
                cmd.Parameters.Add(parUsuario);

                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 20;
                parPassword.Value = trabajador.Password;
                cmd.Parameters.Add(parPassword);




                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se modificó el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return rpta;
        }

        //MÉTODO ELIMINAR
        public string Eliminar(DTrabajador trabajador)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdTrabajador = new SqlParameter();
                parIdTrabajador.ParameterName = "@idtrabajador";
                parIdTrabajador.SqlDbType = SqlDbType.Int;
                parIdTrabajador.Value = trabajador.IdTrabajador;
                cmd.Parameters.Add(parIdTrabajador);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return rpta;

        }


        //MÉTODO CONSULTAR
        public DataTable Consultar()
        {

            DataTable DtResultado = new DataTable("tblTrabajador");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Dat = new SqlDataAdapter(cmd);
                Dat.Fill(DtResultado);

            }
            catch (Exception ex)
            {

                DtResultado = null;
            }

            return DtResultado;

        }

        //MÉTODO CONSULTAR POR NOMBRE
        public DataTable ConsultarApellidos(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("tblTrabajador");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_APELLIDOS_TABLA_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = trabajador.TextoBuscar;
                cmd.Parameters.Add(parTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;
        }



        public DataTable ConsultarDocumento(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("tblTrabajador");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_DOCUMENTO_TABLA_TRABAJADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = trabajador.TextoBuscar;
                cmd.Parameters.Add(parTextoBuscar);



                SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;
        }


        public DataTable Login(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("tblTrabajador");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_LOGIN";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 20;
                parUsuario.Value = trabajador.Usuario;
                cmd.Parameters.Add(parUsuario);


                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 20;
                parPassword.Value = trabajador.Password;
                cmd.Parameters.Add(parPassword);


                SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;
        }

    }
}
