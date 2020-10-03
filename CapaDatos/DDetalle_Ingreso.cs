using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        //Variables
        private int _idDetalle_Ingreso;
        private int _idIngreso;
        private int _idArticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;

        public int IdDetalle_Ingreso { get => _idDetalle_Ingreso; set => _idDetalle_Ingreso = value; }
        public int IdIngreso { get => _idIngreso; set => _idIngreso = value; }
        public int IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public decimal Precio_Compra { get => _Precio_Compra; set => _Precio_Compra = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public int Stock_Inicial { get => _Stock_Inicial; set => _Stock_Inicial = value; }
        public int Stock_Actual { get => _Stock_Actual; set => _Stock_Actual = value; }
        public DateTime Fecha_Produccion { get => _Fecha_Produccion; set => _Fecha_Produccion = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }


        public DDetalle_Ingreso()
        {

        }

        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo,decimal precio_compra,
            decimal precio_venta, int stock_inicial, int stock_actual,DateTime fecha_produccion, 
            DateTime fecha_vencimiento)
        {
            this.IdDetalle_Ingreso = iddetalle_ingreso;
            this.IdIngreso = idingreso;
            this.IdArticulo = idarticulo;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccion = fecha_produccion;
            this.Fecha_Vencimiento = fecha_vencimiento;

        }

        //MÉTODO INSERTAR
        public string Insertar(DDetalle_Ingreso detalle_ingreso, ref SqlConnection SqlCn, 
            ref SqlTransaction SqlTra)
        {
            string rpta = string.Empty;
            

            try
            {
                

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.Transaction = SqlTra;
                cmd.CommandText = "SP_A_TABLA_DETALLE_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdDetalle_Ingreso = new SqlParameter();
                parIdDetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                parIdDetalle_Ingreso.SqlDbType = SqlDbType.Int;
                parIdDetalle_Ingreso.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdDetalle_Ingreso);

                SqlParameter parIdIngreso = new SqlParameter();
                parIdIngreso.ParameterName = "@idingreso";
                parIdIngreso.SqlDbType = SqlDbType.Int;
                parIdIngreso.Value = detalle_ingreso.IdIngreso;
                cmd.Parameters.Add(parIdIngreso);

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = detalle_ingreso.IdArticulo;
                cmd.Parameters.Add(parIdArticulo);

                SqlParameter parPrecio_Compra = new SqlParameter();
                parPrecio_Compra.ParameterName = "@precio_compra";
                parPrecio_Compra.SqlDbType = SqlDbType.Money;
                parPrecio_Compra.Value = detalle_ingreso.Precio_Compra;
                cmd.Parameters.Add(parPrecio_Compra);


                SqlParameter parPrecio_Venta = new SqlParameter();
                parPrecio_Venta.ParameterName = "@precio_venta";
                parPrecio_Venta.SqlDbType = SqlDbType.Money;
                parPrecio_Venta.Value = detalle_ingreso.Precio_Venta;
                cmd.Parameters.Add(parPrecio_Venta);

                SqlParameter parStock_Inicial = new SqlParameter();
                parStock_Inicial.ParameterName = "@stock_inicial";
                parStock_Inicial.SqlDbType = SqlDbType.Int;
                parStock_Inicial.Value = detalle_ingreso.Stock_Inicial;
                cmd.Parameters.Add(parStock_Inicial);

                SqlParameter parStock_Actual = new SqlParameter();
                parStock_Actual.ParameterName = "@stock_actual";
                parStock_Actual.SqlDbType = SqlDbType.Int;
                parStock_Actual.Value = detalle_ingreso.Stock_Actual;
                cmd.Parameters.Add(parStock_Actual);

                SqlParameter parFecha_Produccion = new SqlParameter();
                parFecha_Produccion.ParameterName = "@fecha_produccion";
                parFecha_Produccion.SqlDbType = SqlDbType.Date;
                parFecha_Produccion.Value = detalle_ingreso.Fecha_Produccion;
                cmd.Parameters.Add(parFecha_Produccion);

                SqlParameter parFecha_Vencimiento = new SqlParameter();
                parFecha_Vencimiento.ParameterName = "@telefono";
                parFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                parFecha_Vencimiento.Value = detalle_ingreso.Fecha_Vencimiento;
                cmd.Parameters.Add(parFecha_Vencimiento);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            

            return rpta;
        }


    }
}
