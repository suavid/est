﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace est.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("/System/Inicio");
            }

            ViewBag.Title = "Iniciar sesión";

            return View();
        }

        public ActionResult Reportes()
        {

            ViewBag.Title = "Reportes";

            return View();
        }


        public string AsistenciaDevocional()
        {
            string respuesta = "";
            //*************************************************
            string pFechaInicio =  Request["FechaInicio"];
            string pFechaFin =  Request["FechaFin"];
            //****************************************************
            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            //************************
            DateTime FechaInicio = DateTime.Parse(pFechaInicio);
            DateTime FechaFin = DateTime.Parse(pFechaFin);
            //****************************

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {
                
                var fechas = db.AsistenciaDevocional_Fechas(FechaInicio, FechaFin);
                var cantidades = db.AsistenciaDevocional(FechaInicio, FechaFin);

                List<int> cantidadesList = new List<int>();
                List<string> fechasList = new List<string>();

                foreach (AsistenciaDevocionalResult cant in cantidades)
                {
                    cantidadesList.Add(Int32.Parse(cant.Cantidad.ToString()));
                }

                foreach (AsistenciaDevocional_FechasResult fec in fechas)
                {
                    fecha = (DateTime)fec.Fecha;
                    fechasList.Add(fecha.ToString(formato));
                }

                var JSON = new { fechas = fechasList, cantidades = cantidadesList };

                respuesta = serializer.Serialize(JSON);
            }
            
            return respuesta;
        }

        public string AsistenciaActividad()
        {
            string pFechaInicio = Request["FechaInicio"];
            string pFechaFin = Request["FechaFin"];

            string respuesta = "";

            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            DateTime FechaInicio = DateTime.Parse(pFechaInicio);
            DateTime FechaFin = DateTime.Parse(pFechaFin );

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {

                var fechas = db.AsistenciaActividad_Fechas(FechaInicio, FechaFin);
                var cantidades = db.AsistenciaActividad(FechaInicio, FechaFin);

                List<int> cantidadesList = new List<int>();
                List<string> fechasList = new List<string>();

                foreach (AsistenciaActividadResult cant in cantidades)
                {
                    cantidadesList.Add(Int32.Parse(cant.Cantidad.ToString()));
                }

                foreach (AsistenciaActividad_FechasResult fec in fechas)
                {
                    fecha = (DateTime)fec.Fecha;
                    fechasList.Add(fecha.ToString(formato));
                }

                var JSON = new { fechas = fechasList, cantidades = cantidadesList };

                respuesta = serializer.Serialize(JSON);
            }

            return respuesta;
        }

        public string AsistenciaVigilia()
        {
            string pFechaInicio = Request["FechaInicio"];
            string pFechaFin = Request["FechaFin"];

           
            string respuesta = "";

            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            DateTime FechaInicio = DateTime.Parse(pFechaInicio );
            DateTime FechaFin = DateTime.Parse(pFechaFin );

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {

                var fechas = db.AsistenciaVigilia_Fechas(FechaInicio, FechaFin);
                var cantidades = db.AsistenciaVigilia(FechaInicio, FechaFin);

                List<int> cantidadesList = new List<int>();
                List<string> fechasList = new List<string>();

                foreach (AsistenciaVigiliaResult cant in cantidades)
                {
                    cantidadesList.Add(Int32.Parse(cant.Cantidad.ToString()));
                }

                foreach (AsistenciaVigilia_FechasResult fec in fechas)
                {
                    fecha = (DateTime)fec.Fecha;
                    fechasList.Add(fecha.ToString(formato));
                }

                var JSON = new { fechas = fechasList, cantidades = cantidadesList };

                respuesta = serializer.Serialize(JSON);
            }

            return respuesta;
        }

        public string AsistenciaPromedioJovenes()
        {
            string pFechaInicio = Request["FechaInicio"];
            string pFechaFin = Request["FechaFin"];


            string respuesta = "";

            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            DateTime FechaInicio = DateTime.Parse(pFechaInicio);
            DateTime FechaFin = DateTime.Parse(pFechaFin);

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {

                var cantidades = db.AsistenciaPromedioJovenes(FechaInicio, FechaFin);

                List<int> cantidadesList = new List<int>();
                List<string> fechasList = new List<string>();

                foreach (AsistenciaPromedioJovenesResult cant in cantidades)
                {
                    cantidadesList.Add(Int32.Parse(cant.Cantidad.ToString()));
                }

                var JSON = new { cantidades = cantidadesList };

                respuesta = serializer.Serialize(JSON);
            }

            return respuesta;
        }

        public string AsistenciaEscuela()
        {
            string pFechaInicio = Request["FechaInicio"];
            string pFechaFin = Request["FechaFin"];

            string respuesta = "";

            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            DateTime FechaInicio = DateTime.Parse(pFechaInicio );
            DateTime FechaFin = DateTime.Parse(pFechaFin );

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {

                var fechas = db.AsistenciaEscuela_Fechas(FechaInicio, FechaFin);
                var cantidades = db.AsistenciaEscuela(FechaInicio, FechaFin);

                List<int> cantidadesList = new List<int>();
                List<string> fechasList = new List<string>();

                foreach (AsistenciaEscuelaResult cant in cantidades)
                {
                    cantidadesList.Add(Int32.Parse(cant.Total.ToString()));
                }

                foreach (AsistenciaEscuela_FechasResult fec in fechas)
                {
                    fecha = (DateTime)fec.Fecha;
                    fechasList.Add(fecha.ToString(formato));
                }

                var JSON = new { fechas = fechasList, cantidades = cantidadesList };

                respuesta = serializer.Serialize(JSON);
            }

            return respuesta;
        }

        public string AsistenciaPromedio()
        {
            string pFechaInicio = Request["FechaInicio"];
            string pFechaFin = Request["FechaFin"];

            string respuesta = "";

            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            DateTime FechaInicio = DateTime.Parse(pFechaInicio );
            DateTime FechaFin = DateTime.Parse(pFechaFin );

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {
                var cantidades = db.AsistenciaPromedio(FechaInicio, FechaFin);

                List<int> cantidadesList = new List<int>();

                foreach (AsistenciaPromedioResult cant in cantidades)
                {
                    if (cant.Cantidad != null) { 
                        cantidadesList.Add(Int32.Parse(cant.Cantidad.ToString()));
                    }
                }

                var JSON = new { cantidades = cantidadesList };

                respuesta = serializer.Serialize(JSON);
            }

            return respuesta;
        }

        public string PorcentajeSinRetirarse()
        {
            string pFechaInicio = Request["FechaInicio"];
            string pFechaFin = Request["FechaFin"];


            string respuesta = "";

            var serializer = new JavaScriptSerializer();
            string formato = "dd/MM/yyyy";

            DateTime fecha = new DateTime();

            DateTime FechaInicio = DateTime.Parse(pFechaInicio );
            DateTime FechaFin = DateTime.Parse(pFechaFin );

            using (EstadisticaDBDataContext db = new EstadisticaDBDataContext())
            {
                var cantidades = db.PorcentajeSinRetirarse(FechaInicio, FechaFin);

                List<object> cantidadesList = new List<object>();

                foreach (PorcentajeSinRetirarseResult cant in cantidades)
                {
                    cantidadesList.Add(new { y = cant.y, name = cant.name });
                }

                respuesta = serializer.Serialize(cantidadesList);
            }

            return respuesta;
        }

    }
}
