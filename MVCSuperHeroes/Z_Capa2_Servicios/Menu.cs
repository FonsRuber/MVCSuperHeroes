using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe;
using MVCSuperHeroes.Z_Capa2_Servicios.Persistance;

namespace MVCSuperHeroes.Z_Capa2_Servicios
{
    public class Menu
    {

        public string GuardarImagenDeSuperHeroe(HttpPostedFileBase DatosImagen, string nombrePersonaje)
        {
            string FileExtension = Path.GetExtension(DatosImagen.FileName);
            string FileNameAndExtension = nombrePersonaje + FileExtension;
            string imagepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/Images", FileNameAndExtension);
            DatosImagen.SaveAs(imagepath);
            return FileNameAndExtension;
        }
        #region Menu Sanitarios
        public bool AnnadirSanitario(SanitarioDTO sanitarioAAnnadir)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                obd.InsertarNuevoSanitario(sanitarioAAnnadir);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public SanitarioDTO DevolverSanitario(long id)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                return obd.GetSanitarioPorId(id);
            }
            catch (Exception e)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
        }

        public bool ModificarSanitario(SanitarioDTO sanitarioAModificar)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                obd.ModificarSanitarioEnBD(sanitarioAModificar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BorrarSanitario(long IdABorrar)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                obd.BorraSuperHeroeEnBDById(IdABorrar);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SanitarioDTO> DevolverTodosLosSanitarios()
        {
            OperacionesBD obd = new OperacionesBD();
            return obd.GetListaSanitariosDesdeBD();
        }

        public List<SanitarioDTO> DevolverSanitariosQuePuedenCurar(string nombre)
        {
            OperacionesBD obd = new OperacionesBD();
            return obd.GetSanitariosQuePuedenCurar(nombre);
        }


        #endregion
        #region Menu Bomberos
        public bool AnnadirBombero(BomberoDTO bomberoAAnnadir)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                obd.InsertarNuevoBombero(bomberoAAnnadir);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public BomberoDTO DevolverBombero(long id)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                return obd.GetBomberoPorId(id);
            }
            catch (Exception e)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
        }

        public bool ModificarBombero(BomberoDTO bomberoAModificar)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                obd.ModificarBomberoEnBD(bomberoAModificar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BorrarBombero(long IdABorrar)
        {
            OperacionesBD obd = new OperacionesBD();
            try
            {
                obd.BorraSuperHeroeEnBDById(IdABorrar);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<BomberoDTO> DevolverTodosLosBomberos()
        {
            OperacionesBD obd = new OperacionesBD();
            return obd.GetListaBomberosDesdeBD();
        }

        public List<BomberoDTO> DevolverBomberosQuePuedenApagarFuego(string nombre)
        {
            OperacionesBD obd = new OperacionesBD();
            return obd.GetBomberosQuePuedenApagarFuego(nombre);
        }
        #endregion

        //public List<SuperHeroeDTO> ListaSuperHeroeDTO { get; set; }
        ////public List<SuperHeroe> ListaSuperHeroeBD { get; set; }
        ////public SuperHeroesDBEntities accesoABDSuperHeroe { get; set; }
        //public bool terminar { get; set; }
        //public bool terminarMenuProfesionerHeroicas { get; set; }
        //public bool terminarMenuSuperHumanos { get; set; }
        //public string OpcionSeleccionada { get; set; }

        //public void Ejecutar()
        //{
        //    CrearDatosInicialesDesdeDB();
        //    terminar = false;
        //    do
        //    {
        //        MenuPrincipal();
        //        SeleccionMenuPrincipal();
        //        Console.Clear();
        //    } while (terminar == false);
        //}


        //public void CrearDatosInicialesDesdeDB()
        //{
        //    ListaSuperHeroeDTO = new List<SuperHeroeDTO>();

        //    SuperHeroesDBEntities accesoABD_DTO = new SuperHeroesDBEntities();
        //    List<Sanitario> listaSanitarioBD_DTO = accesoABD_DTO.Sanitario.ToList();
        //    List<Bombero> listaBomberoBD_DTO = accesoABD_DTO.Bombero.ToList();
        //    List<Marvel> listaMarvelBD_DTO = accesoABD_DTO.Marvel.ToList();
        //    List<DC> listaDCBD_DTO = accesoABD_DTO.DC.ToList();


        //    foreach (Sanitario elemento in listaSanitarioBD_DTO)
        //    {
        //        SanitarioDTO sanitarioBD_DTO = new SanitarioDTO();
        //        sanitarioBD_DTO.idSuperHeroe = elemento.ProfesionesHeroicas.SuperHeroe.Id;
        //        sanitarioBD_DTO.dni = elemento.ProfesionesHeroicas.SuperHeroe.DNI;
        //        sanitarioBD_DTO.nombre = elemento.ProfesionesHeroicas.SuperHeroe.Nombre;
        //        sanitarioBD_DTO.apellidos = elemento.ProfesionesHeroicas.SuperHeroe.Apellidos;
        //        sanitarioBD_DTO.edad = elemento.ProfesionesHeroicas.SuperHeroe.Edad;
        //        sanitarioBD_DTO.peso = elemento.ProfesionesHeroicas.SuperHeroe.Peso;
        //        sanitarioBD_DTO.altura = elemento.ProfesionesHeroicas.SuperHeroe.Altura;
        //        sanitarioBD_DTO.superPoder = elemento.ProfesionesHeroicas.SuperHeroe.SuperPoder;
        //        sanitarioBD_DTO.valor = elemento.ProfesionesHeroicas.Valor;
        //        sanitarioBD_DTO.salario = elemento.ProfesionesHeroicas.Salario;
        //        sanitarioBD_DTO.curar = elemento.Curar;
        //        ListaSuperHeroeDTO.Add(sanitarioBD_DTO);
        //    }
        //    foreach (Bombero elemento in listaBomberoBD_DTO)
        //    {
        //        BomberoDTO bomberoBD_DTO = new BomberoDTO();
        //        bomberoBD_DTO.idSuperHeroe = elemento.ProfesionesHeroicas.SuperHeroe.Id;
        //        bomberoBD_DTO.dni = elemento.ProfesionesHeroicas.SuperHeroe.DNI;
        //        bomberoBD_DTO.nombre = elemento.ProfesionesHeroicas.SuperHeroe.Nombre;
        //        bomberoBD_DTO.apellidos = elemento.ProfesionesHeroicas.SuperHeroe.Apellidos;
        //        bomberoBD_DTO.edad = elemento.ProfesionesHeroicas.SuperHeroe.Edad;
        //        bomberoBD_DTO.peso = elemento.ProfesionesHeroicas.SuperHeroe.Peso;
        //        bomberoBD_DTO.altura = elemento.ProfesionesHeroicas.SuperHeroe.Altura;
        //        bomberoBD_DTO.superPoder = elemento.ProfesionesHeroicas.SuperHeroe.SuperPoder;
        //        bomberoBD_DTO.valor = elemento.ProfesionesHeroicas.Valor;
        //        bomberoBD_DTO.salario = elemento.ProfesionesHeroicas.Salario;
        //        bomberoBD_DTO.apagarFuego = elemento.ApagarFuego;
        //        ListaSuperHeroeDTO.Add(bomberoBD_DTO);
        //    }
        //    foreach (Marvel elemento in listaMarvelBD_DTO)
        //    {
        //        MarvelDTO marvelBD_DTO = new MarvelDTO();
        //        marvelBD_DTO.idSuperHeroe = elemento.SuperHumanos.SuperHeroe.Id;
        //        marvelBD_DTO.dni = elemento.SuperHumanos.SuperHeroe.DNI;
        //        marvelBD_DTO.nombre = elemento.SuperHumanos.SuperHeroe.Nombre;
        //        marvelBD_DTO.apellidos = elemento.SuperHumanos.SuperHeroe.Apellidos;
        //        marvelBD_DTO.edad = elemento.SuperHumanos.SuperHeroe.Edad;
        //        marvelBD_DTO.peso = elemento.SuperHumanos.SuperHeroe.Peso;
        //        marvelBD_DTO.altura = elemento.SuperHumanos.SuperHeroe.Altura;
        //        marvelBD_DTO.superPoder = elemento.SuperHumanos.SuperHeroe.SuperPoder;
        //        marvelBD_DTO.volar = elemento.SuperHumanos.Volar;
        //        marvelBD_DTO.superFuerza = elemento.SuperHumanos.SuperFuerza;
        //        marvelBD_DTO.vengadores = elemento.Vengadores;
        //        ListaSuperHeroeDTO.Add(marvelBD_DTO);
        //    }
        //    foreach (DC elemento in listaDCBD_DTO)
        //    {
        //        DCDTO DCBD_DTO = new DCDTO();
        //        DCBD_DTO.idSuperHeroe = elemento.SuperHumanos.SuperHeroe.Id;
        //        DCBD_DTO.dni = elemento.SuperHumanos.SuperHeroe.DNI;
        //        DCBD_DTO.nombre = elemento.SuperHumanos.SuperHeroe.Nombre;
        //        DCBD_DTO.apellidos = elemento.SuperHumanos.SuperHeroe.Apellidos;
        //        DCBD_DTO.edad = elemento.SuperHumanos.SuperHeroe.Edad;
        //        DCBD_DTO.peso = elemento.SuperHumanos.SuperHeroe.Peso;
        //        DCBD_DTO.altura = elemento.SuperHumanos.SuperHeroe.Altura;
        //        DCBD_DTO.superPoder = elemento.SuperHumanos.SuperHeroe.SuperPoder;
        //        DCBD_DTO.volar = elemento.SuperHumanos.Volar;
        //        DCBD_DTO.superFuerza = elemento.SuperHumanos.SuperFuerza;
        //        DCBD_DTO.ligaDeLaJusticia = elemento.LigaDeLaJusticia;
        //        ListaSuperHeroeDTO.Add(DCBD_DTO);
        //    }





        //    //PRobatina
        //    //accesoABDSuperHeroe = new SuperHeroesDBEntities();
        //    //ListaSuperHeroeBD = accesoABDSuperHeroe.SuperHeroe.ToList();

        //    //ListaSuperHeroeDTO = MapeoBD_DTO(ListaSuperHeroeBD);



        //    //ListaSuperHeroe = new List<SuperHeroe>()
        //    //{
        //    //    new SanitarioDTO()
        //    //    {
        //    //        dni = "122",
        //    //        nombre = "Jose",
        //    //        apellidos = "Ortega y Gaset",
        //    //        edad = 37,
        //    //        peso = 80,
        //    //        altura = 170,
        //    //        superPoder = "Curar",
        //    //        fechaNacimiento = new DateTime(1983,6,9),
        //    //        valor = 99,
        //    //        curar = true,
        //    //        salario = 3000
        //    //    },
        //    //    new SanitarioDTO()
        //    //    {
        //    //        dni = "567",
        //    //        nombre = "Pedro Carlos",
        //    //        apellidos = "Cavadas Rodríguez",
        //    //        edad = 54,
        //    //        peso = 70,
        //    //        altura = 175,
        //    //        superPoder = "Curar",
        //    //        fechaNacimiento = new DateTime(1965,11,4),
        //    //        valor = 99,
        //    //        curar = true,
        //    //        salario = 5000
        //    //    },
        //    //    new BomberoDTO()
        //    //    {
        //    //        dni = "091",
        //    //        nombre = "Sebas",
        //    //        apellidos = "Fernandez Garcia",
        //    //        edad = 52,
        //    //        peso = 75,
        //    //        altura = 180,
        //    //        superPoder = "Curar",
        //    //        fechaNacimiento = new DateTime(1968,9,15),
        //    //        valor = 90,
        //    //        apagarFuego = true,
        //    //        salario = 1500
        //    //    },
        //    //    new MarvelDTO()
        //    //    {
        //    //        dni = "0001",
        //    //        nombre = "Capitan",
        //    //        apellidos = "Mar-Vell",
        //    //        edad = 53,
        //    //        peso = 110,
        //    //        altura = 190,
        //    //        superPoder = "Súper-Kree",
        //    //        fechaNacimiento = new DateTime(1967,12,2),
        //    //        volar = true,
        //    //        superFuerza = true,
        //    //        vengadores = true
        //    //    },
        //    //    new MarvelDTO()
        //    //    {
        //    //        dni = "0002",
        //    //        nombre = "Tony",
        //    //        apellidos = "Stark",
        //    //        edad = 52,
        //    //        peso = 110,
        //    //        altura = 190,
        //    //        superPoder = "Inteligencia abrumadora",
        //    //        fechaNacimiento = new DateTime(1968,6,2),
        //    //        volar = true,
        //    //        superFuerza = true,
        //    //        vengadores = true
        //    //    },
        //    //    new DCDTO()
        //    //    {
        //    //        dni = "999",
        //    //        nombre = "Clark",
        //    //        apellidos = "Kent",
        //    //        edad = 82,
        //    //        peso = 76,
        //    //        altura = 174,
        //    //        superPoder = "Kree",
        //    //        fechaNacimiento = new DateTime(1938,7,15),
        //    //        volar = true,
        //    //        superFuerza = true,
        //    //        ligaDeLaJusticia = true
        //    //    }

        //    //};
        //}

        ////public List<SuperHeroeDTO> MapeoBD_DTO(List<SuperHeroe> lista)
        ////{



        ////    //foreach (SuperHeroe elemento in lista)
        ////    //{
        ////    //SuperHeroeDTO nuevoSuperHeroe = new SuperHeroeDTO()
        ////    //{
        ////    //    idSuperHeroe = elemento.Id,
        ////    //    dni = elemento.DNI,
        ////    //    nombre = elemento.Nombre,
        ////    //    apellidos = elemento.Apellidos,
        ////    //    edad = elemento.Edad,
        ////    //    peso = elemento.Peso,
        ////    //    altura = elemento.Altura,
        ////    //    superPoder = elemento.SuperPoder
        ////    //};
        ////    //resul.Add(nuevoSuperHeroe);
        ////    //if (elemento.ProfesionesHeroicas.First().Sanitario.Count == 1)
        ////    //{
        ////    //    SanitarioDTO nuevoSanitario = new SanitarioDTO()
        ////    //    {
        ////    //        curar = elemento.ProfesionesHeroicas.First().Sanitario.First().Curar

        ////    //    };
        ////    //    resul.Add(nuevoSanitario);
        ////    //}

        ////    //if (elemento.ProfesionesHeroicas.First().Bombero.Count == 1)
        ////    //{
        ////    //    BomberoDTO nuevoBombero = new BomberoDTO()
        ////    //    {
        ////    //        apagarFuego = (bool)elemento.ProfesionesHeroicas.First().Bombero.First().ApagarFuego
        ////    //    };
        ////    //    resul.Add(nuevoBombero);
        ////    //}
        ////    ////Si es un superhumano
        ////    //if (elemento.SuperHumanos.First().Marvel.Count == 1)
        ////    //{
        ////    //    MarvelDTO nuevoMarvel = new MarvelDTO()
        ////    //    {
        ////    //        vengadores = (bool)elemento.SuperHumanos.First().Marvel.First().Vengadores
        ////    //    };
        ////    //    resul.Add(nuevoMarvel);
        ////    //}
        ////    //if (elemento.SuperHumanos.First().DC.Count == 1)
        ////    //{
        ////    //    DCDTO nuevoDC = new DCDTO()
        ////    //    {
        ////    //        ligaDeLaJusticia = (bool)elemento.SuperHumanos.First().DC.First().LigaDeLaJusticia
        ////    //    };
        ////    //    resul.Add(nuevoDC);
        ////    //}

        ////    //if (elemento.ProfesionesHeroicas != null)
        ////    //{
        ////    //    ListaSuperHeroe.OfType<ProfesionesHeroicasDTO>().ToList().ForEach(x => (x.GetType().Name == "Valor").GetType(x => { x.MostrarPorPantalla(); Console.WriteLine(); });
        ////    //    ProfesionesHeroicasDTO nuevoProfesionesHeroicasDTO = new ProfesionesHeroicasDTO();
        ////    //    {
        ////    //        dni = elemento.DNI,
        ////    //        nombre = elemento.Nombre,
        ////    //        apellidos = elemento.Apellidos,
        ////    //        edad = elemento.Edad,
        ////    //        peso = elemento.Peso,
        ////    //        altura = elemento.Altura,
        ////    //        superPoder = elemento.SuperPoder,
        ////    //        fechaNacimiento = new DateTime(1983, 6, 9),
        ////    //        valor = (decimal)elemento.ProfesionesHeroicas.First().Valor,
        ////    //        salario = (decimal)elemento.ProfesionesHeroicas.First().Salario
        ////    //    };
        ////    //    resul.Add(nuevoProfesionesHeroicasDTO);
        ////    //}
        ////    //Si tiene una profesion heroica
        ////    //}
        ////    //return resul;
        ////}
        ////public List<SuperHeroe> MapeoDTO_BD(List<SuperHeroeDTO> lista)
        ////{
        ////    List<SuperHeroe> resul = new List<SuperHeroe>();

        ////    foreach (SuperHeroeDTO elemento in lista)
        ////    {
        ////        SuperHeroe nuevoSuperHeroe = new SuperHeroe()
        ////        {
        ////            Id = elemento.idSuperHeroe,
        ////            DNI = elemento.dni,
        ////            Nombre = elemento.nombre,
        ////            Apellidos = elemento.apellidos,
        ////            Edad = elemento.edad,
        ////            Peso = elemento.peso,
        ////            Altura = elemento.altura,
        ////            SuperPoder = elemento.superPoder,
        ////        };

        ////        if (elemento.GetType().Name == "ProfesionesHeroicasDTO")
        ////        {
        ////            ProfesionesHeroicas infoProfesionesHeroicas = new ProfesionesHeroicas()
        ////            {
        ////                Valor = ((ProfesionesHeroicasDTO)elemento).valor,
        ////                Salario = ((ProfesionesHeroicasDTO)elemento).salario
        ////            };
        ////            nuevoSuperHeroe.ProfesionesHeroicas = new List<ProfesionesHeroicas>();
        ////            nuevoSuperHeroe.ProfesionesHeroicas.Add(infoProfesionesHeroicas);

        ////        }

        ////        if (elemento.GetType().Name == "SuperHumanosDTO")
        ////        {
        ////            SuperHumanos infoSuperHumanos = new SuperHumanos()
        ////            {
        ////                Volar = ((SuperHumanosDTO)elemento).volar,
        ////                SuperFuerza = ((SuperHumanosDTO)elemento).superFuerza
        ////            };
        ////            nuevoSuperHeroe.SuperHumanos = new List<SuperHumanos>();
        ////            nuevoSuperHeroe.SuperHumanos.Add(infoSuperHumanos);

        ////        }

        ////        //if (elemento.GetType().Name == "SanitarioDTO")
        ////        //{
        ////        //    Sanitario infoSanitario = new Sanitario()
        ////        //    {
        ////        //        Curar = ((SanitarioDTO)elemento).curar
        ////        //    };
        ////        //    nuevoSuperHeroe.ProfesionesHeroicas.First().Sanitario = new List<Sanitario>();
        ////        //    nuevoSuperHeroe.ProfesionesHeroicas.First().Sanitario.Add(infoSanitario);

        ////        //}

        ////        //if (elemento.GetType().Name == "BomberoDTO")
        ////        //{
        ////        //    Bombero infoBombero = new Bombero()
        ////        //    {
        ////        //        ApagarFuego = ((BomberoDTO)elemento).apagarFuego
        ////        //    };
        ////        //    nuevoSuperHeroe.ProfesionesHeroicas.First().Bombero = new List<Bombero>();
        ////        //    nuevoSuperHeroe.ProfesionesHeroicas.First().Bombero.Add(infoBombero);
        ////        //}
        ////        //if (elemento.GetType().Name == "MarvelDTO")
        ////        //{
        ////        //    Marvel infoMarvel = new Marvel()
        ////        //    {
        ////        //        Vengadores = ((MarvelDTO)elemento).vengadores
        ////        //    };
        ////        //    nuevoSuperHeroe.SuperHumanos.First().Marvel = new List<Marvel>();
        ////        //    nuevoSuperHeroe.SuperHumanos.First().Marvel.Add(infoMarvel);
        ////        //}
        ////        //if (elemento.GetType().Name == "DCDTO")
        ////        //{
        ////        //    DC infoDC = new DC()
        ////        //    {
        ////        //        LigaDeLaJusticia = ((DCDTO)elemento).ligaDeLaJusticia
        ////        //    };
        ////        //    nuevoSuperHeroe.SuperHumanos.First().DC = new List<DC>();
        ////        //    nuevoSuperHeroe.SuperHumanos.First().DC.Add(infoDC);
        ////        //}
        ////        //resul.Add(nuevoSuperHeroe);
        ////    }
        ////    return resul;

        ////    //if (elemento.ProfesionesHeroicas != null)
        ////    //{
        ////    //    ListaSuperHeroe.OfType<ProfesionesHeroicasDTO>().ToList().ForEach(x => (x.GetType().Name == "Valor").GetType(x => { x.MostrarPorPantalla(); Console.WriteLine(); });
        ////    //    ProfesionesHeroicasDTO nuevoProfesionesHeroicasDTO = new ProfesionesHeroicasDTO();
        ////    //    {
        ////    //        dni = elemento.DNI,
        ////    //        nombre = elemento.Nombre,
        ////    //        apellidos = elemento.Apellidos,
        ////    //        edad = elemento.Edad,
        ////    //        peso = elemento.Peso,
        ////    //        altura = elemento.Altura,
        ////    //        superPoder = elemento.SuperPoder,
        ////    //        fechaNacimiento = new DateTime(1983, 6, 9),
        ////    //        valor = (decimal)elemento.ProfesionesHeroicas.First().Valor,
        ////    //        salario = (decimal)elemento.ProfesionesHeroicas.First().Salario
        ////    //    };
        ////    //    resul.Add(nuevoProfesionesHeroicasDTO);
        ////    //}
        ////    //Si tiene una profesion heroica
        ////}


        ////public void BuscarDatosEnLista()
        ////{
        ////    string buscador = "";
        ////    ListaSuperHeroe.ForEach(x =>
        ////    {
        ////        if (x.GetType().Name == buscador)
        ////        {
        ////            x.MostrarInformacionEnUnaLinea();
        ////        }
        ////    });
        ////}
        //public void MostrarDatosEnUnaLinea()
        //{
        //    if (ListaSuperHeroeDTO.First().borrado == false)
        //    {
        //        foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //        {
        //            Console.WriteLine($"ID:     {elemento.idSuperHeroe}");
        //            Console.WriteLine($"Nombre: {elemento.nombre}");
        //            Console.WriteLine();

        //        }
        //    }
        //    else
        //    {
        //        foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //        {
        //            Console.WriteLine($"ID:     {elemento.idSuperHeroe}");
        //            Console.WriteLine($"Nombre: {elemento.nombre}");
        //            Console.WriteLine("Este SuperHeroe esta dado de baja en BD");
        //            Console.WriteLine();

        //        }
        //    }

        //}
        ////public void nuevoSanitario()
        ////{
        ////    //SanitarioDTO nuevoSanitarioDTO = new SanitarioDTO();

        ////    //nuevoSanitarioDTO.PedirPorPantalla();
        ////    //ListaSuperHeroeDTO.Add(nuevoSanitarioDTO);

        ////    //Sanitario nuevoSanitario = new Sanitario();
        ////    //nuevoSanitario.ProfesionesHeroicas = new ProfesionesHeroicas();

        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.DNI = nuevoSanitarioDTO.dni;
        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.Nombre = nuevoSanitarioDTO.dni;
        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.Apellidos = nuevoSanitarioDTO.dni;
        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.Edad = nuevoSanitarioDTO.edad;
        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.Peso = nuevoSanitarioDTO.peso;
        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.Altura = nuevoSanitarioDTO.altura;
        ////    //nuevoSanitario.ProfesionesHeroicas.SuperHeroe.SuperPoder = nuevoSanitarioDTO.superPoder;
        ////    //nuevoSanitario.ProfesionesHeroicas.Valor = nuevoSanitarioDTO.valor;
        ////    //nuevoSanitario.ProfesionesHeroicas.Salario = nuevoSanitarioDTO.salario;
        ////    //nuevoSanitario.Curar = nuevoSanitarioDTO.curar;

        ////    //SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities();
        ////    //accesoABDSuperHeroe.Sanitario.Add(nuevoSanitario);
        ////    //accesoABDSuperHeroe.SaveChanges();

        ////    //Console.WriteLine();

        ////    //Console.Write("DNI: ");
        ////    //nuevoSanitario.Curar = Console.ReadLine();
        ////    //Console.Write("Nombre: ");
        ////    //nuevoSuperHeroe.Nombre = Console.ReadLine();
        ////    //Console.Write("Apellidos: ");
        ////    //nuevoSuperHeroe.Apellidos = Console.ReadLine();
        ////    //Console.Write("Edad: ");
        ////    //nuevoSuperHeroe.Edad = int.Parse(Console.ReadLine());
        ////    //Console.Write("Peso: ");
        ////    //nuevoSuperHeroe.Peso = int.Parse(Console.ReadLine());
        ////    //Console.Write("Altura: ");
        ////    //nuevoSuperHeroe.Altura = int.Parse(Console.ReadLine());
        ////    //Console.Write("SuperPoder: ");
        ////    //nuevoSuperHeroe.SuperPoder = Console.ReadLine();
        ////    //Console.Write("Fecha Nacimiento: ");
        ////    //nuevoSuperHeroe.FechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

        ////    //accesoABDSuperHeroe.SuperHeroe.Add(nuevoSuperHeroe);
        ////    //accesoABDSuperHeroe.SaveChanges();

        ////    ////ListaSuperHeroeBD.Add(nuevoSuperHeroe);
        ////    //Console.WriteLine();
        ////    //Console.WriteLine($"Nuevo SuperHeroe {nuevoSuperHeroe.Nombre} ha sido añadido correctamente. ");
        ////    //Console.Write("Pulse cualquier tecla para regresar al menú");


        ////    //Sanitario nuevoSanitario = new Sanitario();
        ////    //nuevoSanitario.PedirPorPantalla();
        ////    //ListaSuperHeroe.Add(nuevoSanitario);
        ////    //Console.WriteLine();
        ////}



        ////public void nuevoBombero()
        ////{
        ////    //Bombero nuevoBombero = new Bombero();
        ////    //nuevoBombero.PedirPorPantalla();
        ////    //ListaSuperHeroe.Add(nuevoBombero);
        ////    //Console.WriteLine();
        ////}
        ////public void nuevoMarvel()
        ////{
        ////    //Marvel nuevoMarvel = new Marvel();
        ////    //nuevoMarvel.PedirPorPantalla();
        ////    //ListaSuperHeroe.Add(nuevoMarvel);
        ////    //Console.WriteLine();
        ////}

        ////public void nuevoDC()
        ////{
        ////    //DC nuevoDC = new DC();
        ////    //nuevoDC.PedirPorPantalla();
        ////    //ListaSuperHeroe.Add(nuevoDC);
        ////    //Console.WriteLine();
        ////}

        //public void BuscaYMuestraTodosLosSuperHeroes()
        //{
        //    Console.Clear();
        //    MostrarDatosEnUnaLinea();
        //    Console.Write("¿Desea ver los datos completos de todas las profesiones heroicas? Pulse s o n: ");
        //    string opcMostrarDetallesProfesionesHeroicas = Console.ReadLine();
        //    if (opcMostrarDetallesProfesionesHeroicas == "s")
        //    {
        //        Console.Clear();
        //        foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //        {
        //            Console.WriteLine($"DNI:              {((SuperHeroeDTO)elemento).dni}");
        //            Console.WriteLine($"Nombre:           {((SuperHeroeDTO)elemento).nombre}");
        //            Console.WriteLine($"Apellidos:        {((SuperHeroeDTO)elemento).apellidos}");
        //            Console.WriteLine($"Edad:             {((SuperHeroeDTO)elemento).edad}");
        //            Console.WriteLine($"Peso:             {((SuperHeroeDTO)elemento).peso}");
        //            Console.WriteLine($"Altura:           {((SuperHeroeDTO)elemento).altura}");
        //            Console.WriteLine($"SuperPoder:       {((SuperHeroeDTO)elemento).superPoder}");

        //            //if (elemento.GetType().Name == "SuperHeroeDTO")
        //            //{
        //            //    string str_Curar = "";
        //            //    if (((SuperHeroeDTO)elemento).GetType().Name == false)
        //            //    {
        //            //        str_Curar = "No tiene la habilidad de curar";
        //            //        Console.WriteLine($"¿Puede Curar?:    {str_Curar}");
        //            //    }
        //            //    else
        //            //    {
        //            //        str_Curar = "Tiene la habilidad de curar";
        //            //        Console.WriteLine($"¿Puede Curar?:    {str_Curar}");
        //            //    }

        //            //    string str_Vengador = "";
        //            //    if (((MarvelDTO)elemento).vengadores == false)
        //            //    {
        //            //        str_Vengador = "No pertenece a los vengadores";
        //            //        Console.WriteLine($"¿Es un Vengador?: {str_Vengador}");

        //            //    }
        //            //    else
        //            //    {
        //            //        str_Vengador = "Pertenece a los vengadores";
        //            //        Console.WriteLine($"¿Es un Vengador?: {str_Vengador}");

        //            //    }
        //            //}


        //            Console.WriteLine();
        //        }
        //        //Muestra todos los datos de los Superheroes de la base de datos

        //    }

        //    //ListaSuperHeroe.ForEach(x =>
        //    //{
        //    //    x.MostrarInformacionEnUnaLinea();

        //    //});
        //    //Console.Write("¿Desea ver los datos completos de todos los SuperHeroes? Pulse s o n: ");
        //    //string opcMostrarDetalles = Console.ReadLine();

        //    //if (opcMostrarDetalles == "s")
        //    //{
        //    //    Console.Clear();
        //    //    ListaSuperHeroe.ForEach(x =>
        //    //    {
        //    //        x.MostrarPorPantalla();
        //    //        Console.WriteLine();
        //    //    });
        //    //}
        //    //Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //Console.ReadKey();
        //    //Console.Clear();
        //}
        //public void BuscaYMuestraTodasLasProfesionesHeroicas()
        //{
        //    List<SuperHeroeDTO> ListaProfesionesHeroicas = ListaSuperHeroeDTO.Where(x => x.ToString().Contains("ProfesionesHeroicas")).ToList();
        //    //if (ListaProfesionesHeroicas.Count() == 0)
        //    //{
        //    //    Console.WriteLine("No hay Superheroes disponibles en profesiones heroicas");
        //    //}
        //    foreach (SuperHeroeDTO elemento in ListaProfesionesHeroicas)
        //    {
        //        elemento.MostrarPorPantallaDatosDelSuperHeroe();
        //    }

        //    //Console.WriteLine("Elija una de las siguientes opciones:");
        //    //Console.WriteLine("1 - Mostrar todas las profesiones heroicas");
        //    //Console.WriteLine("2 - Mostrar todos los sanitarios");
        //    //Console.WriteLine("3 - Mostrar todas los bomberos");
        //    //Console.Write("Escriba la oopcion escogida: ");
        //    //string opcProfHeroicas = Console.ReadLine();
        //    //switch (opcProfHeroicas)
        //    //{
        //    //    case "1":
        //    //        Console.Clear();
        //    //        ListaSuperHeroe.ForEach(x =>
        //    //        {
        //    //            if ((x.GetType().Name == "Sanitario") || (x.GetType().Name == "Bombero"))
        //    //            {
        //    //                x.MostrarInformacionEnUnaLinea();
        //    //            }
        //    //        });
        //    //        Console.Write("¿Desea ver los datos completos de todas las profesiones heroicas? Pulse s o n: ");
        //    //        string opcMostrarDetallesProfesionesHeroicas = Console.ReadLine();
        //    //        if (opcMostrarDetallesProfesionesHeroicas == "s")
        //    //        {
        //    //            Console.Clear();
        //    //            ListaSuperHeroe.ForEach(x =>
        //    //            {
        //    //                if ((x.GetType().Name == "Sanitario") || (x.GetType().Name == "Bombero"))
        //    //                {
        //    //                    x.MostrarPorPantalla();
        //    //                    Console.WriteLine();
        //    //                }
        //    //            });
        //    //        }
        //    //        Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //        Console.ReadKey();
        //    //        Console.Clear();

        //    //        break;
        //    //    case "2":
        //    //        Console.Clear();
        //    //        ListaSuperHeroe.ForEach(x =>
        //    //        {
        //    //            if (x.GetType().Name == "Sanitario")
        //    //            {
        //    //                x.MostrarInformacionEnUnaLinea();
        //    //            }
        //    //        });
        //    //        Console.Write("¿Desea ver los datos completos de todos los sanitarios? Pulse s o n: ");
        //    //        string opcMostrarDetallesSanitario = Console.ReadLine();
        //    //        if (opcMostrarDetallesSanitario == "s")
        //    //        {
        //    //            Console.Clear();
        //    //            ListaSuperHeroe.ForEach(x =>
        //    //            {
        //    //                if (x.GetType().Name == "Sanitario")
        //    //                {
        //    //                    x.MostrarPorPantalla();
        //    //                    Console.WriteLine();
        //    //                }
        //    //            });
        //    //        }
        //    //        Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //        Console.ReadKey();
        //    //        Console.Clear();
        //    //        break;
        //    //    case "3":
        //    //        Console.Clear();
        //    //        ListaSuperHeroe.ForEach(x =>
        //    //        {
        //    //            if (x.GetType().Name == "Bombero")
        //    //            {
        //    //                x.MostrarInformacionEnUnaLinea();
        //    //            }
        //    //        });
        //    //        Console.Write("¿Desea ver los datos completos de todos los bomberos? Pulse s o n: ");
        //    //        string opcMostrarDetallesBombero = Console.ReadLine();
        //    //        if (opcMostrarDetallesBombero == "s")
        //    //        {
        //    //            Console.Clear();
        //    //            ListaSuperHeroe.ForEach(x =>
        //    //            {
        //    //                if (x.GetType().Name == "Bombero")
        //    //                {
        //    //                    x.MostrarPorPantalla();
        //    //                    Console.WriteLine();
        //    //                }
        //    //            });
        //    //        }
        //    //        Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //        Console.ReadKey();
        //    //        Console.Clear();
        //    //        break;
        //    //}
        //}
        //public void BuscaYMuestraTodosLosSuperHumanos()
        //{
        //    //Console.WriteLine("Elija una de las siguientes opciones:");
        //    //Console.WriteLine("1 - Mostrar todos los SuperHumanos");
        //    //Console.WriteLine("2 - Mostrar todos los heroes Marvel");
        //    //Console.WriteLine("3 - Mostrar todas los heroes DC");
        //    //Console.Write("Escriba la oopcion escogida: ");
        //    //string opcSuperHumano = Console.ReadLine();
        //    //switch (opcSuperHumano)
        //    //{
        //    //    case "1":
        //    //        Console.Clear();
        //    //        ListaSuperHeroe.ForEach(x =>
        //    //        {
        //    //            if ((x.GetType().Name == "Marvel") || (x.GetType().Name == "DC"))
        //    //            {
        //    //                x.MostrarInformacionEnUnaLinea();
        //    //            }
        //    //        });
        //    //        Console.Write("¿Desea ver los datos completos de todos los SuperHumanos? Pulse s o n: ");
        //    //        string opcMostrarDetallesSuperHumano = Console.ReadLine();
        //    //        if (opcMostrarDetallesSuperHumano == "s")
        //    //        {
        //    //            Console.Clear();
        //    //            ListaSuperHeroe.ForEach(x =>
        //    //            {
        //    //                if ((x.GetType().Name == "Marvel") || (x.GetType().Name == "DC"))
        //    //                {
        //    //                    x.MostrarPorPantalla();
        //    //                    Console.WriteLine();
        //    //                }
        //    //            });
        //    //        }
        //    //        Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //        Console.ReadKey();
        //    //        Console.Clear();
        //    //        break;
        //    //    case "2":
        //    //        Console.Clear();
        //    //        ListaSuperHeroe.ForEach(x =>
        //    //        {
        //    //            if (x.GetType().Name == "Marvel")
        //    //            {
        //    //                x.MostrarInformacionEnUnaLinea();
        //    //            }
        //    //        });
        //    //        Console.Write("¿Desea ver los datos completos de todos los heroes de Marvel? Pulse s o n: ");
        //    //        string opcMostrarDetallesMarvel = Console.ReadLine();
        //    //        if (opcMostrarDetallesMarvel == "s")
        //    //        {
        //    //            Console.Clear();
        //    //            ListaSuperHeroe.ForEach(x =>
        //    //            {
        //    //                if (x.GetType().Name == "Marvel")
        //    //                {
        //    //                    x.MostrarPorPantalla();
        //    //                    Console.WriteLine();
        //    //                }
        //    //            });
        //    //        }
        //    //        Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //        Console.ReadKey();
        //    //        Console.Clear();
        //    //        break;
        //    //    case "3":
        //    //        Console.Clear();
        //    //        ListaSuperHeroe.ForEach(x =>
        //    //        {
        //    //            if (x.GetType().Name == "DC")
        //    //            {
        //    //                x.MostrarInformacionEnUnaLinea();
        //    //            }
        //    //        });
        //    //        Console.Write("¿Desea ver los datos completos de todos los heroes de DC? Pulse s o n: ");
        //    //        string opcMostrarDetallesDC = Console.ReadLine();
        //    //        if (opcMostrarDetallesDC == "s")
        //    //        {
        //    //            Console.Clear();
        //    //            ListaSuperHeroe.ForEach(x =>
        //    //            {
        //    //                if (x.GetType().Name == "DC")
        //    //                {
        //    //                    x.MostrarPorPantalla();
        //    //                    Console.WriteLine();
        //    //                }
        //    //            });
        //    //        }
        //    //        Console.Write("(pulse cualquier tecla para volver al menú principal)");
        //    //        Console.ReadKey();
        //    //        Console.Clear();
        //    //        break;
        //    //}
        //}
        //public void BuscaYMuestraUnSuperHeroePorId()
        //{
        //    Console.Write("Nombre del SuperHeroe: ");
        //    string str_nombreLeido = Console.ReadLine();
        //    Console.Clear();
        //    switch (OpcionSeleccionada)
        //    {
        //        case "2":
        //            try
        //            {
        //                //MostrarInformacionEnUnaLinea(str_nombreLeido);
        //            }
        //            catch (ArgumentException argex)
        //            {
        //                Console.WriteLine("Ha Habido un error al introducir el nombre");
        //                Console.WriteLine(argex.Message);
        //                Console.WriteLine(argex.InnerException.Message);
        //                Console.WriteLine($"Metodo MostrarInformacionEnUnaLinea: {str_nombreLeido} no existe en BD");
        //            }
        //            break;


        //            //Console.WriteLine("Escriba el id del SuperHeroe que desea buscar: ");
        //            //int idBuscado = Convert.ToInt32(Console.ReadLine());
        //            //ListaSuperHeroe.ForEach(x =>
        //            //{
        //            //    if (x.idSuperHeroe.Equals(idBuscado))
        //            //    {
        //            //        x.MostrarPorPantalla();
        //            //        Console.WriteLine();
        //            //    }
        //            //});
        //    }
        //}
        //public void BuscaYMuestraYModificaUnSuperHeroePorId()
        //{
        //    Console.WriteLine("Escriba el id del SuperHeroe que desea modificar: ");
        //    int idModificado = Convert.ToInt32(Console.ReadLine());

        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (((SuperHeroeDTO)elemento).idSuperHeroe == idModificado)
        //        {

        //            SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities();
        //            SuperHeroe superHeroeAModificar = accesoABDSuperHeroe.SuperHeroe.First(x => x.Id == elemento.idSuperHeroe);

        //            Console.Write("Nuevo DNI:        ");
        //            string nuevoDNI = Console.ReadLine();
        //            elemento.dni = nuevoDNI;
        //            superHeroeAModificar.Nombre = nuevoDNI;
        //            Console.Write("Nuevo Nombre:     ");
        //            string nuevoNombre = Console.ReadLine();
        //            elemento.nombre = nuevoNombre;
        //            superHeroeAModificar.Nombre = nuevoNombre;
        //            Console.Write("Nuevos Apellidos: ");
        //            string nuevoApellidos = Console.ReadLine();
        //            elemento.apellidos = nuevoApellidos;
        //            superHeroeAModificar.Apellidos = nuevoApellidos;
        //            Console.Write("Nuevo Edad:       ");
        //            int nuevoEdad = int.Parse(Console.ReadLine());
        //            elemento.edad = nuevoEdad;
        //            superHeroeAModificar.Edad = nuevoEdad;
        //            Console.Write("Nuevo Peso:       ");
        //            int nuevoPeso = int.Parse(Console.ReadLine());
        //            elemento.peso = nuevoPeso;
        //            superHeroeAModificar.Peso = nuevoPeso;
        //            Console.Write("Nuevo Altura:     ");
        //            int nuevoAltura = int.Parse(Console.ReadLine());
        //            elemento.altura = nuevoAltura;
        //            superHeroeAModificar.Altura = nuevoAltura;
        //            Console.Write("Nuevo SuperPoder: ");
        //            string nuevoSuperPoder = Console.ReadLine();
        //            elemento.superPoder = nuevoSuperPoder;
        //            superHeroeAModificar.SuperPoder = nuevoSuperPoder;
        //            accesoABDSuperHeroe.SaveChanges();
        //        }
        //    }


        //    //ListaSuperHeroe.ForEach(x =>
        //    //{
        //    //    if (x.idSuperHeroe.Equals(idModificado))
        //    //    {
        //    //        Console.Clear();
        //    //        x.MostrarPorPantalla();
        //    //        Console.WriteLine();
        //    //        Console.WriteLine("Escriba a continuación los datos nuevos:");
        //    //        x.PedirPorPantalla();
        //    //    }
        //    //});
        //}
        //public void BuscaYEliminaUnSuperHeroePorID()
        //{
        //    //Console.WriteLine("Cual es el heroe que desea eliminar: ");
        //    //int idEliminado = Convert.ToInt32(Console.ReadLine());
        //    //ListaSuperHeroe.ForEach(x =>
        //    //{
        //    //    if (x.idSuperHeroe.Equals(idEliminado))
        //    //    {
        //    //        Console.Clear();
        //    //        x.MostrarPorPantalla();
        //    //        Console.WriteLine();
        //    //    }
        //    //});
        //    //Console.Write("¿Estas seguro? Pulse s o n: ");
        //    //string str_leido;
        //    //str_leido = Convert.ToString(Console.ReadLine()).ToLower();
        //    //if (str_leido == "s")
        //    //{
        //    //    ListaSuperHeroe.RemoveAll(x => x.idSuperHeroe.Equals(idEliminado));
        //    //}

        //}


        ////public void NuevoSuperHeroe()
        ////{
        ////    SuperHeroe nuevoSuperHeroe = new SuperHeroe();

        ////    Console.Write("DNI: ");
        ////    nuevoSuperHeroe.DNI = Console.ReadLine();
        ////    Console.Write("Nombre: ");
        ////    nuevoSuperHeroe.Nombre = Console.ReadLine();
        ////    Console.Write("Apellidos: ");
        ////    nuevoSuperHeroe.Apellidos = Console.ReadLine();
        ////    Console.Write("Edad: ");
        ////    nuevoSuperHeroe.Edad = int.Parse(Console.ReadLine());
        ////    Console.Write("Peso: ");
        ////    nuevoSuperHeroe.Peso = int.Parse(Console.ReadLine());
        ////    Console.Write("Altura: ");
        ////    nuevoSuperHeroe.Altura = int.Parse(Console.ReadLine());
        ////    Console.Write("SuperPoder: ");
        ////    nuevoSuperHeroe.SuperPoder = Console.ReadLine();
        ////    nuevoSuperHeroe.Borrado = false;

        ////    SuperHeroe nuevoSuperHeroeCreado = accesoABDSuperHeroe.SuperHeroe.Add(nuevoSuperHeroe);
        ////    accesoABDSuperHeroe.SaveChanges();


        ////    ProfesionesHeroicas nuevoProfesionesHeroicas = new ProfesionesHeroicas();
        ////    nuevoProfesionesHeroicas.IdSuperHeroe = nuevoSuperHeroeCreado.Id;
        ////    Console.WriteLine($"Nivel de Valor de 0 a 100: ");
        ////    nuevoProfesionesHeroicas.Valor = int.Parse(Console.ReadLine());
        ////    Console.WriteLine($"Cuantía del salario: ");
        ////    nuevoProfesionesHeroicas.Salario = decimal.Parse(Console.ReadLine());

        ////    accesoABDSuperHeroe.ProfesionesHeroicas.Add(nuevoProfesionesHeroicas);
        ////    accesoABDSuperHeroe.SaveChanges();


        ////    SuperHumanos nuevoSuperHumano = new SuperHumanos();
        ////    nuevoSuperHumano.IdSuperHeroe = nuevoSuperHeroeCreado.Id;
        ////    Console.Write("¿Puede volar? Pulse s o n: ");
        ////    string str_leidoVolar;
        ////    str_leidoVolar = Convert.ToString(Console.ReadLine()).ToLower();
        ////    if (str_leidoVolar == "s")
        ////    {
        ////        nuevoSuperHumano.Volar = true;
        ////    }
        ////    else { nuevoSuperHumano.Volar = false; }

        ////    Console.Write("¿Tiene SuperFuerza? Pulse s o n: ");
        ////    string str_leidoSuperFuerza;
        ////    str_leidoSuperFuerza = Convert.ToString(Console.ReadLine()).ToLower();
        ////    if (str_leidoSuperFuerza == "s")
        ////    {
        ////        nuevoSuperHumano.SuperFuerza = true;
        ////    }
        ////    else { nuevoSuperHumano.SuperFuerza = false; }

        ////    accesoABDSuperHeroe.SuperHumanos.Add(nuevoSuperHumano);
        ////    accesoABDSuperHeroe.SaveChanges();


        ////    Sanitario nuevoSanitario = new Sanitario();
        ////    nuevoSanitario.IdProfesionesHeroicas = nuevoProfesionesHeroicas.Id;
        ////    Console.Write("¿Tiene el poder de Curar? Escriba s o n: ");
        ////    string str_leidoCurar;
        ////    str_leidoCurar = Convert.ToString(Console.ReadLine()).ToLower();
        ////    if (str_leidoCurar == "s")
        ////    {
        ////        nuevoSanitario.Curar = true;
        ////    }
        ////    else { nuevoSanitario.Curar = false; }

        ////    accesoABDSuperHeroe.Sanitario.Add(nuevoSanitario);
        ////    accesoABDSuperHeroe.SaveChanges();


        ////    Bombero nuevoBombero = new Bombero();
        ////    nuevoBombero.IdProfesionesHeroicas = nuevoProfesionesHeroicas.Id;
        ////    Console.Write("¿Puede apagar fuego? Escriba s o n: ");
        ////    string str_leidoApagarFuego;
        ////    str_leidoApagarFuego = Convert.ToString(Console.ReadLine()).ToLower();
        ////    if (str_leidoApagarFuego == "s")
        ////    {
        ////        nuevoBombero.ApagarFuego = true;
        ////    }
        ////    else { nuevoBombero.ApagarFuego = false; }

        ////    accesoABDSuperHeroe.Bombero.Add(nuevoBombero);
        ////    accesoABDSuperHeroe.SaveChanges();


        ////    Marvel nuevoMarvel = new Marvel();
        ////    nuevoMarvel.IdSuperHumanos = nuevoSuperHumano.Id;
        ////    Console.Write("¿Pertenece a los vengadores? Escriba s o n: ");
        ////    string str_leidoVengador;
        ////    str_leidoVengador = Convert.ToString(Console.ReadLine()).ToLower();
        ////    if (str_leidoVengador == "s")
        ////    {
        ////        nuevoMarvel.Vengadores = true;
        ////    }
        ////    else { nuevoMarvel.Vengadores = false; }

        ////    accesoABDSuperHeroe.Marvel.Add(nuevoMarvel);
        ////    accesoABDSuperHeroe.SaveChanges();

        ////    DC nuevoDC = new DC();
        ////    nuevoDC.IdSuperHumanos = nuevoSuperHumano.Id;
        ////    Console.Write("¿Pertenece a la liga de la justicia? Escriba s o n: ");
        ////    string str_leidoLigaJusticia;
        ////    str_leidoLigaJusticia = Convert.ToString(Console.ReadLine()).ToLower();
        ////    if (str_leidoLigaJusticia == "s")
        ////    {
        ////        nuevoDC.LigaDeLaJusticia = true;
        ////    }
        ////    else { nuevoDC.LigaDeLaJusticia = false; }

        ////    accesoABDSuperHeroe.DC.Add(nuevoDC);
        ////    accesoABDSuperHeroe.SaveChanges();


        ////    Console.WriteLine();
        ////    Console.WriteLine($"Nuevo SuperHeroe {nuevoSuperHeroe.Nombre} ha sido añadido correctamente. ");
        ////    Console.Write("Pulse cualquier tecla para regresar al menú");
        ////}

        //public void MenuPrincipal()
        //{
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("--------PROGRAMA 18: SUPERHEROES--------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine(" 1 - Gestionar Profesiones Heroicas");
        //    Console.WriteLine(" 2 - Gestionar Super Humanos");
        //    Console.WriteLine(" 3 - Modificar un SuperHeroe por ID");
        //    Console.WriteLine(" 4 - Mostrar todos los SuperHeroes");
        //    Console.WriteLine(" 5 - Dar de baja a un SuperHeroe");
        //    Console.WriteLine(" 6 - Salir");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.Write("Seleccione una opción: ");
        //    OpcionSeleccionada = Console.ReadLine();
        //}

        //public void SeleccionMenuPrincipal()
        //{
        //    switch (OpcionSeleccionada)
        //    {
        //        case "1":
        //        case "2":
        //            Console.Clear();
        //            switch (OpcionSeleccionada)
        //            {
        //                case "1":
        //                    do
        //                    {
        //                        MenuProfesionesHeroicas();
        //                        SeleccionMenuProfesioneHeroicas();
        //                    } while (terminarMenuProfesionerHeroicas == false);
        //                    break;
        //                case "2":
        //                    do
        //                    {
        //                        MenuSuperHumanos();
        //                        SeleccionMenuSuperHumanos();
        //                    } while (terminarMenuSuperHumanos == false);
        //                    break;
        //            }

        //            break;
        //        case "3":
        //            BuscaYMuestraYModificaUnSuperHeroePorId();
        //            break;
        //        case "4":
        //            BuscaYMuestraTodosLosSuperHeroes();
        //            break;
        //        case "5":
        //            DarDeBajaUnSuperHeroe();
        //            break;
        //        case "6":
        //            terminar = true;
        //            break;
        //        case "":
        //            Console.Clear();
        //            terminar = true;
        //            //ListaSuperHeroeBD = MapeoDTO_BD(ListaSuperHeroeDTO);

        //            //foreach (SuperHeroe elemento in ListaSuperHeroeBD)
        //            //{
        //            //    if (elemento.Id == 0)
        //            //    {
        //            //        accesoABDSuperHeroe.SuperHeroe.Add(elemento);
        //            //    }
        //            //    else
        //            //    {
        //            //        SuperHeroe superHeroeAModificar = accesoABDSuperHeroe.SuperHeroe.Find(elemento.Id);

        //            //        superHeroeAModificar.DNI = elemento.DNI;
        //            //        superHeroeAModificar.Nombre = elemento.Nombre;
        //            //        superHeroeAModificar.Apellidos = elemento.Apellidos;
        //            //        superHeroeAModificar.Edad = elemento.Edad;
        //            //        superHeroeAModificar.Peso = elemento.Peso;
        //            //        superHeroeAModificar.Altura = elemento.Altura;
        //            //        superHeroeAModificar.SuperPoder = elemento.SuperPoder;
        //            //    }
        //            //}
        //            //accesoABDSuperHeroe.SaveChanges();
        //            break;
        //        default:
        //            Console.WriteLine("Opción Incorrecta. Pulse cualquier tecla para volver a seleccionar opción");
        //            break;
        //    }
        //    if (OpcionSeleccionada != "")
        //    {
        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}

        //public void DarDeBajaUnSuperHeroe()
        //{
        //    Console.WriteLine("Introduzca el nombre del usuario que quiere dar de baja");
        //    string nombreLeido = Console.ReadLine();

        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {

        //        if (nombreLeido == elemento.nombre)
        //        {
        //            if (elemento.borrado == false)
        //            {
        //                elemento.borrado = true;
        //                SuperHeroesDBEntities AccesoBD = new SuperHeroesDBEntities();
        //                SuperHeroe superHeroeAeliminar = AccesoBD.SuperHeroe.FirstOrDefault(x => x.Nombre == elemento.nombre);
        //                superHeroeAeliminar.Borrado = elemento.borrado;
        //                AccesoBD.SaveChanges();
        //                Console.WriteLine("El SuperHeroe se ha dado de baja correctamente");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"El SuperHeroe {elemento.nombre} ya ha sido dado de baja");
        //            }
        //        }

        //    }
        //    Console.WriteLine("Pulsa para finalizar");
        //}
        //public void MenuProfesionesHeroicas()
        //{
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------PROFESIONES HEROICAS----------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine(" 1 - Crear nuevo Sanitario");
        //    Console.WriteLine(" 2 - Crear nuevo Bombero");
        //    Console.WriteLine(" 3 - Modificar Sanitario");
        //    Console.WriteLine(" 4 - Modificar Bombero");
        //    Console.WriteLine(" 5 - Mostrar todas los sanitarios");
        //    Console.WriteLine(" 6 - Mostrar todas los bomberos");
        //    Console.WriteLine(" 7 - Mostrar Sanitario por nombre");
        //    Console.WriteLine(" 8 - Mostrar Bombero por nombre");
        //    Console.WriteLine(" 9 - Salir");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.Write("Seleccione una opción: ");
        //    OpcionSeleccionada = Console.ReadLine();
        //    Console.Clear();
        //}
        //public void SeleccionMenuProfesioneHeroicas()
        //{
        //    switch (OpcionSeleccionada)
        //    {
        //        case "1":
        //            NuevoSuperHeroeSanitario();
        //            break;
        //        case "2":
        //            NuevoSuperHeroeBombero();
        //            break;
        //        case "3":
        //            ModificarSanitario();
        //            break;
        //        case "4":
        //            ModificarBombero();
        //            break;
        //        case "5":
        //            BuscaYMuestraTodosLosSuperHeroesSanitario();
        //            break;
        //        case "6":
        //            BuscaYMuestraTodosLosSuperHeroesBombero();
        //            break;
        //        case "7":
        //            BuscaYMuestraSanitarioPorNombre();
        //            break;
        //        case "8":
        //            BuscaYMuestraBomberoPorNombre();
        //            break;
        //        case "9":
        //            //GetSanitariosQuePuedenCurar();
        //            break;
        //        case "10":
        //            terminarMenuProfesionerHeroicas = true;
        //            break;
        //        case "":
        //            Console.Clear();
        //            terminarMenuProfesionerHeroicas = true;
        //            break;
        //        default:
        //            Console.WriteLine("Opción Incorrecta. Pulse cualquier tecla para volver a seleccionar opción");
        //            break;
        //    }
        //    if (OpcionSeleccionada != "")
        //    {
        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}

        //public void NuevoSuperHeroeSanitario()
        //{
        //    SanitarioDTO sanitarioDTO = new SanitarioDTO();
        //    sanitarioDTO.PedirPorPantalla();
        //    ListaSuperHeroeDTO.Add(sanitarioDTO);
        //    Sanitario sanitarioBD = new Sanitario();
        //    sanitarioBD.ProfesionesHeroicas = new ProfesionesHeroicas();
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe = new SuperHeroe();
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.DNI = sanitarioDTO.dni;
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.Nombre = sanitarioDTO.nombre;
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.Apellidos = sanitarioDTO.apellidos;
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.Edad = sanitarioDTO.edad;
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.Peso = sanitarioDTO.peso;
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.Altura = sanitarioDTO.altura;
        //    sanitarioBD.ProfesionesHeroicas.SuperHeroe.SuperPoder = sanitarioDTO.superPoder;
        //    sanitarioBD.ProfesionesHeroicas.Valor = sanitarioDTO.valor;
        //    sanitarioBD.ProfesionesHeroicas.Salario = sanitarioDTO.salario;
        //    sanitarioBD.Curar = sanitarioDTO.curar;
        //    SuperHeroesDBEntities accesoDTO_DB = new SuperHeroesDBEntities();
        //    accesoDTO_DB.Sanitario.Add(sanitarioBD);
        //    accesoDTO_DB.SaveChanges();
        //    Console.WriteLine();
        //}
        //public void NuevoSuperHeroeBombero()
        //{
        //    BomberoDTO bomberoDTO = new BomberoDTO();
        //    bomberoDTO.PedirPorPantalla();
        //    ListaSuperHeroeDTO.Add(bomberoDTO);
        //    Bombero bomberoBD = new Bombero();
        //    bomberoBD.ProfesionesHeroicas = new ProfesionesHeroicas();
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe = new SuperHeroe();
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.DNI = bomberoDTO.dni;
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.Nombre = bomberoDTO.nombre;
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.Apellidos = bomberoDTO.apellidos;
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.Edad = bomberoDTO.edad;
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.Peso = bomberoDTO.peso;
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.Altura = bomberoDTO.altura;
        //    bomberoBD.ProfesionesHeroicas.SuperHeroe.SuperPoder = bomberoDTO.superPoder;
        //    bomberoBD.ProfesionesHeroicas.Valor = bomberoDTO.valor;
        //    bomberoBD.ProfesionesHeroicas.Salario = bomberoDTO.salario;
        //    bomberoBD.ApagarFuego = bomberoDTO.apagarFuego;
        //    SuperHeroesDBEntities accesoDTO_DB = new SuperHeroesDBEntities();
        //    accesoDTO_DB.Bombero.Add(bomberoBD);
        //    accesoDTO_DB.SaveChanges();
        //    Console.WriteLine();
        //}
        //public void ModificarSanitario()
        //{
        //    Console.Write("Nombre del Sanitario a modificar: ");
        //    string nombreAModificar = Console.ReadLine();


        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "SanitarioDTO" && ((SanitarioDTO)elemento).nombre == nombreAModificar)
        //        {

        //            SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities();
        //            SuperHeroe superHeroeAModificar = accesoABDSuperHeroe.SuperHeroe.First(x => x.Id == elemento.idSuperHeroe);

        //            Console.Write("Nuevo DNI:        ");
        //            string nuevoDNI = Console.ReadLine();
        //            elemento.dni = nuevoDNI;
        //            superHeroeAModificar.DNI = nuevoDNI;
        //            Console.Write("Nuevo Nombre:     ");
        //            string nuevoNombre = Console.ReadLine();
        //            elemento.nombre = nuevoNombre;
        //            superHeroeAModificar.Nombre = nuevoNombre;
        //            Console.Write("Nuevos Apellidos: ");
        //            string nuevoApellidos = Console.ReadLine();
        //            elemento.apellidos = nuevoApellidos;
        //            superHeroeAModificar.Apellidos = nuevoApellidos;
        //            Console.Write("Nuevo Edad:       ");
        //            int nuevoEdad = int.Parse(Console.ReadLine());
        //            elemento.edad = nuevoEdad;
        //            superHeroeAModificar.Edad = nuevoEdad;
        //            Console.Write("Nuevo Peso:       ");
        //            int nuevoPeso = int.Parse(Console.ReadLine());
        //            elemento.peso = nuevoPeso;
        //            superHeroeAModificar.Peso = nuevoPeso;
        //            Console.Write("Nuevo Altura:     ");
        //            int nuevoAltura = int.Parse(Console.ReadLine());
        //            elemento.altura = nuevoAltura;
        //            superHeroeAModificar.Altura = nuevoAltura;
        //            Console.Write("Nuevo SuperPoder: ");
        //            string nuevoSuperPoder = Console.ReadLine();
        //            elemento.superPoder = nuevoSuperPoder;
        //            superHeroeAModificar.SuperPoder = nuevoSuperPoder;
        //            Console.Write("Nuevo nivel de Valor (de 0 a 100): ");
        //            int nuevoValor = int.Parse(Console.ReadLine());
        //            ((ProfesionesHeroicasDTO)elemento).valor = nuevoValor;
        //            superHeroeAModificar.ProfesionesHeroicas.First().Valor = nuevoValor;
        //            Console.Write("Nueva cuantía del Salario: ");
        //            int nuevoSalario = int.Parse(Console.ReadLine());
        //            ((ProfesionesHeroicasDTO)elemento).salario = nuevoSalario;
        //            superHeroeAModificar.ProfesionesHeroicas.First().Salario = nuevoSalario;
        //            Console.Write("¿Tiene la habilidad de Curar? (Pulse s o n para Si o No):  ");
        //            string curarLeido = Console.ReadLine();
        //            bool nuevoCurar;
        //            if (curarLeido == "s")
        //            {
        //                nuevoCurar = true;
        //                superHeroeAModificar.ProfesionesHeroicas.First().Sanitario.First().Curar = nuevoCurar;
        //            }
        //            else
        //            {
        //                nuevoCurar = false;
        //                superHeroeAModificar.ProfesionesHeroicas.First().Sanitario.First().Curar = nuevoCurar;
        //            }
        //            accesoABDSuperHeroe.SaveChanges();
        //        }
        //    }
        //}
        //public void ModificarBombero()
        //{
        //    Console.Write("Nombre del Bombero a modificar: ");
        //    string nombreAModificar = Console.ReadLine();


        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "BomberoDTO" && ((BomberoDTO)elemento).nombre == nombreAModificar)
        //        {

        //            SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities();
        //            SuperHeroe superHeroeAModificar = accesoABDSuperHeroe.SuperHeroe.First(x => x.Id == elemento.idSuperHeroe);

        //            Console.Write("Nuevo DNI:        ");
        //            string nuevoDNI = Console.ReadLine();
        //            elemento.dni = nuevoDNI;
        //            superHeroeAModificar.DNI = nuevoDNI;
        //            Console.Write("Nuevo Nombre:     ");
        //            string nuevoNombre = Console.ReadLine();
        //            elemento.nombre = nuevoNombre;
        //            superHeroeAModificar.Nombre = nuevoNombre;
        //            Console.Write("Nuevos Apellidos: ");
        //            string nuevoApellidos = Console.ReadLine();
        //            elemento.apellidos = nuevoApellidos;
        //            superHeroeAModificar.Apellidos = nuevoApellidos;
        //            Console.Write("Nuevo Edad:       ");
        //            int nuevoEdad = int.Parse(Console.ReadLine());
        //            elemento.edad = nuevoEdad;
        //            superHeroeAModificar.Edad = nuevoEdad;
        //            Console.Write("Nuevo Peso:       ");
        //            int nuevoPeso = int.Parse(Console.ReadLine());
        //            elemento.peso = nuevoPeso;
        //            superHeroeAModificar.Peso = nuevoPeso;
        //            Console.Write("Nuevo Altura:     ");
        //            int nuevoAltura = int.Parse(Console.ReadLine());
        //            elemento.altura = nuevoAltura;
        //            superHeroeAModificar.Altura = nuevoAltura;
        //            Console.Write("Nuevo SuperPoder: ");
        //            string nuevoSuperPoder = Console.ReadLine();
        //            elemento.superPoder = nuevoSuperPoder;
        //            superHeroeAModificar.SuperPoder = nuevoSuperPoder;
        //            Console.Write("Nuevo nivel de Valor (de 0 a 100): ");
        //            int nuevoValor = int.Parse(Console.ReadLine());
        //            ((ProfesionesHeroicasDTO)elemento).valor = nuevoValor;
        //            superHeroeAModificar.ProfesionesHeroicas.First().Valor = nuevoValor;
        //            Console.Write("Nueva cuantía del Salario: ");
        //            int nuevoSalario = int.Parse(Console.ReadLine());
        //            ((ProfesionesHeroicasDTO)elemento).salario = nuevoSalario;
        //            superHeroeAModificar.ProfesionesHeroicas.First().Salario = nuevoSalario;
        //            Console.Write("¿Tiene la habilidad de apagar fuego? (Pulse s o n para Si o No):  ");
        //            string apagarFuegoLeido = Console.ReadLine();
        //            bool nuevoApagarFuego;
        //            if (apagarFuegoLeido == "s")
        //            {
        //                nuevoApagarFuego = true;
        //                superHeroeAModificar.ProfesionesHeroicas.First().Sanitario.First().Curar = nuevoApagarFuego;
        //            }
        //            else
        //            {
        //                nuevoApagarFuego = false;
        //                superHeroeAModificar.ProfesionesHeroicas.First().Sanitario.First().Curar = nuevoApagarFuego;
        //            }
        //            accesoABDSuperHeroe.SaveChanges();
        //        }
        //    }
        //}

        //public void BuscaYMuestraTodosLosSuperHeroesSanitario()
        //{
        //    List<SuperHeroeDTO> sanitarioLista = ListaSuperHeroeDTO.Where(x => x.ToString().Contains("SanitarioDTO")).ToList();
        //    if (sanitarioLista.Count() == 0)
        //    {
        //        Console.WriteLine("No hay SuperHeroes disponibles");
        //    }

        //    foreach (SanitarioDTO elemento in sanitarioLista)
        //    {
        //        elemento.MostrarPorPantalla();
        //        Console.WriteLine();
        //    }
        //}
        //public void BuscaYMuestraTodosLosSuperHeroesBombero()
        //{
        //    List<SuperHeroeDTO> bomberoLista = ListaSuperHeroeDTO.Where(x => x.ToString().Contains("BomberoDTO")).ToList();
        //    if (bomberoLista.Count() == 0)
        //    {
        //        Console.WriteLine("No hay SuperHeroes disponibles");
        //    }

        //    foreach (BomberoDTO elemento in bomberoLista)
        //    {
        //        elemento.MostrarPorPantalla();
        //        Console.WriteLine();
        //    }
        //}
        //public void BuscaYMuestraSanitarioPorNombre()
        //{

        //    Console.Write("Nombre del sanitario que desea buscar: ");
        //    string nombreABuscar = Console.ReadLine();
        //    bool encontrado = false;
        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "SanitarioDTO" && ((SanitarioDTO)elemento).nombre == nombreABuscar)
        //        {
        //            encontrado = true;
        //            elemento.MostrarPorPantalla();
        //        }
        //    }
        //    if (encontrado == false)
        //    {
        //        Console.WriteLine("Nombre no encontrado");
        //    }
        //}

        //public void BuscaYMuestraBomberoPorNombre()
        //{
        //    Console.Write("Nombre del bombero que desea buscar: ");
        //    string nombreABuscar = Console.ReadLine();
        //    bool encontrado = false;
        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "BomberoDTO" && ((BomberoDTO)elemento).nombre == nombreABuscar)
        //        {
        //            encontrado = true;
        //            elemento.MostrarPorPantalla();
        //        }
        //    }
        //    if (encontrado == false)
        //    {
        //        Console.WriteLine("Nombre no encontrado");
        //    }
        //}


        //public void MenuSuperHumanos()

        //{
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("-------------SUPER HUMANOS--------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine(" 1 - Crear nuevo Heroe de Marvel");
        //    Console.WriteLine(" 2 - Crear nuevo Heroe de DC");
        //    Console.WriteLine(" 3 - Modificar un Heroe de Marvel por nombre");
        //    Console.WriteLine(" 4 - Modificar un Heroe de DC por nombre");
        //    Console.WriteLine(" 5 - Mostrar todas los Heroes de Marvel");
        //    Console.WriteLine(" 6 - Mostrar todas los Heroes de DC");
        //    Console.WriteLine(" 7 - Muestra Heroe de Marvel por nombre");
        //    Console.WriteLine(" 8 - Muestra Heroe de DC por nombre");
        //    Console.WriteLine(" 9 - Salir");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("----------------------------------------");
        //    Console.Write("Seleccione una opción: ");
        //    OpcionSeleccionada = Console.ReadLine();
        //    Console.Clear();
        //}
        //public void SeleccionMenuSuperHumanos()
        //{
        //    switch (OpcionSeleccionada)
        //    {

        //        case "1":
        //            NuevoSuperHeroeMarvel();
        //            break;
        //        case "2":
        //            NuevoSuperHeroeDC();
        //            break;
        //        case "3":
        //            ModificarMarvel();
        //            break;
        //        case "4":
        //            ModificarDC();
        //            break;
        //        case "5":
        //            BuscaYMuestraTodosLosSuperHeroesMarvel();
        //            break;
        //        case "6":
        //            BuscaYMuestraTodosLosSuperHeroesDC();
        //            break;
        //        case "7":
        //            BuscaYMuestraMarvelPorNombre();
        //            break;
        //        case "8":
        //            BuscaYMuestraDCPorNombre();
        //            break;
        //        case "9":
        //            terminarMenuSuperHumanos = true;
        //            break;
        //        case "":
        //            Console.Clear();
        //            terminarMenuSuperHumanos = true;
        //            break;
        //        default:
        //            Console.WriteLine("Opción Incorrecta. Pulse cualquier tecla para volver a seleccionar opción");
        //            break;
        //    }
        //    if (OpcionSeleccionada != "")
        //    {
        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}
        //public void NuevoSuperHeroeMarvel()
        //{
        //    MarvelDTO marvelDTO = new MarvelDTO();
        //    marvelDTO.PedirPorPantalla();
        //    ListaSuperHeroeDTO.Add(marvelDTO);
        //    Marvel marvelBD = new Marvel();
        //    marvelBD.SuperHumanos = new SuperHumanos();
        //    marvelBD.SuperHumanos.SuperHeroe = new SuperHeroe();
        //    marvelBD.SuperHumanos.SuperHeroe.DNI = marvelDTO.dni;
        //    marvelBD.SuperHumanos.SuperHeroe.Nombre = marvelDTO.nombre;
        //    marvelBD.SuperHumanos.SuperHeroe.Apellidos = marvelDTO.apellidos;
        //    marvelBD.SuperHumanos.SuperHeroe.Edad = marvelDTO.edad;
        //    marvelBD.SuperHumanos.SuperHeroe.Peso = marvelDTO.peso;
        //    marvelBD.SuperHumanos.SuperHeroe.Altura = marvelDTO.altura;
        //    marvelBD.SuperHumanos.SuperHeroe.SuperPoder = marvelDTO.superPoder;
        //    marvelBD.SuperHumanos.Volar = marvelDTO.volar;
        //    marvelBD.SuperHumanos.SuperFuerza = marvelDTO.superFuerza;
        //    marvelBD.Vengadores = marvelDTO.vengadores;
        //    SuperHeroesDBEntities accesoDTO_DB = new SuperHeroesDBEntities();
        //    accesoDTO_DB.Marvel.Add(marvelBD);
        //    accesoDTO_DB.SaveChanges();
        //    Console.WriteLine();
        //}
        //public void NuevoSuperHeroeDC()
        //{
        //    DCDTO dcDTO = new DCDTO();
        //    dcDTO.PedirPorPantalla();
        //    ListaSuperHeroeDTO.Add(dcDTO);
        //    DC DCBD = new DC();
        //    DCBD.SuperHumanos = new SuperHumanos();
        //    DCBD.SuperHumanos.SuperHeroe = new SuperHeroe();
        //    DCBD.SuperHumanos.SuperHeroe.DNI = dcDTO.dni;
        //    DCBD.SuperHumanos.SuperHeroe.Nombre = dcDTO.nombre;
        //    DCBD.SuperHumanos.SuperHeroe.Apellidos = dcDTO.apellidos;
        //    DCBD.SuperHumanos.SuperHeroe.Edad = dcDTO.edad;
        //    DCBD.SuperHumanos.SuperHeroe.Peso = dcDTO.peso;
        //    DCBD.SuperHumanos.SuperHeroe.Altura = dcDTO.altura;
        //    DCBD.SuperHumanos.SuperHeroe.SuperPoder = dcDTO.superPoder;
        //    DCBD.SuperHumanos.Volar = dcDTO.volar;
        //    DCBD.SuperHumanos.SuperFuerza = dcDTO.superFuerza;
        //    DCBD.LigaDeLaJusticia = dcDTO.ligaDeLaJusticia;
        //    SuperHeroesDBEntities accesoDTO_DB = new SuperHeroesDBEntities();
        //    accesoDTO_DB.DC.Add(DCBD);
        //    accesoDTO_DB.SaveChanges();
        //    Console.WriteLine();
        //}
        //public void ModificarMarvel()
        //{
        //    Console.Write("Nombre del Heroe de Marvel a modificar: ");
        //    string nombreAModificar = Console.ReadLine();


        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "MarvelDTO" && ((MarvelDTO)elemento).nombre == nombreAModificar)
        //        {

        //            SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities();
        //            SuperHeroe superHeroeAModificar = accesoABDSuperHeroe.SuperHeroe.First(x => x.Id == elemento.idSuperHeroe);

        //            Console.Write("Nuevo DNI:        ");
        //            string nuevoDNI = Console.ReadLine();
        //            elemento.dni = nuevoDNI;
        //            superHeroeAModificar.DNI = nuevoDNI;
        //            Console.Write("Nuevo Nombre:     ");
        //            string nuevoNombre = Console.ReadLine();
        //            elemento.nombre = nuevoNombre;
        //            superHeroeAModificar.Nombre = nuevoNombre;
        //            Console.Write("Nuevos Apellidos: ");
        //            string nuevoApellidos = Console.ReadLine();
        //            elemento.apellidos = nuevoApellidos;
        //            superHeroeAModificar.Apellidos = nuevoApellidos;
        //            Console.Write("Nuevo Edad:       ");
        //            int nuevoEdad = int.Parse(Console.ReadLine());
        //            elemento.edad = nuevoEdad;
        //            superHeroeAModificar.Edad = nuevoEdad;
        //            Console.Write("Nuevo Peso:       ");
        //            int nuevoPeso = int.Parse(Console.ReadLine());
        //            elemento.peso = nuevoPeso;
        //            superHeroeAModificar.Peso = nuevoPeso;
        //            Console.Write("Nuevo Altura:     ");
        //            int nuevoAltura = int.Parse(Console.ReadLine());
        //            elemento.altura = nuevoAltura;
        //            superHeroeAModificar.Altura = nuevoAltura;
        //            Console.Write("Nuevo SuperPoder: ");
        //            string nuevoSuperPoder = Console.ReadLine();
        //            elemento.superPoder = nuevoSuperPoder;
        //            superHeroeAModificar.SuperPoder = nuevoSuperPoder;
        //            Console.Write("¿Puede Volar? (Pulse s o n para Si o No): ");
        //            string volarLeido = Console.ReadLine();
        //            bool nuevoVolar;
        //            if (volarLeido == "s")
        //            {
        //                nuevoVolar = true;
        //                superHeroeAModificar.SuperHumanos.First().Volar = nuevoVolar;
        //            }
        //            else
        //            {
        //                nuevoVolar = false;
        //                superHeroeAModificar.SuperHumanos.First().Volar = nuevoVolar;
        //            }
        //            Console.Write("¿Tiene SuperFuerza? (Pulse s o n para Si o No): ");
        //            string superfuerzaLeido = Console.ReadLine();
        //            bool nuevoSuperFuerza;
        //            if (superfuerzaLeido == "s")
        //            {
        //                nuevoSuperFuerza = true;
        //                superHeroeAModificar.SuperHumanos.First().SuperFuerza = nuevoSuperFuerza;
        //            }
        //            else
        //            {
        //                nuevoSuperFuerza = false;
        //                superHeroeAModificar.SuperHumanos.First().SuperFuerza = nuevoSuperFuerza;
        //            }
        //            Console.Write("¿Pertenece a los Vengadores? (Pulse s o n para Si o No): ");
        //            string vengadorLeido = Console.ReadLine();
        //            bool nuevoVengador;
        //            if (vengadorLeido == "s")
        //            {
        //                nuevoVengador = true;
        //                superHeroeAModificar.SuperHumanos.First().Marvel.First().Vengadores = nuevoVengador;
        //            }
        //            else
        //            {
        //                nuevoVengador = false;
        //                superHeroeAModificar.SuperHumanos.First().Marvel.First().Vengadores = nuevoVengador;
        //            }
        //            accesoABDSuperHeroe.SaveChanges();
        //        }
        //    }
        //}
        //public void ModificarDC()
        //{
        //    Console.Write("Nombre del Heroe de DC a modificar: ");
        //    string nombreAModificar = Console.ReadLine();


        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "DCDTO" && ((DCDTO)elemento).nombre == nombreAModificar)
        //        {

        //            SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities();
        //            SuperHeroe superHeroeAModificar = accesoABDSuperHeroe.SuperHeroe.First(x => x.Id == elemento.idSuperHeroe);

        //            Console.Write("Nuevo DNI:        ");
        //            string nuevoDNI = Console.ReadLine();
        //            elemento.dni = nuevoDNI;
        //            superHeroeAModificar.DNI = nuevoDNI;
        //            Console.Write("Nuevo Nombre:     ");
        //            string nuevoNombre = Console.ReadLine();
        //            elemento.nombre = nuevoNombre;
        //            superHeroeAModificar.Nombre = nuevoNombre;
        //            Console.Write("Nuevos Apellidos: ");
        //            string nuevoApellidos = Console.ReadLine();
        //            elemento.apellidos = nuevoApellidos;
        //            superHeroeAModificar.Apellidos = nuevoApellidos;
        //            Console.Write("Nuevo Edad:       ");
        //            int nuevoEdad = int.Parse(Console.ReadLine());
        //            elemento.edad = nuevoEdad;
        //            superHeroeAModificar.Edad = nuevoEdad;
        //            Console.Write("Nuevo Peso:       ");
        //            int nuevoPeso = int.Parse(Console.ReadLine());
        //            elemento.peso = nuevoPeso;
        //            superHeroeAModificar.Peso = nuevoPeso;
        //            Console.Write("Nuevo Altura:     ");
        //            int nuevoAltura = int.Parse(Console.ReadLine());
        //            elemento.altura = nuevoAltura;
        //            superHeroeAModificar.Altura = nuevoAltura;
        //            Console.Write("Nuevo SuperPoder: ");
        //            string nuevoSuperPoder = Console.ReadLine();
        //            elemento.superPoder = nuevoSuperPoder;
        //            superHeroeAModificar.SuperPoder = nuevoSuperPoder;
        //            Console.Write("¿Puede Volar? (Pulse s o n para Si o No): ");
        //            string volarLeido = Console.ReadLine();
        //            bool nuevoVolar;
        //            if (volarLeido == "s")
        //            {
        //                nuevoVolar = true;
        //                superHeroeAModificar.SuperHumanos.First().Volar = nuevoVolar;
        //            }
        //            else
        //            {
        //                nuevoVolar = false;
        //                superHeroeAModificar.SuperHumanos.First().Volar = nuevoVolar;
        //            }
        //            Console.Write("¿Tiene SuperFuerza? (Pulse s o n para Si o No): ");
        //            string superfuerzaLeido = Console.ReadLine();
        //            bool nuevoSuperFuerza;
        //            if (superfuerzaLeido == "s")
        //            {
        //                nuevoSuperFuerza = true;
        //                superHeroeAModificar.SuperHumanos.First().SuperFuerza = nuevoSuperFuerza;
        //            }
        //            else
        //            {
        //                nuevoSuperFuerza = false;
        //                superHeroeAModificar.SuperHumanos.First().SuperFuerza = nuevoSuperFuerza;
        //            }
        //            Console.Write("¿Pertenece a la Liga de la Justicia? (Pulse s o n para Si o No): ");
        //            string ligaJusticiaLeido = Console.ReadLine();
        //            bool nuevoLigaJusticia;
        //            if (ligaJusticiaLeido == "s")
        //            {
        //                nuevoLigaJusticia = true;
        //                superHeroeAModificar.SuperHumanos.First().DC.First().LigaDeLaJusticia = nuevoLigaJusticia;
        //            }
        //            else
        //            {
        //                nuevoLigaJusticia = false;
        //                superHeroeAModificar.SuperHumanos.First().DC.First().LigaDeLaJusticia = nuevoLigaJusticia;
        //            }
        //            accesoABDSuperHeroe.SaveChanges();
        //        }
        //    }
        //}
        //public void BuscaYMuestraTodosLosSuperHeroesMarvel()
        //{
        //    List<SuperHeroeDTO> marvelLista = ListaSuperHeroeDTO.Where(x => x.ToString().Contains("MarvelDTO")).ToList();
        //    if (marvelLista.Count() == 0)
        //    {
        //        Console.WriteLine("No hay SuperHeroes disponibles");
        //    }

        //    foreach (MarvelDTO elemento in marvelLista)
        //    {
        //        elemento.MostrarPorPantalla();
        //        Console.WriteLine();
        //    }
        //}
        //public void BuscaYMuestraTodosLosSuperHeroesDC()
        //{
        //    List<SuperHeroeDTO> DCLista = ListaSuperHeroeDTO.Where(x => x.ToString().Contains("DCDTO")).ToList();
        //    if (DCLista.Count() == 0)
        //    {
        //        Console.WriteLine("No hay SuperHeroes disponibles");
        //    }

        //    foreach (DCDTO elemento in DCLista)
        //    {
        //        elemento.MostrarPorPantalla();
        //        Console.WriteLine();
        //    }
        //}

        //public void BuscaYMuestraMarvelPorNombre()
        //{
        //    Console.Write("Nombre del Heroe de Marvel que desea buscar: ");
        //    string nombreABuscar = Console.ReadLine();
        //    bool encontrado = false;
        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "MarvelDTO" && ((MarvelDTO)elemento).nombre == nombreABuscar)
        //        {
        //            encontrado = true;
        //            elemento.MostrarPorPantalla();
        //        }
        //    }
        //    if (encontrado == false)
        //    {
        //        Console.WriteLine("Nombre no encontrado");
        //    }
        //}
        //public void BuscaYMuestraDCPorNombre()
        //{
        //    Console.Write("Nombre del Heroe de DC que desea buscar: ");
        //    string nombreABuscar = Console.ReadLine();
        //    bool encontrado = false;
        //    foreach (SuperHeroeDTO elemento in ListaSuperHeroeDTO)
        //    {
        //        if (elemento.GetType().Name == "DCDTO" && ((DCDTO)elemento).nombre == nombreABuscar)
        //        {
        //            encontrado = true;
        //            elemento.MostrarPorPantalla();
        //        }
        //    }
        //    if (encontrado == false)
        //    {
        //        Console.WriteLine("Nombre no encontrado");
        //    }
        //}
    }
}
