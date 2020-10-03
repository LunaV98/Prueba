using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {

        private int _idProveedor;
        private string _Razon_Social;
        private string _Sector_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

        public int IdProveedor { get => _idProveedor; set => _idProveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }



        public DProveedor()
        {

        }


        public DProveedor(int idproveedor,string razon_social,string sector_comercial,
            string tipo_documento, string num_documento,
            string direccion,string telefono,string email,string url,string textobuscar)
        {
            this.IdProveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = telefono;
        }

        public string Insertar(DProveedor proveedor)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parRazon_Social = new SqlParameter();
                parRazon_Social.ParameterName = "@razon_social";
                parRazon_Social.SqlDbType = SqlDbType.VarChar;
                parRazon_Social.Size = 100;
                parRazon_Social.Value = proveedor.Razon_Social;
                cmd.Parameters.Add(parRazon_Social);

                SqlParameter parSector_Comercial = new SqlParameter();
                parSector_Comercial.ParameterName = "@sector_comercial";
                parSector_Comercial.SqlDbType = SqlDbType.VarChar;
                parSector_Comercial.Size = 25;
                parSector_Comercial.Value = proveedor.Sector_Comercial;
                cmd.Parameters.Add(parSector_Comercial);

                SqlParameter parTipo_Documento = new SqlParameter();
                parTipo_Documento.ParameterName = "@tipo_documento";
                parTipo_Documento.SqlDbType = SqlDbType.VarChar;
                parTipo_Documento.Size = 25;
                parTipo_Documento.Value = proveedor.Tipo_Documento;
                cmd.Parameters.Add(parTipo_Documento);

                SqlParameter parNum_Doc = new SqlParameter();
                parNum_Doc.ParameterName = "@num_documento";
                parNum_Doc.SqlDbType = SqlDbType.VarChar;
                parNum_Doc.Size = 25;
                parNum_Doc.Value = proveedor.Num_Documento;
                cmd.Parameters.Add(parNum_Doc);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = proveedor.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = proveedor.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 100;
                parEmail.Value = proveedor.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parUrl = new SqlParameter();
                parUrl.ParameterName = "@url";
                parUrl.SqlDbType = SqlDbType.VarChar;
                parTipo_Documento.Size = 50;
                parUrl.Value = proveedor.Url;
                cmd.Parameters.Add(parUrl);



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
        public string Modificar(DProveedor proveedor)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Value = proveedor.IdProveedor;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parRazon_Social = new SqlParameter();
                parRazon_Social.ParameterName = "@razon_social";
                parRazon_Social.SqlDbType = SqlDbType.VarChar;
                parRazon_Social.Size = 100;
                parRazon_Social.Value = proveedor.Razon_Social;
                cmd.Parameters.Add(parRazon_Social);

                SqlParameter parSector_Comercial = new SqlParameter();
                parSector_Comercial.ParameterName = "@sector_comercial";
                parSector_Comercial.SqlDbType = SqlDbType.VarChar;
                parSector_Comercial.Size = 25;
                parSector_Comercial.Value = proveedor.Sector_Comercial;
                cmd.Parameters.Add(parSector_Comercial);

                SqlParameter parTipo_Documento = new SqlParameter();
                parTipo_Documento.ParameterName = "@tipo_documento";
                parTipo_Documento.SqlDbType = SqlDbType.VarChar;
                parTipo_Documento.Size = 25;
                parTipo_Documento.Value = proveedor.Tipo_Documento;
                cmd.Parameters.Add(parTipo_Documento);

                SqlParameter parNum_Doc = new SqlParameter();
                parNum_Doc.ParameterName = "@num_documento";
                parNum_Doc.SqlDbType = SqlDbType.VarChar;
                parNum_Doc.Size = 25;
                parNum_Doc.Value = proveedor.Num_Documento;
                cmd.Parameters.Add(parNum_Doc);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = proveedor.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = proveedor.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 100;
                parEmail.Value = proveedor.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parUrl = new SqlParameter();
                parUrl.ParameterName = "@url";
                parUrl.SqlDbType = SqlDbType.VarChar;
                parTipo_Documento.Size = 50;
                parUrl.Value = proveedor.Url;
                cmd.Parameters.Add(parUrl);



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
        public string Eliminar(DProveedor proveedor)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Value = proveedor.IdProveedor;
                cmd.Parameters.Add(parIdProveedor);


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

            DataTable DtResultado = new DataTable("tblProveedor");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_PROVEEDOR";
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
        public DataTable ConsultarRazonSocial(DProveedor proveedor)
        {
            DataTable DtResultado = new DataTable("tblProveedor");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_NOMBRE_TABLA_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = proveedor.TextoBuscar;
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



        public DataTable ConsultarDocumento(DProveedor proveedor)
        {
            DataTable DtResultado = new DataTable("tblProveedor");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_DOCUMENTO_TABLA_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textoBuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 25;
                parTextoBuscar.Value = proveedor.TextoBuscar;
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
