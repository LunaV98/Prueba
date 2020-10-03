using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CapaDatos
{
    public class DIngreso
    {

        private int _IdIngreso;
        private int _IdTrabajador;
        private int _IdProveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int IdIngreso { get => _IdIngreso; set => _IdIngreso = value; }
        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }


        public DIngreso()
        {


        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal igv,
            string estado)
        {

            this.IdIngreso = idingreso;
            this.IdTrabajador = idtrabajador;
            this.IdProveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;

        }


        public string Insertar(DIngreso dingreso, List<DDetalle_Ingreso> detalle)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlTransaction SqlTra = SqlCn.BeginTransaction();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.Transaction = SqlTra;
                cmd.CommandText = "SP_A_TABLA_INGRESO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdIngreso = new SqlParameter();
                parIdIngreso.ParameterName = "@idingreso";
                parIdIngreso.SqlDbType = SqlDbType.Int;
                parIdIngreso.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdIngreso);

                SqlParameter parIdTrabajador = new SqlParameter();
                parIdTrabajador.ParameterName = "@idtrabajador";
                parIdTrabajador.SqlDbType = SqlDbType.Int;
                parIdTrabajador.Value = dingreso.IdTrabajador;
                cmd.Parameters.Add(parIdTrabajador);

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Value = dingreso.IdProveedor;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.Date;
                parFecha.Value = dingreso.Fecha;
                cmd.Parameters.Add(parFecha);


                SqlParameter parTipo_Comprobante = new SqlParameter();
                parTipo_Comprobante.ParameterName = "@tipo_comprobante";
                parTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                parFecha.Size = 20;
                parTipo_Comprobante.Value = dingreso.Tipo_Comprobante;
                cmd.Parameters.Add(parTipo_Comprobante);

                SqlParameter parSerie = new SqlParameter();
                parSerie.ParameterName = "@serie";
                parSerie.SqlDbType = SqlDbType.VarChar;
                parSerie.Size = 4;
                parSerie.Value = dingreso.Serie;
                cmd.Parameters.Add(parSerie);

                SqlParameter parCorrelativo = new SqlParameter();
                parCorrelativo.ParameterName = "@correlativo";
                parCorrelativo.SqlDbType = SqlDbType.VarChar;
                parCorrelativo.Size = 7;
                parCorrelativo.Value = dingreso.Correlativo;
                cmd.Parameters.Add(parCorrelativo);

                SqlParameter parIgv = new SqlParameter();
                parIgv.ParameterName = "@igv";
                parIgv.SqlDbType = SqlDbType.Decimal;
                parIgv.Value = dingreso.Igv;
                cmd.Parameters.Add(parIgv);

                SqlParameter parEstado = new SqlParameter();
                parEstado.ParameterName = "@estado";
                parEstado.SqlDbType = SqlDbType.VarChar;
                parEstado.Size = 7;
                parEstado.Value = dingreso.Estado;
                cmd.Parameters.Add(parEstado);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";

                if (rpta.Equals("OK"))
                {
                    //obtener el código del ingreso generado
                    this.IdIngreso = Convert.ToInt32(cmd.Parameters["@idingreso"].Value);
                    foreach (DDetalle_Ingreso det in detalle)
                    {
                        det.IdIngreso = this.IdIngreso;
                        //llamar a insertar
                        rpta = det.Insertar(det, ref SqlCn, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }




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


        public string Anular(DIngreso ingreso)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_ANULAR_TABLA_INGRESO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdIngreso = new SqlParameter();
                parIdIngreso.ParameterName = "@idingreso";
                parIdIngreso.SqlDbType = SqlDbType.Int;
                parIdIngreso.Value = ingreso.IdIngreso;
                cmd.Parameters.Add(parIdIngreso);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se anuló el registro";
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

            DataTable DtResultado = new DataTable("tblIngreso");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_INGRESO";
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
        public DataTable ConsultarFechas(string TextoBuscar1, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("tblIngreso");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_FECHA_TABLA_INGRESO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar1 = new SqlParameter();
                parTextoBuscar1.ParameterName = "@textobuscar1";
                parTextoBuscar1.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar1.Size = 20;
                parTextoBuscar1.Value = TextoBuscar1;
                cmd.Parameters.Add(parTextoBuscar1);

                SqlParameter parTextoBuscar2 = new SqlParameter();
                parTextoBuscar2.ParameterName = "@textobuscar2";
                parTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar2.Size = 20;
                parTextoBuscar2.Value = TextoBuscar2;
                cmd.Parameters.Add(parTextoBuscar2);

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
