using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private int _IdCliente;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nac;
        private string _Tipo_Doc;
        private string _Num_Doc;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nac { get => _Fecha_Nac; set => _Fecha_Nac = value; }
        public string Tipo_Doc { get => _Tipo_Doc; set => _Tipo_Doc = value; }
        public string Num_Doc { get => _Num_Doc; set => _Num_Doc = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }



        public DCliente()
        {

        }

        public DCliente(int idcliente,string nombre,string apellidos,string sexo,DateTime fecha_nac,
            string tipo_doc,string num_doc,string direccion,string telefono,string email,string textobuscar)
        {
            this.IdCliente = idcliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nac = fecha_nac;
            this.Tipo_Doc = tipo_doc;
            this.Num_Doc = num_doc;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }


        public string Insertar(DCliente cliente)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCliente = new SqlParameter();
                parIdCliente.ParameterName = "@idcliente";
                parIdCliente.SqlDbType = SqlDbType.Int;
                parIdCliente.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdCliente);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = cliente.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 50;
                parApellidos.Value = cliente.Apellidos;
                cmd.Parameters.Add(parApellidos);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = cliente.Sexo;
                cmd.Parameters.Add(parSexo);


                SqlParameter parFecha_Nac = new SqlParameter();
                parFecha_Nac.ParameterName = "@fecha_nac";
                parFecha_Nac.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 50;
                parFecha_Nac.Value = cliente.Fecha_Nac;
                cmd.Parameters.Add(parFecha_Nac);

                SqlParameter parTipo_Doc = new SqlParameter();
                parTipo_Doc.ParameterName = "@tipo_doc";
                parTipo_Doc.SqlDbType = SqlDbType.VarChar;
                parTipo_Doc.Size = 20;
                parTipo_Doc.Value = cliente.Tipo_Doc;
                cmd.Parameters.Add(parTipo_Doc);

                SqlParameter parNum_Doc = new SqlParameter();
                parNum_Doc.ParameterName = "@num_doc";
                parNum_Doc.SqlDbType = SqlDbType.VarChar;
                parNum_Doc.Size = 20;
                parNum_Doc.Value = cliente.Num_Doc;
                cmd.Parameters.Add(parNum_Doc);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = cliente.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 11;
                parTelefono.Value = cliente.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = cliente.Email;
                cmd.Parameters.Add(parEmail);

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
        public string Modificar(DCliente cliente)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCliente = new SqlParameter();
                parIdCliente.ParameterName = "@idcliente";
                parIdCliente.SqlDbType = SqlDbType.Int;
                parIdCliente.Value = cliente.IdCliente;
                cmd.Parameters.Add(parIdCliente);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = cliente.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 50;
                parApellidos.Value = cliente.Apellidos;
                cmd.Parameters.Add(parApellidos);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = cliente.Sexo;
                cmd.Parameters.Add(parSexo);


                SqlParameter parFecha_Nac = new SqlParameter();
                parFecha_Nac.ParameterName = "@fecha_nac";
                parFecha_Nac.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 50;
                parFecha_Nac.Value = cliente.Fecha_Nac;
                cmd.Parameters.Add(parFecha_Nac);

                SqlParameter parTipo_Doc = new SqlParameter();
                parTipo_Doc.ParameterName = "@tipo_doc";
                parTipo_Doc.SqlDbType = SqlDbType.VarChar;
                parTipo_Doc.Size = 20;
                parTipo_Doc.Value = cliente.Tipo_Doc;
                cmd.Parameters.Add(parTipo_Doc);

                SqlParameter parNum_Doc = new SqlParameter();
                parNum_Doc.ParameterName = "@num_doc";
                parNum_Doc.SqlDbType = SqlDbType.VarChar;
                parNum_Doc.Size = 20;
                parNum_Doc.Value = cliente.Num_Doc;
                cmd.Parameters.Add(parNum_Doc);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = cliente.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 11;
                parTelefono.Value = cliente.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = cliente.Email;
                cmd.Parameters.Add(parEmail);



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
        public string Eliminar(DCliente cliente)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCliente = new SqlParameter();
                parIdCliente.ParameterName = "@idcliente";
                parIdCliente.SqlDbType = SqlDbType.Int;
                parIdCliente.Value = cliente.IdCliente;
                cmd.Parameters.Add(parIdCliente);


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

            DataTable DtResultado = new DataTable("tblCliente");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_CLIENTE";
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
        public DataTable ConsultarApellidos(DCliente cliente)
        {
            DataTable DtResultado = new DataTable("tblCliente");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_APELLIDOS_TABLA_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = cliente.TextoBuscar;
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



        public DataTable ConsultarDocumento(DCliente cliente)
        {
            DataTable DtResultado = new DataTable("tblCliente");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_DOCUMENTO_TABLA_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = cliente.TextoBuscar;
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
    }
}

