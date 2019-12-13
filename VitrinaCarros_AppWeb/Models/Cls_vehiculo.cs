using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VitrinaCarros_AppWeb.Models.Databases;
using System.Data.SqlClient;

namespace VitrinaCarros_AppWeb.Models
{
    public class Cls_vehiculo
    {

        cls_ConexionDB db = new cls_ConexionDB();

        SQLHelpers sql = new SQLHelpers();

        #region "Atributos"
            private int idVehiculo;
            private string modelo;
            private string fecha;
            private int anio;
            private double precio;
        #endregion

        #region "Propiedades"
        [Key]
            public int IdVehiculo { get; set; }

            public string Modelo { get; set; }
            
            public int Anio { get; set; }

            public double Precio { get; set; }

            //public byte[] Ruta { get; set; }
        #endregion

        #region "Contructores"

            public Cls_vehiculo()
            { }

            public Cls_vehiculo(string modelo, int anio, double precio)
            {
                this.Modelo =  modelo;
                this.Anio = anio;
                this.Precio = precio;
            }
        #endregion


        #region "Metodos Publicos"

        public void setIdVehiculo(int idVehiculo)
        {
            this.idVehiculo = idVehiculo;
        }

        public int getIdVehiculo() => this.idVehiculo;

        public void setModelo(string modelo)
        {
            this.modelo = modelo;
        }

        public string getModelo() => this.modelo;

        public int getAnio() => this.anio;

        public void setFecha(string fecha)
        {
            this.fecha = fecha; 
        }

        public string getFecha() => this.fecha; 


        public void setPrecio(double precio)
        {
            this.precio = precio;
        }

        public double getPrecio() => this.precio;


        public int DarAltaVehiculo()
        {
            try
            {
                db.Conectar();
            }
            catch
            {
                throw;
            }

            string query = "insert into tbl_vehiculo " +
                "values ('"+getModelo()+"', '"+getFecha()+"', "+getPrecio()+")";

            int fila = db.operaracion(query);
            
            return fila;
        }
         

        public List<Cls_vehiculo> ListarVehiculos()
        {
            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {              
                throw e;
            }
                    
            List<Cls_vehiculo> datosVehiculos = new List<Cls_vehiculo>();

            string query = "select int_id_vehiculo, modelo, year(fecha) as anio, precio from tbl_vehiculo";

            SqlDataReader d = db.Consulta(query);

   
            while (d.Read())
            {
                datosVehiculos.Add(new Cls_vehiculo()
                {
                    idVehiculo = Convert.ToInt32(d["int_id_vehiculo"]),
                    modelo = Convert.ToString(d["modelo"]),
                    anio = Convert.ToInt32(d["anio"]),
                    precio = Convert.ToDouble(d["precio"]),
                   
                });
            }

            return datosVehiculos;
        }

        public List<Cls_vehiculo> ListadoVehiculosXmodelo()
        {

            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {
                throw e;
            }

            List<Cls_vehiculo> datos = new List<Cls_vehiculo>();

            string query = "select int_id_vehiculo, modelo from tbl_vehiculo ";

            SqlDataReader d = db.Consulta(query);

            while (d.Read())
            {
                datos.Add(new Cls_vehiculo()
                {
                    idVehiculo = Convert.ToInt32(d["int_id_vehiculo"]),
                    modelo = Convert.ToString(d["modelo"]),

                });
            }

            return datos;
        }

        #endregion



    }
}