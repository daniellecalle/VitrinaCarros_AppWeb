using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using VitrinaCarros_AppWeb.Models.Databases;

namespace VitrinaCarros_AppWeb.Models
{
    public class Vehiculo
    {

        Database db = new Database();
        SqlConnection a;
        SQLHelpers sql = new SQLHelpers();

        #region "Atributos/Propiedades"
            [Key]
            public int IdVehiculo { get; set; }

            public string Modelo { get; set; }
            
            public int Anio { get; set; }

            public double Precio { get; set; }

            //public byte[] Ruta { get; set; }
        #endregion

        #region "Contructores"

            public Vehiculo()
            { }

            public Vehiculo(int id_vehiculo, string modelo, int anio, double precio)
            {
                this.IdVehiculo = id_vehiculo;
                this.Modelo =  modelo;
                this.Anio = anio;
                this.Precio = precio;
            }
        #endregion


        #region "Metodos Publicos"

        public int DarAltaVehiculo()
        {
            try
            {
                a = db.Conectar();
            }
            catch
            {
                throw;
            }

            int fila = db.operaracion(sql.Sql_insertarVehiculo(), a);
            
            return fila;
        }


        public bool ValidarCampos()
        {
            return (!String.IsNullOrEmpty(Modelo));
        }


        public List<Vehiculo> ListarVehiculos()
        {
            try
            {
                a = db.Conectar();
            }
            catch (Exception)
            {
                throw;
            }
           

            List<Vehiculo> datos = new List<Vehiculo>();

            SqlDataReader d = db.Consulta(sql.Sql_consultarVehiculos(), a);

            while (d.Read())
            {
                datos.Add(new Vehiculo()
                {
                    IdVehiculo = Convert.ToInt32(d["ID_VEHICULO"]),
                    Modelo = Convert.ToString(d["MODELO"]),
                    Anio = Convert.ToInt32(d["ANIO"]),
                    Precio = Convert.ToDouble(d["PRECIO"]),
                   
                });
            }

            return datos;
        }
        #endregion



    }
}