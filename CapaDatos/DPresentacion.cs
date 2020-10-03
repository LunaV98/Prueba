using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Data.Common;

namespace CapaDatos
{
    public class DPresentacion
    {
        private int _idPresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int idPresentacion { get => _idPresentacion; set => _idPresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DPresentacion()
        {

        }

        public DPresentacion(int idpresentacion, string nombre, string descripcion,string textobuscar)
        {
            this.idPresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }


        public string Insertar(DPresentacion dPresentacion)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_PRESENTACION";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdPresentacion);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = dPresentacion.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = dPresentacion.Descripcion;
                cmd.Parameters.Add(parDescripcion);

                rpta = cmd.ExecuteNonQuery() == 1? "OK" : "No se ingresó el registro";
                
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)  SqlCn.Close(); 
               
            }

            return rpta;


        }


        public string Modificar(DPresentacion dPresentacion)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_PRESENTACION";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = dPresentacion.idPresentacion;
                cmd.Parameters.Add(parIdPresentacion);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = dPresentacion.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = dPresentacion.Descripcion;
                cmd.Parameters.Add(parDescripcion);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se modificó el registro";

            }
            catch (Exception ex )
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

        public string Eliminar(DPresentacion dPresentacion)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_PRESENTACION";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = dPresentacion.idPresentacion;
                cmd.Parameters.Add(parIdPresentacion);

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

        
        public DataTable Consultar()
        {
            DataTable DtResultado = new DataTable("tblPresentacion");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_PRESENTACION";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public DataTable ConsultarNombre(DPresentacion dPresentacion)
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_NOMBRE_TABLA_PRESENTACION";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = dPresentacion.TextoBuscar;
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
