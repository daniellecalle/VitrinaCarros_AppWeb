using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VitrinaCarros_AppWeb.Models;

namespace VitrinaCarros_AppWeb.Models.Databases
{
    public class SQLHelpers
    {

        Vehiculo objV = new Vehiculo();

        public string Sql_insertarVehiculo() => "INSERT INTO TBL_VEHICULO (MODELO, ANIO, PRECIO) "
                + "VALUES ('" + objV.Modelo + "', '" + objV.Anio + "', '" + objV.Precio + "')";

        public string Sql_actualizarVehiculo() => "";
       

        public string Sql_consultarVehiculos() => "SELECT * FROM TBL_VEHICULO";


        public string Sql_editarVehiculo() => "";
       

    }
}