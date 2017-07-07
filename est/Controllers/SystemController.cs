using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Globalization;


namespace est.Controllers
{
    public class SystemController : Controller
    {

        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;

        // GET: System
        public ActionResult Inicio()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            return View();
        }

        public ActionResult ReporteGrafico()
        {

            if (Session["usuario"] == null)
            {
                ViewBag.Title = "Reporte estadistico";
                return View("ReporteGrafico2");

            }
            else
            {
                ViewBag.Title = "Reporte estadistico";

                return View();
            }



        }

        public void CerrarSesion()
        {
            Session["usuario"] = null;

            Response.Redirect("/Home/Index");
        }

        public ActionResult InicioReporte()
        {
            return View();
        }

        public ActionResult Censo()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Censo";

            return View();
        }

        public ActionResult CensoFoto()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Censo - Foto";

            return View();
        }

        public ActionResult CensoReporte()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Censo";

            return View();
        }

        public ActionResult DevocionalDominical()
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Devocional dominical";

            return View();
        }

        public ActionResult DevocionalDominicalReporte()
        {
            ViewBag.Title = "Devocional dominical";

            return View();
        }

        public ActionResult Vigilia()
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Vigilia";

            return View();
        }

        public ActionResult VigiliaReporte()
        {
            ViewBag.Title = "Vigilia";
            return View();

        }

        public ActionResult CultoDeOracion()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Culto de oración";

            return View();
        }

        public ActionResult CultoDeOracionReporte()
        {
            ViewBag.Title = "Culto de oración";

            return View();

        }

        public ActionResult ActividadJuvenil()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Actividad juvenil";

            return View();
        }

        public ActionResult ActividadJuvenilReporte()
        {

            ViewBag.Title = "Actividad juvenil";

            return View();
        }


        public ActionResult EscuelaBiblica()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            ViewBag.Title = "Escuela biblica";

            return View();
        }

        public ActionResult EscuelaBiblicaReporte()
        {

            ViewBag.Title = "Escuela biblica";
            return View();

        }

        public void UploadImg()
        {
            var File1 = Request.Files[0];

            if ((File1 != null) && (File1.ContentLength > 0))
            {
                string SaveLocation = Server.MapPath("~/Content/images") + "/p_" + Request["IdPersona"] + ".jpg";
                try
                {
                    File1.SaveAs(SaveLocation);
                    Response.Redirect("/System/CensoFoto");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }

        public string IngresarDevocional()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            DateTime fecha = DateTime.ParseExact(Request["fecha"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            int salaCuna = Int32.Parse(Request["salaCuna"]);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarDevocional(comentarios, adultosFueraDelTemplo, ujieres, adultosEnTemplo, jardinInfantil, primarios, principiantes, parvulos, responsable, fecha, salaCuna);

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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            DateTime fecha = DateTime.ParseExact(Request["fecha"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarCultoDeOracion(comentarios, personasFueraDelTemplo, ujieres, adultosEnTemplo, jovenesEnTemplo, adolescentesEnTemplo, maestros, ninosEnClase, ninosEnTemplo, fecha, responsable);

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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            DateTime fecha = DateTime.ParseExact(Request["fecha"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            DateTime fecha = DateTime.ParseExact(Request["fecha"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            int responsable = 2;
            int maestros = Int32.Parse(Request["maestros"]);
            DateTime fecha = DateTime.ParseExact(Request["fecha"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            var serializer = new JavaScriptSerializer();

            string nombre = Request["nombre"];
            string apellido = Request["apellido"];
            DateTime fechaNacimiento = DateTime.ParseExact(Request["fechaNacimiento"], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string dui = Request["dui"];
            string direccion = Request["direccion"];
            string sector = Request["sector"];
            int estadoCivil = Int32.Parse(Request["estadoCivil"]);
            int miembro = Int32.Parse(Request["miembro"]);
            string celular = Request["celular"];
            string telefono = Request["telefono"];
            string ministerio = Request["ministerio"];
            string profesionOficio = Request["profesionOficio"];
            int sexo = Int32.Parse(Request["sexo"]);

            int responsable = 2;
            int ids = 0;
            string msgs = "";
            bool resultado = false;

            try
            {
                EstadisticaDBDataContext db = new EstadisticaDBDataContext();

                var Results = db.IngresarPersona(responsable, nombre, apellido, fechaNacimiento, dui, direccion, sector, estadoCivil, miembro, celular, telefono, ministerio, profesionOficio, sexo);
                ids = Int32.Parse(Results.ToString());
                resultado = true;
            }
            catch (Exception ex)
            {
                msgs = ex.Message;
                resultado = false;
            }


            var JSON = new { success = resultado, id = ids , msg= msgs};

            string respuesta = serializer.Serialize(JSON);

            return respuesta;
        }

        public string ObtenerEstadoCivil()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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

        public string ObtenerProfesiones()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            string texto = Request["texto"];

            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerProfesiones(texto);

            List<object> Result = new List<object>();

            foreach (ObtenerProfesionesResult res in Results)
            {
                Result.Add(new
                {
                    display = res.ProfesionOficio,
                    value = res.ProfesionOficio
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerSectores()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

            string texto = Request["texto"];

            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ObtenerSectores(texto);

            List<object> Result = new List<object>();

            foreach (ObtenerSectoresResult res in Results)
            {
                Result.Add(new
                {
                    display = res.Sector,
                    value = res.Sector
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerMinisterio()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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

        public string ValidarUsuario()
        {

            var serializer = new JavaScriptSerializer();

            string Usuario = Request["Usuario"];
            string Clave = Request["Clave"];

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            var Results = db.ValidarUsuario(Usuario, Clave);

            List<object> Result = new List<object>();

            foreach (ValidarUsuarioResult res in Results)
            {
                Session["usuario"] = res.NombreUsuario;
            }

            if (Session["usuario"] != null)
            {
                Result.Add(new { Result = true });
            }
            else
            {
                Result.Add(new { Result = false });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerClase()
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Home/Index");
            }

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

        public string ReportePersona()
        {

            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            string Cadena = Request["Cadena"];

            var Results = db.ReportePersona(Cadena);

            List<object> Result = new List<object>();

            foreach (ReportePersonaResult res in Results)
            {
                Result.Add(new
                {
                    Nombre = res.Nombre
,
                    Apellido = res.Apellido
,
                    FechaNacimiento = res.FechaNacimiento
,
                    Dui = res.Dui
,
                    Direccion = res.Direccion
,
                    Sector = res.Sector
,
                    EstadoCivil = res.EstadoCivil
,
                    Miembro = res.Miembro
,
                    Celular = res.Celular
,
                    Telefono = res.Telefono
,
                    ProfesionOficio = res.ProfesionOficio
,
                    Sexo = res.Sexo
                });
            }

            string respuesta = serializer.Serialize(Result);

            return respuesta;
        }

        public string ObtenerReporte()
        {

            var serializer = new JavaScriptSerializer();

            EstadisticaDBDataContext db = new EstadisticaDBDataContext();

            string resultado = "";

            string fecha = Request["Fecha"];
            string tipoReporte = Request["tipoReporte"];

            switch (tipoReporte)
            {
                case "devocional":
                    var resultDevocional = db.ReporteDevocional(DateTime.ParseExact(fecha, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture));

                    List<object> Result = new List<object>();

                    foreach (ReporteDevocionalResult res in resultDevocional)
                    {
                        Result.Add(new
                        {
                            Comentarios = res.Comentarios
                            ,
                            AdultosFueraDelTemplo = res.AdultosFueraDelTemplo
                            ,
                            Ujieres = res.Ujieres
                            ,
                            AdultosEnTemplo = res.AdultosEnTemplo
                            ,
                            JardinInfantil = res.JardinInfantil
                            ,
                            Primarios = res.Primarios
                            ,
                            Principiantes = res.Principiantes
                            ,
                            Parvulos = res.Parvulos
                            ,
                            Responsable = res.Responsable
                            ,
                            Fecha = res.Fecha
                            ,
                            SalaCuna = res.SalaCuna
                            ,
                            id = res.id
                            ,
                            especial = res.especial
                        });
                    }

                    resultado = serializer.Serialize(Result);
                    break;

                case "vigilia":
                    var resultVigilia = db.ReporteVigilia(DateTime.Parse(fecha));

                    List<object> Result2 = new List<object>();

                    foreach (ReporteVigiliaResult res in resultVigilia)
                    {
                        Result2.Add(new
                        {
                            comentarios = res.Comentarios
                            ,
                            personasFueraDelTemplo = res.PersonasFueraDelTemplo
                            ,
                            ujieres = res.Ujieres
                            ,
                            adultosEnTemplo = res.AdultosEnTemplo
                            ,
                            jovenesEnTemplo = res.JovenesEnTemplo
                            ,
                            adolescentesEnTemplo = res.AdolescentesEnTemplo
                            ,
                            maestros = res.Maestros
                            ,
                            ninosEnClase = res.NinosEnClase
                            ,
                            ninosEnTemplo = res.NinosEnTemplo
                            ,
                            fecha = res.Fecha
                            ,
                            id = res.id
                            ,
                            esVigilia = res.EsVigilia
                            ,
                            cJovenes = res.cJovenes
                            ,
                            responsable = res.Responsable
                        });
                    }

                    resultado = serializer.Serialize(Result2);

                    break;

                case "cultoDeOracion":

                    var resultOracion = db.ReporteActividad(DateTime.Parse(fecha));

                    List<object> Result3 = new List<object>();

                    foreach (ReporteActividadResult res in resultOracion)
                    {
                        Result3.Add(new
                        {
                            comentarios = res.Comentarios
                            ,
                            personasFueraDelTemplo = res.PersonasFueraDelTemplo
                            ,
                            ujieres = res.Ujieres
                            ,
                            adultosEnTemplo = res.AdultosEnTemplo
                            ,
                            jovenesEnTemplo = res.JovenesEnTemplo
                            ,
                            adolescentesEnTemplo = res.AdolescentesEnTemplo
                            ,
                            maestros = res.Maestros
                            ,
                            ninosEnClase = res.NinosEnClase
                            ,
                            ninosEnTemplo = res.NinosEnTemplo
                            ,
                            fecha = res.Fecha
                            ,
                            id = res.id
                            ,
                            esVigilia = res.EsVigilia
                            ,
                            cJovenes = res.cJovenes
                            ,
                            responsable = res.Responsable
                        });
                    }

                    resultado = serializer.Serialize(Result3);



                    break;

                case "actividadEspecial":

                    var resultActividad = db.ReporteActividadEspecial(DateTime.Parse(fecha));

                    List<object> Result4 = new List<object>();

                    foreach (ReporteActividadEspecialResult res in resultActividad)
                    {
                        Result4.Add(new
                        {
                            Comentarios = res.Comentarios
                            ,
                            AdultosFueraDelTemplo = res.AdultosFueraDelTemplo
                            ,
                            Ujieres = res.Ujieres
                            ,
                            AdultosEnTemplo = res.AdultosEnTemplo
                            ,
                            JardinInfantil = res.JardinInfantil
                            ,
                            Primarios = res.Primarios
                            ,
                            Principiantes = res.Principiantes
                            ,
                            Parvulos = res.Parvulos
                            ,
                            Responsable = res.Responsable
                            ,
                            Fecha = res.Fecha
                            ,
                            SalaCuna = res.SalaCuna
                            ,
                            id = res.id
                            ,
                            especial = res.especial
                        });
                    }

                    resultado = serializer.Serialize(Result4);

                    break;

                case "cultoDeJovenes":
                    // var resultJovenes = db.Res
                    break;

                case "escuelaBiblica":

                    var resultEscuela = db.ReporteEscuela(DateTime.Parse(fecha));

                    List<object> Result5 = new List<object>();

                    foreach (ReporteEscuelaResult res in resultEscuela)
                    {
                        Result5.Add(new
                        {
                            Fecha = res.Fecha
                              ,
                            Total = res.Total
                              ,
                            Biblias = res.Biblias
                              ,
                            CapitulosLeidos = res.CapitulosLeidos
                              ,
                            Ofrenda = res.Ofrenda
                              ,
                            Diezmos = res.Diezmos
                              ,
                            Cumpleanos = res.Cumpleanos
                              ,
                            Presentes = res.Presentes
                              ,
                            Visitas = res.Visitas
                              ,
                            PersonasEvangelizadas = res.PersonasEvangelizadas
                              ,
                            Maestros = res.Maestros
                              ,
                            CultosFamiliares = res.CultosFamiliares
                              ,
                            VisitasHogares = res.VisitasHogares
                              ,
                            Responsable = res.Responsable
                              ,
                            Clase = res.Clase
                        });
                    }

                    resultado = serializer.Serialize(Result5);

                    break;
            }

            return resultado;

        }
    }
}