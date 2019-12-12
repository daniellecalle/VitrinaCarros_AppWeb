using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VitrinaCarros_AppWeb.Models;

namespace VitrinaCarros_AppWeb.Controllers
{
    
    public class VehiculoController : Controller
    {

        Vehiculo objv = new Vehiculo();
        
        public ActionResult formRegistroVehiculos()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult crearVehiculos()
        {
       
            objv.Modelo = Convert.ToString(Request["txtModelo"]);
            objv.Precio = Convert.ToDouble(Request["precio"]);
            objv.Anio = Convert.ToInt32(Request["txtAnio"]);

            //String ruta = Convert.ToString(Request["txtRuta"]);
            // byte[] data = System.IO.File.ReadAllBytes(ruta);
            //objv.Ruta = null;

            if (!String.IsNullOrEmpty(Request["txtModelo"]) || !String.IsNullOrEmpty(Request["anio"])
                    || !String.IsNullOrEmpty(Request["precio"]))
            {
                return View("formRegistroVehiculos");
            }
            else
            {
                if (objv.DarAltaVehiculo() != 0)
                {
                    //List<Vehiculo> objListaVehiculos = objv.ListarVehiculos();
                    //ViewData["listaVehiculos"] = objListaVehiculos;
                    //ViewBag.Mensaje = "Datos Guardos Correctamente";
                    return View("formRegistroVehiculos");
                }
                else
                {
                    return View("formRegistroVehiculos");
                }
            }
        }

        public ActionResult formRegistroMarca() 
        {
            objv = new Vehiculo();

            

            return View();
        }
    }
}