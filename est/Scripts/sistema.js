// Inicialización del módulo
var RegistroAcademicoApp = angular.module('Estadistica');

// Creación del controlador principal de la aplicación
RegistroAcademicoApp.controller('SistemaController', SistemaController);

// Definición del controlador del sistema
function SistemaController($http) {
    var vm = this;

    // Definicion de campos requeridos
    var DevocionalDominicalMV = [];
    var ActividadJuvenilMV = [];
    var CultoDeOracionMV = [];
    var EscuelaBiblicaMV = [];
    var PersonaMV = [];
    var VigiliaMV = [];


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
        fecha: "",
        salaCuna: 0
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
        fecha: ""
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
        fecha: ""
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
        fecha: ""
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
        fecha: ""
    };

    vm.Persona = {
        nombre:"",
        apellido:"",
        fechaNacimiento:"",
        dui:"",
        direccion:"",
        sector:"",
        estadoCivil:"1",
        miembro:"1",
        celular:"",
        telefono:"",
        ministerio:"1",
        profesionOficio:"",
        sexo: "1",
    };

    // Contenedores de datos para tablas
    //vm.Personas = [];
  

    vm.Datos = {
        Clave: "",
        Clave2: ""
    }

    // Funcionalidad para verificar si el usuario ha iniciado sesión
    //vm.ValidateSession = ValidateSession;

    // Funcionalidades para el popup de nuevo registro
    vm.Save = Save;

    //// Funcionalidad para eliminar un registro
    //vm.DeleteItem = DeleteItem;

    //// Cerrar sesión
    //vm.Logout = Logout;

    // Datos del usuario
    vm.Usuario = {
        NombreUsuario: ' Cargando... ',
        EsDocente: 0,
        EsAdministrador: 0,
        Reset: 0,
        IdDatos: 0
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

    // Valida si existe una sesion activa
    function ValidateSession() {
        $http.post('Actions/ValidateSession.aspx', {}, {
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
                location.href = 'login.aspx'
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

    //function CreateUser(view) {
    //    if (view == 'alumno') vm.DatosUsuario.EsDocente = 0; else vm.DatosUsuario.EsDocente = 1;
    //    if (VerificarCamposRequeridos(vm.DatosUsuario, UsuarioMV)) {
    //        $http.post('Actions/CrearUsuario.aspx', vm.DatosUsuario, {
    //            headers: {
    //                "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
    //            },
    //            transformRequest: [function (data) {
    //                return angular.isObject(data)
    //                    ? jQuery.param(data)
    //                    : data;
    //            }]
    //        }).then(function (response) {
    //            HidePopupUser();
    //            RestablecerVariables();
    //            vm.ObtenerAlumnos();
    //            if (response.data.success = true) {
    //                alert("Usuario creado con éxito, la clave de acceso fue enviada al correo del usuario");
    //            } else {
    //                alert("Ha ocurrido un error al crear el usuario");
    //            }
    //        });
    //    }
    //}


    // Finaliza la seccion actual
    //function Logout() {
    //    $http.post('Actions/CloseSession.aspx', {}, {
    //        headers: {
    //            "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
    //        },
    //        transformRequest: [function (data) {
    //            return angular.isObject(data)
    //                ? jQuery.param(data)
    //                : data;
    //        }]
    //    }).then(function (response) {
    //        location.href = 'login.aspx'
    //    });
    //}


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
                MV = EscuelaBiblicaMV;
                url = '/System/IngresarEscuela';
                break;
            case 'persona':
                // Asigna los datos correspondientes a filial
                Data = vm.Persona;
                MV = PersonaMV;
                url = '/System/IngresarPersona';
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
            fecha: "",
            salaCuna: 0
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
            fecha: ""
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
            fecha: ""
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
            clase: 0,
            maestros: 0,
            fecha: ""
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
            fecha: ""
        };

        vm.Persona = {
            nombre: "",
            apellido: "",
            fechaNacimiento: "",
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
    }

    //function Actualizar() {

    //    if (vm.Datos.Clave != vm.Datos.Clave2) {
    //        alert('Las claves no coinciden');
    //    } else {

    //        if (vm.Datos.Clave.length < 6) {
    //            alert('La clave debe tener al menos 6 caracteres');
    //        } else {
    //            $http.post('Actions/ActualizarUsuario.aspx', vm.Datos, {
    //                headers: {
    //                    "Content-Type": 'application/x-www-form-urlencoded;charset=utf-8'
    //                },
    //                transformRequest: [function (data) {
    //                    return angular.isObject(data)
    //                        ? jQuery.param(data)
    //                        : data;
    //                }]
    //            }).then(function (response) {
    //                if (response.data.success == true) {
    //                    alert('Clave actualizada con éxito');
    //                    location.href = 'index.aspx'
    //                } else {
    //                    alert('Ocurrió un error inesperado');
    //                }
    //            });
    //        }
    //    }
    //}
}