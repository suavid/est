// Inicialización del módulo
var RegistroAcademicoApp = angular.module('Estadistica');

// Creación del controlador principal de la aplicación
RegistroAcademicoApp.controller('SistemaController', SistemaController);

// Definición del controlador del sistema
function SistemaController($http, $mdDialog) {
    var vm = this;

    // Definicion de campos requeridos
    var DevocionalDominicalMV = [];
    var ActividadJuvenilMV = [];
    var CultoDeOracionMV = [];
    var EscuelaBiblicaMV = [];
    var PersonaMV = ["nombre", "apelido", "fechaNacimiento", "direccion", "sector"];
    var VigiliaMV = [];


    vm.Title = "Página de inicio";

    vm.searchText = "";
    vm.searchText2 = "";

    vm.FechaReporte = new Date();

    vm.Usuario = "";
    vm.Clave = "";
    vm.tipoReporte = "";
    vm.profesionOficioSeleccionado = null,
    vm.sectorSeleccionado = null;
    vm.ministeriosSeleccionados = null;

    window.onhashchange = function () {
        if (location.href.split("/").length > 1) {
            var parts = location.href.split("/");
            switch (parts[parts.length - 1]) {
                case "DevocionalDominical":
                    vm.Title = "Devocional dominical";
                    break;
            }
        }
    }

    if (location.href.split("/").length > 1) {
        var parts = location.href.split("/");
        switch (parts[parts.length - 1]) {
            case "DevocionalDominical":
                vm.Title = "Devocional dominical";
                break;
            case "DevocionalDominicalReporte":
                vm.Title = "Devocional dominical";
                break;
            case "CultoDeOracion":
                vm.Title = "Culto de oración";
                break;
            case "CultoDeOracionReporte":
                vm.Title = "Culto de oración";
                break;
            case "Vigilia":
                vm.Title = "Vigilia";
                break;
            case "VigiliaReporte":
                vm.Title = "Vigilia";
                break;
            case "ActividadJuvenil":
                vm.Title = "Centro juvenil";
                break;
            case "ActividadJuvenilReporte":
                vm.Title = "Centro juvenil";
                break;
            case "EscuelaBiblica":
                vm.Title = "Escuela bíblica";
                break;
            case "EscuelaBiblicaReporte":
                vm.Title = "Escuela bíblica";
                break;
            case "Censo":
                vm.Title = "Censo";
                break;
            case "CensoReporte":
                vm.Title = "Censo";
                break;
        }
    }

    vm.ArregloEscuela = [];
    vm.ArregloPersona = [];

    // Variables para formularios
    vm.DevocionalDominical = {
        comentarios:"",
        adultosFueraDelTemplo: 0,
        ujieres: 0,
        adultosEnTemplo: 0,
        jardinInfantil: 0,
        primarios: 0,
        principiantes: 0,
        parvulos: 0,
        fecha: new Date(),
        salaCuna: 0
    };

    vm.DevocionalDominicalReporte = {
        Comentarios: "",
        AdultosFueraDelTemplo: 0,
        Ujieres: 0,
        AdultosEnTemplo: 0,
        JardinInfantil: 0,
        Primarios: 0,
        Principiantes: 0,
        Parvulos: 0,
        Fecha: new Date(),
        SalaCuna: 0
    };

    vm.ActividadJuvenil = {
        comentarios:"",
        personasFueraDelTemplo:0,
        ujieres:0,
        adultosEnTemplo:0,
        jovenesEnTemplo:0,
        adolescentesEnTemplo:0,
        maestros:0,
        ninosEnClase:0,
        ninosEnTemplo:0,
        fecha: new Date()
    };
   
    vm.CultoDeOracion = {
        comentarios: "",
        personasFueraDelTemplo: 0,
        ujieres: 0,
        adultosEnTemplo: 0,
        jovenesEnTemplo: 0,
        adolescentesEnTemplo: 0,
        maestros: 0,
        ninosEnClase: 0,
        ninosEnTemplo: 0,
        fecha: new Date()
    };

    vm.EscuelaBiblica = {
        biblias:0,
        capitulosLeidos:0,
        ofrenda:0,
        diezmos:0,
        cumpleanos:0,
        presentes:0,
        visitas:0,
        personasEvangelizadas:0,
        cultosFamiliares:0,
        visitasHogares:0,
        clase:"1",
        maestros:0,
        fecha: new Date()
    };

    vm.Vigilia = {
        comentarios: "",
        personasFueraDelTemplo: 0,
        ujieres: 0,
        adultosEnTemplo: 0,
        jovenesEnTemplo: 0,
        adolescentesEnTemplo: 0,
        maestros: 0,
        ninosEnClase: 0,
        ninosEnTemplo: 0,
        fecha: new Date()
    };

    vm.Persona = {
        nombre:"",
        apellido:"",
        fechaNacimiento: new Date(),
        dui:"",
        direccion:"",
        sector:"",
        estadoCivil:"1",
        miembro:"1",
        celular:"",
        telefono:"",
        ministerio:"",
        profesionOficio:"",
        sexo: "1",
    };

    // Contenedores de datos para tablas
    //vm.Personas = [];
  

    vm.Datos = {
        Clave: "",
        Clave2: ""
    }

    vm.Cadena = "",

    // Funcionalidad para verificar si el usuario ha iniciado sesión
    //vm.ValidateSession = ValidateSession;

    // Funcionalidades para el popup de nuevo registro
    vm.Save = Save;
    vm.ValidarUsuario = ValidarUsuario;
    vm.ObtenerReporte = ObtenerReporte;
    vm.ReportePersona = ReportePersona;

    //// Funcionalidad para eliminar un registro
    //vm.DeleteItem = DeleteItem;

    //// Cerrar sesión
    //vm.Logout = Logout;

    // Datos del usuario

    vm.Redirect = Redirect;
 
    vm.selectedItemChange = selectedItemChange;
    vm.searchTextChange = searchTextChange;
    vm.selectedItemChange2 = selectedItemChange2;
    vm.searchTextChange2 = searchTextChange2;

    vm.ListadoProfesiones = [];
    vm.ListadoSectores = [];

    function searchTextChange(text) {
        $http.post('/System/ObtenerProfesiones', { texto: text }, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.ListadoProfesiones = response.data;
        });
    }

    function selectedItemChange(item) {
        
    }

    function searchTextChange2(text) {
        $http.post('/System/ObtenerSectores', { texto: text }, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.ListadoSectores = response.data;
        });
    }

    function selectedItemChange2(item) {

    }


    // Llamado a funciones de inicializacion

    // Valida la session cada minuto
    //setInterval(vm.ValidateSession, 60000);

    ObtenerEstadoCivil();
    ObtenerMembresia();
    ObtenerMinisterio();
    ObtenerSexo();
    ObtenerClase();

    // Definición de funciones //

    function Redirect(url) {
        location.href = url;
    }

  

    function ReportePersona() {
        $http.post('/System/ReportePersona', { Cadena: vm.Cadena }, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {

            vm.ArregloPersona = response.data;
        });
    }

    function ObtenerReporte(tipoReporte) {

        vm.tipoReporte = tipoReporte;

        $http.post('/System/ObtenerReporte', { fecha: moment(vm.FechaReporte).format('DD/MM/YYYY hh:mm:ss'), tipoReporte: tipoReporte }, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {

            switch (vm.tipoReporte) {
                case 'devocional':
                    vm.DevocionalDominicalReporte = response.data[0];
                    break;
                case 'escuelaBiblica':
                    vm.ArregloEscuela = response.data;
                    break;
                case 'cultoDeOracion':
                    vm.CultoDeOracion = response.data[0];
                    break;
                case 'vigilia':
                    vm.Vigilia = response.data[0];
            }
        });
    }

    function ObtenerEstadoCivil() {
        $http.post('/System/ObtenerEstadoCivil', {}, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.EstadoCivil = response.data;
        });
    }

    function ValidarUsuario() {
        $http.post('/System/ValidarUsuario', {Usuario: vm.Usuario, Clave: vm.Clave}, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            if (response.data[0].Result == true) {
                location.href = '/System/Inicio';
            } else {
                alert("Usuario o clave incorrectos");
            }
        });
    }

    function ObtenerMembresia() {
        $http.post('/System/ObtenerMembresia', {}, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.Membresia = response.data;
        });
    }

    function ObtenerMinisterio() {
        $http.post('/System/ObtenerMinisterio', {}, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.Ministerio = response.data;
        });
    }

    function ObtenerSexo() {
        $http.post('/System/ObtenerSexo', {}, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.Sexo = response.data;
        });
    }

    function ObtenerClase() {
        $http.post('/System/ObtenerClase', {}, {
            headers: {
                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
            },
            transformRequest: [function (data) {
                return angular.isObject(data)
                    ? jQuery.param(data)
                    : data;
            }]
        }).then(function (response) {
            vm.Clase = response.data;
        });
    }

    // Funcion para guardar datos
    function Save(view, action) {
        // Url a la que se enviaran los datos
        var url = '';
        // Datos que seran enviados al servidor
        var Data = {};
        // Campos requeridos para el formulario en cuestion
        var VM = [];

        // Las variables anteriores se llenan dependiendo de la vista que este siendo procesada
        switch (view) {
            case 'escuela':
                // Asigna los datos correspondientes a filial
                Data = vm.EscuelaBiblica;
                Data.fecha = moment(Data.fecha).format('DD/MM/YYYY hh:mm:ss')
                MV = EscuelaBiblicaMV;
                url = '/System/IngresarEscuela';
                break;
            case 'persona':
                // Asigna los datos correspondientes a filial
                Data = vm.Persona;
                Data.fechaNacimiento = moment(Data.fechaNacimiento).format('DD/MM/YYYY hh:mm:ss')
                Data.profesionOficio = (vm.profesionOficioSeleccionado != null) ? vm.profesionOficioSeleccionado.value : vm.searchText;
                Data.sector = (vm.sectorSeleccionado != null) ? vm.sectorSeleccionado.value : vm.searchText2;
                Data.ministerio = vm.ministeriosSeleccionados.join();
                MV = PersonaMV;
                url = '/System/IngresarPersona';
                break;
            case 'juvenil':
                Data = vm.ActividadJuvenil;
                Data.fecha = moment(Data.fecha).format('DD/MM/YYYY hh:mm:ss')
                MV = ActividadJuvenilMV;
                url = '/System/IngresarActividadJuvenil';
                break;
            case 'vigilia':
                Data = vm.Vigilia;
                Data.fecha = moment(Data.fecha).format('DD/MM/YYYY hh:mm:ss')
                MV= VigiliaMV;
                url = '/System/IngresarVigilia';
                break;
            case 'oracion':
                Data = vm.CultoDeOracion;
                Data.fecha = moment(Data.fecha).format('DD/MM/YYYY hh:mm:ss')
                MV = CultoDeOracionMV;
                url = '/System/IngresarCultoDeOracion';
                break;
            case 'devocional':
                Data = vm.DevocionalDominical;
                Data.fecha = moment(Data.fecha).format('DD/MM/YYYY hh:mm:ss')
                MV = DevocionalDominicalMV;
                url = '/System/IngresarDevocional'
                break;
        }       

        // Envia la peticion al servidor
        if (VerificarCamposRequeridos(Data, MV)) {
            $http.post(url, Data, {
                headers: {
                    "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
                },
                transformRequest: [function (data) {
                    return angular.isObject(data)
                        ? jQuery.param(data)
                        : data;
                }]
            }).then(function (response) {

                if (response.data.id) {
                    $mdDialog.show(
                      $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#popupContainer')))
                        .clickOutsideToClose(true)
                        .title('ID de persona')
                        .textContent('El ID de la persona es: ' + response.data.id)
                        .ariaLabel('ID Dialog')
                        .ok('Entendido!')
                        .targetEvent(null)
                    );
                }
                // Reestablece todas las variables
                RestablecerVariables(); 
            });
        } else {
            // Si la validacion de campos requeridos falla envia una alerta al usuario
            alert("Por favor complete todos los campos marcados con '*'");
        }
    }

    // Elimina un registro de una tabla
    function DeleteItem(view, data) {
        // Requiere confirmacion del usuario
        if (confirm("Esta seguro que desea eliminar/bloquear el registro?")) {
            // Variables necesarias para la eliminacion, dependeran de la vista utilizada
            // Url que atendiende la peticion de eliminacion
            var url = '';
            // Datos que seran enviados al servidor
            var JsData = {};
            // Se llenan los datos dependiendo de la vista
            switch (view) {
                case 'filial':
                    JsData = data;
                    url = '/System/IngresarEscuela';
                    break;
            }
            // Se realiza la peticion al servidor
            $http.post(url, JsData, {
                headers: {
                    "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
                },
                transformRequest: [function (data) {
                    return angular.isObject(data)
                        ? jQuery.param(data)
                        : data;
                }]
            }).then(function (response) {
                if (response.data.success == false) {
                    // Si el proceso devuelve falso no fue posible eliminar el registro por la relacion de las tablas
                    alert("No es posible eliminar el registro. Posee dependencias. ")
                }
                // Se ejecutan todas las funciones post proceso
                callback();
                RestablecerVariables();
            });
        }
    }

    // Funcion que verifica que los campos requeridos esten presentes
    function VerificarCamposRequeridos(Data, Campos) {
        for (x in Campos) {
            if (String(Data[Campos[x]]).trim() == "" || String(Data[Campos[x]]).trim() == "0") {
                return false;
            }
        }

        return true;
    }

    // Reestablece las variables contenedoras de datos
    function RestablecerVariables() {
        vm.DevocionalDominical = {
            comentarios: "",
            adultosFueraDelTemplo: 0,
            ujieres: 0,
            adultosEnTemplo: 0,
            jardinInfantil: 0,
            primarios: 0,
            principiantes: 0,
            parvulos: 0,
            fecha: new Date(),
            salaCuna: 0
        };

        vm.DevocionalDominicalReporte = {
            Comentarios: "",
            AdultosFueraDelTemplo: 0,
            Ujieres: 0,
            AdultosEnTemplo: 0,
            JardinInfantil: 0,
            Primarios: 0,
            Principiantes: 0,
            Parvulos: 0,
            Fecha: new Date(),
            SalaCuna: 0
        };

        vm.ActividadJuvenil = {
            comentarios: "",
            personasFueraDelTemplo: 0,
            ujieres: 0,
            adultosEnTemplo: 0,
            jovenesEnTemplo: 0,
            adolescentesEnTemplo: 0,
            maestros: 0,
            ninosEnClase: 0,
            ninosEnTemplo: 0,
            fecha: new Date()
        };

        vm.CultoDeOracion = {
            comentarios: "",
            personasFueraDelTemplo: 0,
            ujieres: 0,
            adultosEnTemplo: 0,
            jovenesEnTemplo: 0,
            adolescentesEnTemplo: 0,
            maestros: 0,
            ninosEnClase: 0,
            ninosEnTemplo: 0,
            fecha: new Date()
        };

        vm.EscuelaBiblica = {
            biblias: 0,
            capitulosLeidos: 0,
            ofrenda: 0,
            diezmos: 0,
            cumpleanos: 0,
            presentes: 0,
            visitas: 0,
            personasEvangelizadas: 0,
            cultosFamiliares: 0,
            visitasHogares: 0,
            clase: "1",
            maestros: 0,
            fecha: new Date()
        };

        vm.Vigilia = {
            comentarios: "",
            personasFueraDelTemplo: 0,
            ujieres: 0,
            adultosEnTemplo: 0,
            jovenesEnTemplo: 0,
            adolescentesEnTemplo: 0,
            maestros: 0,
            ninosEnClase: 0,
            ninosEnTemplo: 0,
            fecha: new Date()
        };

        vm.Persona = {
            nombre: "",
            apellido: "",
            fechaNacimiento: new Date(),
            dui: "",
            direccion: "",
            sector: "",
            estadoCivil: "1",
            miembro: "1",
            celular: "",
            telefono: "",
            ministerio: "1",
            profesionOficio: "",
            sexo: "1",
        };


        vm.searchText = "";
        vm.searchText2 = "";
        vm.ministeriosSeleccionados = null;
    }

}