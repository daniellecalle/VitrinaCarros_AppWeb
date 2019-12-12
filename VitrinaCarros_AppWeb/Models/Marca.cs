using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VitrinaCarros_AppWeb.Models.Databases;

namespace VitrinaCarros_AppWeb.Models
{
    public class Marca
    {
        Database db = new Database();
        SQLHelpers sql = new SQLHelpers();

        #region "Constructores"

            public Marca() { }

        #endregion

        #region "Atributos/Propiedades"
            [Key]
            public int IdVehiculo { get; set; } 
            public string Nombre { get; set; }
           
        #endregion


    }
}