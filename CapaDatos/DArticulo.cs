using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulo
    {
        private int _IdArticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _IdCategoria;
        private int _IdPresentacion;
        private string _TextoBuscar;

        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

       

        public DArticulo()
        {

        }

        public DArticulo(int idarticulo, string codigo, string nombre,string descripcion, byte[] imagen, int idcategoria,
            int idpresentacion,string textobuscar)
        {
            this.IdArticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.IdCategoria = idcategoria;
            this.IdPresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
        }

        public string Insertar(DArticulo articulo)
        {

           
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_ARTICULO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdArticulo);

                SqlParameter parCodigo = new SqlParameter();
                parCodigo.ParameterName = "@codigo";
                parCodigo.SqlDbType = SqlDbType.VarChar;
                parCodigo.Size = 50;
                parCodigo.Value = articulo.Codigo;
                cmd.Parameters.Add(parCodigo);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = articulo.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = articulo.Descripcion;
                cmd.Parameters.Add(parDescripcion);

                SqlParameter parImagen = new SqlParameter();
                parImagen.ParameterName = "@imagen";
                parImagen.SqlDbType = SqlDbType.Image;
                parImagen.Value = articulo.Imagen;
                cmd.Parameters.Add(parImagen);

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Value = articulo.IdCategoria;
                cmd.Parameters.Add(parIdCategoria);

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = articulo.IdPresentacion;
                cmd.Parameters.Add(parIdPresentacion);

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
        public string Modificar(DArticulo articulo)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_ARTICULO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = articulo.IdArticulo;
                cmd.Parameters.Add(parIdArticulo);

                SqlParameter parCodigo = new SqlParameter();
                parCodigo.ParameterName = "@codigo";
                parCodigo.SqlDbType = SqlDbType.VarChar;
                parCodigo.Size = 50;
                parCodigo.Value = articulo.Codigo;
                cmd.Parameters.Add(parCodigo);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = articulo.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = articulo.Descripcion;
                cmd.Parameters.Add(parDescripcion);

                SqlParameter parImagen = new SqlParameter();
                parImagen.ParameterName = "@imagen";
                parImagen.SqlDbType = SqlDbType.Image;
                parImagen.Value = articulo.Imagen;
                cmd.Parameters.Add(parImagen);

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Value = articulo.IdCategoria;
                cmd.Parameters.Add(parIdCategoria);

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = articulo.IdPresentacion;
                cmd.Parameters.Add(parIdPresentacion);



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
        public string Eliminar(DArticulo articulo)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_ARTICULO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = articulo.IdArticulo;
                cmd.Parameters.Add(parIdArticulo);


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

            DataTable DtResultado = new DataTable("tblArticulo");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_ARTICULO";
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
        public DataTable ConsultarNombre(DArticulo articulo)
        {
            DataTable DtResultado = new DataTable("tblArticulo");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_NOMBRE_TABLA_ARTICULO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = articulo.TextoBuscar;
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

