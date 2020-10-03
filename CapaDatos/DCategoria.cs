using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Data.Common;

namespace CapaDatos
{
    public class DCategoria
    {
        private int _idCategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }



        public DCategoria()
        {

        }

        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.IdCategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
            
        }

        //MÉTODO INSERTAR
        public string Insertar(DCategoria categoria)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_CATEGORIA";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdCategoria);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = categoria.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = categoria.Descripcion;
                cmd.Parameters.Add(parDescripcion);


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

        //MÉTODO CONSULTAR
        

        //MÉTODO MODIFICAR
        public string Modificar(DCategoria categoria)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_CATEGORIA";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Value = categoria.IdCategoria;
                cmd.Parameters.Add(parIdCategoria);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = categoria.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = categoria.Descripcion;
                cmd.Parameters.Add(parDescripcion);

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
        public string Eliminar(DCategoria categoria)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_CATEGORIA";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Value = categoria.IdCategoria;
                cmd.Parameters.Add(parIdCategoria);


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

            DataTable DtResultado = new DataTable("tblCategoria");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_CATEGORIA";
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
        public DataTable ConsultarNombre(DCategoria categoria)
        {
            DataTable DtResultado = new DataTable("tblCategoria");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_NOMBRE_TABLA_CATEGORIA"; 
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = categoria.TextoBuscar;
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
