using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace est.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Censo()
        {
            ViewBag.Title = "Censo";

            return View();
        }

        public ActionResult DevocionalDominical()
        {
            ViewBag.Title = "Devocional dominical";

            return View();
        }

        public ActionResult Vigilia()
        {
            ViewBag.Title = "Vigilia";

            return View();
        }

        public ActionResult CultoDeOracion()
        {
            ViewBag.Title = "Culto de oración";

            return View();
        }

        public ActionResult ActividadJuvenil()
        {
            ViewBag.Title = "Actividad juvenil";

            return View();
        }

        public ActionResult EscuelaBiblica()
        {
            ViewBag.Title = "Escuela biblica";

            return View();
        }

        public string IngresarDevocional()
        {
            var serializer = new JavaScriptSerializer();

            string comentarios = Request["comentarios"];
            int adultosFueraDelTemplo = Int32.Parse(Request["adultosFueraDelTemplo"]);
            int ujieres = Int32.Parse(Request["ujieres"]);
            int adultosEnTemplo = Int32.Parse(Request["adultosEnTemplo"]);
            int jardinInfantil = Int32.Parse(Request["jardinInfantil"]);
            int primarios = Int32.Parse(Request["primarios"]);
            int principiantes = Int32.Parse(Request["principiantes"]);
            int parvulos = Int32.Parse(Request["parvulos"]);
            int responsable = 2;
            DateTime fecha = DateTime.Parse(Request["fecha"]);
            int salaCuna = Int32.Parse(Request["salaCuna"]);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarDevocional(comentarios,adultosFueraDelTemplo,ujieres,adultosEnTemplo,jardinInfantil,primarios,principiantes,parvulos,responsable,fecha,salaCuna);
               
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            var JSON = new { success = resultado };

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string IngresarCultoDeOracion()
        {
            var serializer = new JavaScriptSerializer();

            string comentarios = Request["comentarios"];
            int personasFueraDelTemplo = Int32.Parse(Request["personasFueraDelTemplo"]);
            int ujieres = Int32.Parse(Request["ujieres"]);
            int adultosEnTemplo = Int32.Parse(Request["adultosEnTemplo"]);
            int jovenesEnTemplo = Int32.Parse(Request["jovenesEnTemplo"]);
            int adolescentesEnTemplo = Int32.Parse(Request["adolescentesEnTemplo"]);
            int responsable = 2;
            int maestros = Int32.Parse(Request["maestros"]);
            int ninosEnClase = Int32.Parse(Request["ninosEnClase"]);
            int ninosEnTemplo = Int32.Parse(Request["ninosEnTemplo"]);
            DateTime fecha = DateTime.Parse(Request["fecha"]);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarCultoDeOracion(comentarios,personasFueraDelTemplo,ujieres,adultosEnTemplo,jovenesEnTemplo,adolescentesEnTemplo,maestros,ninosEnClase,ninosEnTemplo,fecha,responsable);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            var JSON = new { success = resultado };

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string IngresarActividadJuvenil()
        {
            var serializer = new JavaScriptSerializer();

            string comentarios = Request["comentarios"];
            int personasFueraDelTemplo = Int32.Parse(Request["personasFueraDelTemplo"]);
            int ujieres = Int32.Parse(Request["ujieres"]);
            int adultosEnTemplo = Int32.Parse(Request["adultosEnTemplo"]);
            int jovenesEnTemplo = Int32.Parse(Request["jovenesEnTemplo"]);
            int adolescentesEnTemplo = Int32.Parse(Request["adolescentesEnTemplo"]);
            int responsable = 2;
            int maestros = Int32.Parse(Request["maestros"]);
            int ninosEnClase = Int32.Parse(Request["ninosEnClase"]);
            int ninosEnTemplo = Int32.Parse(Request["ninosEnTemplo"]);
            DateTime fecha = DateTime.Parse(Request["fecha"]);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarActividadJuvenil(comentarios, personasFueraDelTemplo, ujieres, adultosEnTemplo, jovenesEnTemplo, adolescentesEnTemplo, maestros, ninosEnClase, ninosEnTemplo, fecha, responsable);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            var JSON = new { success = resultado };

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string IngresarVigilia()
        {
            var serializer = new JavaScriptSerializer();

            string comentarios = Request["comentarios"];
            int personasFueraDelTemplo = Int32.Parse(Request["personasFueraDelTemplo"]);
            int ujieres = Int32.Parse(Request["ujieres"]);
            int adultosEnTemplo = Int32.Parse(Request["adultosEnTemplo"]);
            int jovenesEnTemplo = Int32.Parse(Request["jovenesEnTemplo"]);
            int adolescentesEnTemplo = Int32.Parse(Request["adolescentesEnTemplo"]);
            int responsable = 2;
            int maestros = Int32.Parse(Request["maestros"]);
            int ninosEnClase = Int32.Parse(Request["ninosEnClase"]);
            int ninosEnTemplo = Int32.Parse(Request["ninosEnTemplo"]);
            DateTime fecha = DateTime.Parse(Request["fecha"]);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarVigilia(comentarios, personasFueraDelTemplo, ujieres, adultosEnTemplo, jovenesEnTemplo, adolescentesEnTemplo, maestros, ninosEnClase, ninosEnTemplo, fecha, responsable);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            var JSON = new { success = resultado };

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string IngresarEscuela()
        {
            var serializer = new JavaScriptSerializer();

            int biblias = Int32.Parse(Request["biblias"]);
            int capitulosLeidos = Int32.Parse(Request["capitulosLeidos"]);
            int ofrenda = Int32.Parse(Request["ofrenda"]);
            int diezmos = Int32.Parse(Request["diezmos"]);
            int cumpleanos = Int32.Parse(Request["cumpleanos"]);
            int presentes = Int32.Parse(Request["presentes"]);
            int visitas = Int32.Parse(Request["visitas"]);
            int personasEvangelizadas = Int32.Parse(Request["personasEvangelizadas"]);
            int cultosFamiliares = Int32.Parse(Request["cultosFamiliares"]);
            int visitasHogares = Int32.Parse(Request["visitasHogares"]);
            int clase = Int32.Parse(Request["clase"]);
            int responsable =2;
            int maestros = Int32.Parse(Request["maestros"]);
            DateTime fecha = DateTime.Parse(Request["fecha"]);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarEscuela(fecha, biblias, capitulosLeidos, ofrenda, diezmos, cumpleanos, presentes, visitas, personasEvangelizadas, maestros, cultosFamiliares, visitasHogares, responsable, clase);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            var JSON = new { success = resultado };

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string IngresarPersona()
        {
            var serializer = new JavaScriptSerializer();

            string nombre = Request["nombre"];
            string apellido = Request["apellido"];
            DateTime fechaNacimiento = DateTime.Parse(Request["fechaNacimiento"]);
            string dui = Request["dui"];
            string direccion = Request["direccion"];
            string sector = Request["sector"];
            int estadoCivil = Int32.Parse(Request["estadoCivil"]);
            int miembro = Int32.Parse(Request["miembro"]);
            string celular = Request["celular"];
            string telefono = Request["telefono"];
            int ministerio = Int32.Parse(Request["ministerio"]);
            string profesionOficio = Request["profesionOficio"];
            int sexo = Int32.Parse(Request["sexo"]);
         
            int responsable = 2;

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarPersona(responsable, nombre, apellido, fechaNacimiento, dui, direccion, sector, estadoCivil, miembro, celular, telefono, ministerio, profesionOficio, sexo);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            var JSON = new { success = resultado };

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string ObtenerEstadoCivil()
        {
            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerEstadoCivil();

            List<object> Result = new List<object>();

            foreach (ObtenerEstadoCivilResult res in Results)
            {
                Result.Add(new
                {
                    id = res.IdEstadoCivil,
                    descripcion = res.Descripcion
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerMembresia()
        {
            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerMembresia();

            List<object> Result = new List<object>();

            foreach (ObtenerMembresiaResult res in Results)
            {
                Result.Add(new
                {
                    id = res.IdMembresia,
                    descripcion = res.Descripcion
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerMinisterio()
        {
            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerMinisterio();

            List<object> Result = new List<object>();

            foreach (ObtenerMinisterioResult res in Results)
            {
                Result.Add(new
                {
                    id = res.IdMinisterio,
                    descripcion = res.Nombre
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerSexo()
        {
            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerSexo();

            List<object> Result = new List<object>();

            foreach (ObtenerSexoResult res in Results)
            {
                Result.Add(new
                {
                    id = res.IdSexo,
                    descripcion = res.Descripcion
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerClase()
        {
            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerClase();

            List<object> Result = new List<object>();

            foreach (ObtenerClaseResult res in Results)
            {
                Result.Add(new
                {
                    id = res.IdClase,
                    descripcion = res.Nombre
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }
    }
}