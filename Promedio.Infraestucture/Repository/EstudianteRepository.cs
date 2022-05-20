using Promedio.Domain.Entities;
using Promedio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promedio.Infraestucture.Repository
{
    public class EstudianteRepository : Iestudiante
    {
        public IDbContext dbContext;
        public EstudianteRepository(IDbContext context)
        {
            this.dbContext = context;
        }

        public double calculopromedio(Estudiante estudiante)
        {
            double promedio = estudiante.Matematica + estudiante.Programacion + estudiante.Contabilidad + estudiante.Estadistica / 4;
            return promedio;
        }

        public void Create(Estudiante t)
        {
            try
            {
                dbContext.estudiantes.Add(t);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentException("Object null");
                }
                Estudiante estudiante = FinById(t.Id);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto asset con id {t.Id} no existe.");
                }
                dbContext.estudiantes.Remove(estudiante);
                int result = dbContext.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Estudiante FinById(int id)
        {
            try
            {

                if (id <= 0)
                {
                    throw new Exception($"El id{id} no puede ser igual a cero");
                }
                return dbContext.estudiantes.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Estudiante FindByCarnet(string carnet)
        {
            try
            {
                if (carnet == null)
                {
                    throw new ArgumentException($"El carnet {carnet} no puede esta vacio");
                }
                return dbContext.estudiantes.FirstOrDefault(x => x.Carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estudiante> GetAll()
        {
            return dbContext.estudiantes.ToList();
        }

        public int Update(Estudiante t)
        {
            try
            {

                if (t == null)
                {
                    throw new ArgumentNullException("El objeto asset no puede ser null.");
                }
                Estudiante estudiante = FinById(t.Id);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto asset con id {t.Id} no existe.");
                }
                estudiante.Id = t.Id;
                estudiante.Nombres = t.Nombres;
                estudiante.Phone = t.Phone;
                estudiante.Apellidos = t.Apellidos;
                estudiante.Carnet = t.Carnet;
                estudiante.Correo = t.Correo;
                estudiante.Direccion = t.Direccion;
                estudiante.Contabilidad = t.Contabilidad;
                estudiante.Estadistica = t.Estadistica;
                estudiante.Matematica = t.Matematica;
                estudiante.Programacion = t.Programacion;
                dbContext.estudiantes.Update(estudiante);
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            

        }
    }
}
