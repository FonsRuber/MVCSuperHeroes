using MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe;
using MVCSuperHeroes.Z_Capa3_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSuperHeroes.Z_Capa2_Servicios.Persistance
{
    class OperacionesBD
    {
        #region Operaciones sobre la tabla SuperHeroes
        public void GetListaSuperHeroesDesdeBD(List<SuperHeroeDTO> listaSuperHeroes)
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                MapeoBD_DTO_Por_Sanitarios(GetListaSanitariosSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                MapeoBD_DTO_Por_Bomberos(GetListaBomberosSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                MapeoBD_DTO_Por_Marvels(GetListaMarvelsSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                MapeoBD_DTO_Por_DCs(GetListaDCsSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
            }
        }
        public void MapeoBD_DTO_Por_SuperHeroes(List<SuperHeroe> lista, List<SuperHeroeDTO> listaFinalDTOs)
        {
            foreach (SuperHeroe elemento in lista)
            {
                // si es un Sanitario
                if (elemento.ProfesionesHeroicas.First().Sanitario.Count == 1)
                {
                    SanitarioDTO nuevoSanitario = new SanitarioDTO();
                    Mapeo_Sanitario_SanitarioDTO(elemento.ProfesionesHeroicas.First().Sanitario.First(), nuevoSanitario);
                    listaFinalDTOs.Add(nuevoSanitario);
                }
                // si es un Bombero
                if (elemento.ProfesionesHeroicas.First().Sanitario.Count == 1)
                {
                    BomberoDTO nuevoBombero = new BomberoDTO();
                    Mapeo_Bombero_BomberoDTO(elemento.ProfesionesHeroicas.First().Bombero.First(), nuevoBombero);
                    listaFinalDTOs.Add(nuevoBombero);
                }
            }
        }
        //public void BorrSuperHeroeEnBD(SuperHeroeDTO dtoAModificar)
        //{
        //    using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
        //    {
        //        SuperHeroe superHeroeABorrar = accesoABDSuperHeroe.SuperHeroe.Find(dtoAModificar.idSuperHeroe);

        //        // esto es para el borrado lógico
        //        superHeroeABorrar.Borrado = true;

        //        // esto es para el borrado físico
        //        //if (personajeABorrar.Piratas.Count == 1)
        //        //{
        //        //    accesoABDOnePiece.Piratas.Remove(personajeABorrar.Piratas.First());
        //        //}
        //        //if (personajeABorrar.Marines.Count == 1)
        //        //{
        //        //    accesoABDOnePiece.Marines.Remove(personajeABorrar.Marines.First());
        //        //}
        //        //accesoABDOnePiece.Personajes.Remove(personajeABorrar);

        //        accesoABDSuperHeroe.SaveChanges();
        //    }
        //}
        public void BorraSuperHeroeEnBDById(long IdABorrar)
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                SuperHeroe superHeroeABorrar = accesoABDSuperHeroe.SuperHeroe.Find(IdABorrar);

                // esto es para el borrado lógico
                superHeroeABorrar.Borrado = true;

                accesoABDSuperHeroe.SaveChanges();
            }
        }
        #endregion
        #region Operaciones sobre la tabla Sanitarios

        public List<Sanitario> GetListaSanitariosSinBorrados(SuperHeroesDBEntities accesoABDSuperHeroe)
        {
            List<Sanitario> listadevuelta = accesoABDSuperHeroe.Sanitario.Where(x => x.ProfesionesHeroicas.SuperHeroe.Borrado == false).ToList();
            return listadevuelta;
        }
        public List<SanitarioDTO> GetListaSanitariosDesdeBD()
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                List<SuperHeroeDTO> listaSuperHeroes = new List<SuperHeroeDTO>();
                MapeoBD_DTO_Por_Sanitarios(GetListaSanitariosSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                return listaSuperHeroes.OfType<SanitarioDTO>().ToList();
            }
        }
        public void MapeoBD_DTO_Por_Sanitarios(List<Sanitario> listaSanitarios, List<SuperHeroeDTO> listaFinalDTOs)
        {
            foreach (Sanitario sanitarioBD in listaSanitarios)
            {
                SanitarioDTO nuevoSanitarioDto = new SanitarioDTO();
                Mapeo_Sanitario_SanitarioDTO(sanitarioBD, nuevoSanitarioDto);
                listaFinalDTOs.Add(nuevoSanitarioDto);
            }
        }
        public void Mapeo_Sanitario_SanitarioDTO(Sanitario SanitariosEntityAMapear, SanitarioDTO sanitarioDto)
        {
            sanitarioDto.idSuperHeroe = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Id;
            sanitarioDto.dni = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.DNI;
            sanitarioDto.nombre = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Nombre;
            sanitarioDto.apellidos = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Apellidos;
            sanitarioDto.edad = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Edad;
            sanitarioDto.peso = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Peso;
            sanitarioDto.altura = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Altura;
            sanitarioDto.superPoder = SanitariosEntityAMapear.ProfesionesHeroicas.SuperHeroe.SuperPoder;
            sanitarioDto.valor = SanitariosEntityAMapear.ProfesionesHeroicas.Valor;
            sanitarioDto.salario = SanitariosEntityAMapear.ProfesionesHeroicas.Salario;
            sanitarioDto.curar = SanitariosEntityAMapear.Curar;
        }
        public void Mapeo_SanitarioDTO_Sanitario(SanitarioDTO sanitarioDtoAMapear, Sanitario sanitarioBD)
        {
            sanitarioBD.SuperHeroes.Id = sanitarioDtoAMapear.idSuperHeroe;
            sanitarioBD.SuperHeroes.DNI = sanitarioDtoAMapear.dni;
            sanitarioBD.SuperHeroes.Nombre = sanitarioDtoAMapear.nombre;
            sanitarioBD.SuperHeroes.Apellidos = sanitarioDtoAMapear.apellidos;
            sanitarioBD.SuperHeroes.Edad = sanitarioDtoAMapear.edad;
            sanitarioBD.SuperHeroes.Peso = sanitarioDtoAMapear.peso;
            sanitarioBD.SuperHeroes.Altura = sanitarioDtoAMapear.altura;
            sanitarioBD.SuperHeroes.SuperPoder = sanitarioDtoAMapear.superPoder;
            //sanitarioBD.ProfesionesHeroicas.Valor = sanitarioDtoAMapear.valor;
            //sanitarioBD.ProfesionesHeroicas.Salario = sanitarioDtoAMapear.salario;
            sanitarioBD.Curar = sanitarioDtoAMapear.curar;  
        }
        public void Mapeo_SanitarioDTO_Sanitario_Edit(SanitarioDTO sanitarioDtoAMapear, Sanitario sanitarioBD)
        {
            sanitarioBD.ProfesionesHeroicas.SuperHeroe.Id = sanitarioDtoAMapear.idSuperHeroe;
            sanitarioBD.ProfesionesHeroicas.SuperHeroe.SuperPoder = sanitarioDtoAMapear.superPoder;
            sanitarioBD.ProfesionesHeroicas.Valor = sanitarioDtoAMapear.valor;
            sanitarioBD.ProfesionesHeroicas.Salario = sanitarioDtoAMapear.salario;
            sanitarioBD.Curar = sanitarioDtoAMapear.curar;
        }
        public void InsertarNuevoSanitario(SanitarioDTO nuevoSanitarioDto)
        {
            Sanitario nuevoSanitarioBD = new Sanitario();
            nuevoSanitarioBD.SuperHeroes = new SuperHeroe();

            Mapeo_SanitarioDTO_Sanitario(nuevoSanitarioDto, nuevoSanitarioBD);

            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                accesoABDSuperHeroe.Sanitario.Add(nuevoSanitarioBD);
                accesoABDSuperHeroe.SaveChanges();
            }
        }
        public SanitarioDTO GetSanitarioPorNombre(string nombre)
        {
            SanitarioDTO sanitario = GetListaSanitariosDesdeBD().FirstOrDefault(x => x.nombre.ToLower().Contains(nombre.ToLower()));
            if (sanitario == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return sanitario;
        }
        public SanitarioDTO GetSanitarioPorId(long id)
        {
            SanitarioDTO sanitario = GetListaSanitariosDesdeBD().FirstOrDefault(x => x.idSuperHeroe == id);
            if (sanitario == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return sanitario;
        }
        public List<SanitarioDTO> GetSanitariosQuePuedenCurar(string nombreTripulacion)
        {
            return GetListaSanitariosDesdeBD().Where(x => x.curar == true).ToList();
        }
        public void ModificarSanitarioEnBD(SanitarioDTO dtoAModificar)
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                Sanitario sanitarioAModificar = accesoABDSuperHeroe.Sanitario.FirstOrDefault(x => x.IdProfesionesHeroicas == dtoAModificar.idSuperHeroe);

                Mapeo_SanitarioDTO_Sanitario_Edit(dtoAModificar, sanitarioAModificar);

                accesoABDSuperHeroe.SaveChanges();
            }
        }
        #endregion

        #region Operaciones sobre la tabla Bomberos

        public List<Bombero> GetListaBomberosSinBorrados(SuperHeroesDBEntities accesoABDSuperHeroe)
        {
            List<Bombero> listadevuelta = accesoABDSuperHeroe.Bombero.Where(x => x.ProfesionesHeroicas.SuperHeroe.Borrado == false).ToList();
            return listadevuelta;
        }
        public List<BomberoDTO> GetListaBomberosDesdeBD()
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                List<SuperHeroeDTO> listaSuperHeroes = new List<SuperHeroeDTO>();
                MapeoBD_DTO_Por_Bomberos(GetListaBomberosSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                return listaSuperHeroes.OfType<BomberoDTO>().ToList();
            }
        }
        public void MapeoBD_DTO_Por_Bomberos(List<Bombero> listaBomberos, List<SuperHeroeDTO> listaFinalDTOs)
        {
            foreach (Bombero bomberoBD in listaBomberos)
            {
                BomberoDTO nuevoBomberoDto = new BomberoDTO();
                Mapeo_Bombero_BomberoDTO(bomberoBD, nuevoBomberoDto);
                listaFinalDTOs.Add(nuevoBomberoDto);
            }
        }
        public void Mapeo_Bombero_BomberoDTO(Bombero BomberosEntityAMapear, BomberoDTO bomberoDto)
        {
            bomberoDto.idSuperHeroe = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Id;
            bomberoDto.dni = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.DNI;
            bomberoDto.nombre = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Nombre;
            bomberoDto.apellidos = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Apellidos;
            bomberoDto.edad = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Edad;
            bomberoDto.peso = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Peso;
            bomberoDto.altura = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.Altura;
            bomberoDto.superPoder = BomberosEntityAMapear.ProfesionesHeroicas.SuperHeroe.SuperPoder;
            bomberoDto.valor = BomberosEntityAMapear.ProfesionesHeroicas.Valor;
            bomberoDto.salario = BomberosEntityAMapear.ProfesionesHeroicas.Salario;
            bomberoDto.apagarFuego = BomberosEntityAMapear.ApagarFuego;
        }
        public void Mapeo_BomberoDTO_Bombero(BomberoDTO bomberoDtoAMapear, Bombero bomberoBD)
        {
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Id = bomberoDtoAMapear.idSuperHeroe;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.DNI = bomberoDtoAMapear.dni;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Nombre = bomberoDtoAMapear.nombre;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Apellidos = bomberoDtoAMapear.apellidos;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Edad = bomberoDtoAMapear.edad;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Peso = bomberoDtoAMapear.peso;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Altura = bomberoDtoAMapear.altura;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.SuperPoder = bomberoDtoAMapear.superPoder;
            bomberoBD.ProfesionesHeroicas.Valor = bomberoDtoAMapear.valor;
            bomberoBD.ProfesionesHeroicas.Salario = bomberoDtoAMapear.salario;
            bomberoBD.ApagarFuego = bomberoDtoAMapear.apagarFuego;
        }
        public void Mapeo_BomberoDTO_Bombero_Edit(BomberoDTO bomberoDtoAMapear, Bombero bomberoBD)
        {
            bomberoBD.ProfesionesHeroicas.SuperHeroe.Id = bomberoDtoAMapear.idSuperHeroe;
            bomberoBD.ProfesionesHeroicas.SuperHeroe.SuperPoder = bomberoDtoAMapear.superPoder;
            bomberoBD.ProfesionesHeroicas.Valor = bomberoDtoAMapear.valor;
            bomberoBD.ProfesionesHeroicas.Salario = bomberoDtoAMapear.salario;
            bomberoBD.ApagarFuego = bomberoDtoAMapear.apagarFuego;
        }
        public void InsertarNuevoBombero(BomberoDTO nuevoBomberoDto)
        {
            Bombero nuevoBomberoBD = new Bombero();
            nuevoBomberoBD.ProfesionesHeroicas.SuperHeroe = new SuperHeroe();

            Mapeo_BomberoDTO_Bombero(nuevoBomberoDto, nuevoBomberoBD);

            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                accesoABDSuperHeroe.Bombero.Add(nuevoBomberoBD);
                accesoABDSuperHeroe.SaveChanges();
            }
        }
        public BomberoDTO GetBomberoPorNombre(string nombre)
        {
            BomberoDTO bombero = GetListaBomberosDesdeBD().FirstOrDefault(x => x.nombre.ToLower().Contains(nombre.ToLower()));
            if (bombero == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return bombero;
        }
        public BomberoDTO GetBomberoPorId(long id)
        {
            BomberoDTO bombero = GetListaBomberosDesdeBD().FirstOrDefault(x => x.idSuperHeroe == id);
            if (bombero == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return bombero;
        }
        public List<BomberoDTO> GetBomberosQuePuedenApagarFuego(string nombreTripulacion)
        {
            return GetListaBomberosDesdeBD().Where(x => x.apagarFuego == true).ToList();
        }
        public void ModificarBomberoEnBD(BomberoDTO dtoAModificar)
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                Bombero bomberoAModificar = accesoABDSuperHeroe.Bombero.FirstOrDefault(x => x.IdProfesionesHeroicas == dtoAModificar.idSuperHeroe);

                Mapeo_BomberoDTO_Bombero_Edit(dtoAModificar, bomberoAModificar);

                accesoABDSuperHeroe.SaveChanges();
            }
        }
        #endregion
        #region Operaciones sobre la tabla Marvel

        public List<Marvel> GetListaMarvelsSinBorrados(SuperHeroesDBEntities accesoABDSuperHeroe)
        {
            List<Marvel> listadevuelta = accesoABDSuperHeroe.Marvel.Where(x => x.SuperHumanos.SuperHeroe.Borrado == false).ToList();
            return listadevuelta;
        }
        public List<MarvelDTO> GetListaMarvelsDesdeBD()
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                List<SuperHeroeDTO> listaSuperHeroes = new List<SuperHeroeDTO>();
                MapeoBD_DTO_Por_Marvels(GetListaMarvelsSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                return listaSuperHeroes.OfType<MarvelDTO>().ToList();
            }
        }
        public void MapeoBD_DTO_Por_Marvels(List<Marvel> listaMarvel, List<SuperHeroeDTO> listaFinalDTOs)
        {
            foreach (Marvel marvelBD in listaMarvel)
            {
                MarvelDTO nuevoMarvelDto = new MarvelDTO();
                Mapeo_Marvel_MarvelDTO(marvelBD, nuevoMarvelDto);
                listaFinalDTOs.Add(nuevoMarvelDto);
            }
        }
        public void Mapeo_Marvel_MarvelDTO(Marvel MarvelsEntityAMapear, MarvelDTO marvelDto)
        {
            marvelDto.idSuperHeroe = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.Id;
            marvelDto.dni = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.DNI;
            marvelDto.nombre = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.Nombre;
            marvelDto.apellidos = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.Apellidos;
            marvelDto.edad = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.Edad;
            marvelDto.peso = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.Peso;
            marvelDto.altura = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.Altura;
            marvelDto.superPoder = MarvelsEntityAMapear.SuperHumanos.SuperHeroe.SuperPoder;
            marvelDto.superFuerza = MarvelsEntityAMapear.SuperHumanos.SuperFuerza;
            marvelDto.volar = MarvelsEntityAMapear.SuperHumanos.Volar;
            marvelDto.vengadores = MarvelsEntityAMapear.Vengadores;
        }
        public void Mapeo_MarvelDTO_Marvel(MarvelDTO marvelDtoAMapear, Marvel marvelBD)
        {
            marvelBD.SuperHumanos.SuperHeroe.Id = marvelDtoAMapear.idSuperHeroe;
            marvelBD.SuperHumanos.SuperHeroe.DNI = marvelDtoAMapear.dni;
            marvelBD.SuperHumanos.SuperHeroe.Nombre = marvelDtoAMapear.nombre;
            marvelBD.SuperHumanos.SuperHeroe.Apellidos = marvelDtoAMapear.apellidos;
            marvelBD.SuperHumanos.SuperHeroe.Edad = marvelDtoAMapear.edad;
            marvelBD.SuperHumanos.SuperHeroe.Peso = marvelDtoAMapear.peso;
            marvelBD.SuperHumanos.SuperHeroe.Altura = marvelDtoAMapear.altura;
            marvelBD.SuperHumanos.SuperHeroe.SuperPoder = marvelDtoAMapear.superPoder;
            marvelBD.SuperHumanos.SuperFuerza = marvelDtoAMapear.superFuerza;
            marvelBD.SuperHumanos.Volar = marvelDtoAMapear.volar;
            marvelBD.Vengadores = marvelDtoAMapear.vengadores;
        }
        public void Mapeo_MarvelDTO_Marvel_Edit(MarvelDTO marvelDtoAMapear, Marvel marvelBD)
        {
            marvelBD.SuperHumanos.SuperHeroe.Id = marvelDtoAMapear.idSuperHeroe;
            marvelBD.SuperHumanos.SuperHeroe.SuperPoder = marvelDtoAMapear.superPoder;
            marvelBD.SuperHumanos.SuperFuerza = marvelDtoAMapear.superFuerza;
            marvelBD.SuperHumanos.Volar = marvelDtoAMapear.volar;
            marvelBD.Vengadores = marvelDtoAMapear.vengadores;
        }
        public void InsertarNuevoMarvel(MarvelDTO nuevoMarvelDto)
        {
            Marvel nuevoMarvelBD = new Marvel();
            nuevoMarvelBD.SuperHumanos.SuperHeroe = new SuperHeroe();

            Mapeo_MarvelDTO_Marvel(nuevoMarvelDto, nuevoMarvelBD);

            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                accesoABDSuperHeroe.Marvel.Add(nuevoMarvelBD);
                accesoABDSuperHeroe.SaveChanges();
            }
        }
        public MarvelDTO GetMarvelPorNombre(string nombre)
        {
            MarvelDTO marvel = GetListaMarvelsDesdeBD().FirstOrDefault(x => x.nombre.ToLower().Contains(nombre.ToLower()));
            if (marvel == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return marvel;
        }
        public MarvelDTO GetMarvelPorId(long id)
        {
            MarvelDTO marvel = GetListaMarvelsDesdeBD().FirstOrDefault(x => x.idSuperHeroe == id);
            if (marvel == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return marvel;
        }
        public List<MarvelDTO> GetMarvelsQueSonVengadores(string nombreTripulacion)
        {
            return GetListaMarvelsDesdeBD().Where(x => x.vengadores == true).ToList();
        }
        public void ModificarMarvelEnBD(MarvelDTO dtoAModificar)
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                Marvel marvelAModificar = accesoABDSuperHeroe.Marvel.FirstOrDefault(x => x.IdSuperHumanos == dtoAModificar.idSuperHeroe);

                Mapeo_MarvelDTO_Marvel_Edit(dtoAModificar, marvelAModificar);

                accesoABDSuperHeroe.SaveChanges();
            }
        }
        #endregion

        #region Operaciones sobre la tabla DC

        public List<DC> GetListaDCsSinBorrados(SuperHeroesDBEntities accesoABDSuperHeroe)
        {
            List<DC> listadevuelta = accesoABDSuperHeroe.DC.Where(x => x.SuperHumanos.SuperHeroe.Borrado == false).ToList();
            return listadevuelta;
        }
        public List<DCDTO> GetListaDCsDesdeBD()
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                List<SuperHeroeDTO> listaSuperHeroes = new List<SuperHeroeDTO>();
                MapeoBD_DTO_Por_DCs(GetListaDCsSinBorrados(accesoABDSuperHeroe), listaSuperHeroes);
                return listaSuperHeroes.OfType<DCDTO>().ToList();
            }
        }
        public void MapeoBD_DTO_Por_DCs(List<DC> listaDC, List<SuperHeroeDTO> listaFinalDTOs)
        {
            foreach (DC DCBD in listaDC)
            {
                DCDTO nuevoDCDto = new DCDTO();
                Mapeo_DC_DCDTO(DCBD, nuevoDCDto);
                listaFinalDTOs.Add(nuevoDCDto);
            }
        }
        public void Mapeo_DC_DCDTO(DC DCsEntityAMapear, DCDTO DCDto)
        {
            DCDto.idSuperHeroe = DCsEntityAMapear.SuperHumanos.SuperHeroe.Id;
            DCDto.dni = DCsEntityAMapear.SuperHumanos.SuperHeroe.DNI;
            DCDto.nombre = DCsEntityAMapear.SuperHumanos.SuperHeroe.Nombre;
            DCDto.apellidos = DCsEntityAMapear.SuperHumanos.SuperHeroe.Apellidos;
            DCDto.edad = DCsEntityAMapear.SuperHumanos.SuperHeroe.Edad;
            DCDto.peso = DCsEntityAMapear.SuperHumanos.SuperHeroe.Peso;
            DCDto.altura = DCsEntityAMapear.SuperHumanos.SuperHeroe.Altura;
            DCDto.superPoder = DCsEntityAMapear.SuperHumanos.SuperHeroe.SuperPoder;
            DCDto.superFuerza = DCsEntityAMapear.SuperHumanos.SuperFuerza;
            DCDto.volar = DCsEntityAMapear.SuperHumanos.Volar;
            DCDto.ligaDeLaJusticia = DCsEntityAMapear.LigaDeLaJusticia;
        }
        public void Mapeo_DCDTO_DC(DCDTO DCDtoAMapear, DC DCBD)
        {
            DCBD.SuperHumanos.SuperHeroe.Id = DCDtoAMapear.idSuperHeroe;
            DCBD.SuperHumanos.SuperHeroe.DNI = DCDtoAMapear.dni;
            DCBD.SuperHumanos.SuperHeroe.Nombre = DCDtoAMapear.nombre;
            DCBD.SuperHumanos.SuperHeroe.Apellidos = DCDtoAMapear.apellidos;
            DCBD.SuperHumanos.SuperHeroe.Edad = DCDtoAMapear.edad;
            DCBD.SuperHumanos.SuperHeroe.Peso = DCDtoAMapear.peso;
            DCBD.SuperHumanos.SuperHeroe.Altura = DCDtoAMapear.altura;
            DCBD.SuperHumanos.SuperHeroe.SuperPoder = DCDtoAMapear.superPoder;
            DCBD.SuperHumanos.SuperFuerza = DCDtoAMapear.superFuerza;
            DCBD.SuperHumanos.Volar = DCDtoAMapear.volar;
            DCBD.LigaDeLaJusticia = DCDtoAMapear.ligaDeLaJusticia;
        }
        public void Mapeo_DCDTO_DC_Edit(DCDTO DCDtoAMapear, DC DCBD)
        {
            DCBD.SuperHumanos.SuperHeroe.Id = DCDtoAMapear.idSuperHeroe;
            DCBD.SuperHumanos.SuperHeroe.SuperPoder = DCDtoAMapear.superPoder;
            DCBD.SuperHumanos.SuperFuerza = DCDtoAMapear.superFuerza;
            DCBD.SuperHumanos.Volar = DCDtoAMapear.volar;
            DCBD.LigaDeLaJusticia = DCDtoAMapear.ligaDeLaJusticia;
        }
        public void InsertarNuevoDC(DCDTO nuevoDCDto)
        {
            DC nuevoDCBD = new DC();
            nuevoDCBD.SuperHumanos.SuperHeroe = new SuperHeroe();

            Mapeo_DCDTO_DC(nuevoDCDto, nuevoDCBD);

            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                accesoABDSuperHeroe.DC.Add(nuevoDCBD);
                accesoABDSuperHeroe.SaveChanges();
            }
        }
        public DCDTO GetDCPorNombre(string nombre)
        {
            DCDTO DC = GetListaDCsDesdeBD().FirstOrDefault(x => x.nombre.ToLower().Contains(nombre.ToLower()));
            if (DC == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return DC;
        }
        public DCDTO GetDCPorId(long id)
        {
            DCDTO DC = GetListaDCsDesdeBD().FirstOrDefault(x => x.idSuperHeroe == id);
            if (DC == null)
            {
                throw new NullReferenceException("El SuperHeroe solicitado no se ha encontrado");
            }
            return DC;
        }
        public List<DCDTO> GetDCsQueSonVengadores(string nombreTripulacion)
        {
            return GetListaDCsDesdeBD().Where(x => x.ligaDeLaJusticia == true).ToList();
        }
        public void ModificarDCEnBD(DCDTO dtoAModificar)
        {
            using (SuperHeroesDBEntities accesoABDSuperHeroe = new SuperHeroesDBEntities())
            {
                DC DCAModificar = accesoABDSuperHeroe.DC.FirstOrDefault(x => x.IdSuperHumanos == dtoAModificar.idSuperHeroe);

                Mapeo_DCDTO_DC_Edit(dtoAModificar, DCAModificar);

                accesoABDSuperHeroe.SaveChanges();
            }
        }
        #endregion
    }
}
