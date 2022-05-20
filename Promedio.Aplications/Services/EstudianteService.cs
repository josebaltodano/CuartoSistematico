using Promedio.Aplications.Iservices;
using Promedio.Domain.Entities;
using Promedio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promedio.Aplications.Services
{
    public class EstudianteService : IEstudianteservice
    {
        public Iestudiante iestudiante;
        public EstudianteService (Iestudiante iestudiante)
        {
            this.iestudiante = iestudiante;
        }

        public double calculopromedio(Estudiante estudiante)
        {
            return this.iestudiante.calculopromedio(estudiante);
        }

        public void Create(Estudiante t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("El objeto no puede ser null.");
            }
            iestudiante.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            return iestudiante.Delete(t);
        }

        public Estudiante FinById(int id)
        {
            return iestudiante.FinById(id);
        }

        public Estudiante FindByCarnet(string carnet)
        {
            return iestudiante.FindByCarnet(carnet);
        }

        public List<Estudiante> GetAll()
        {
            return iestudiante.GetAll();
        }

        public int Update(Estudiante t)
        {
            return iestudiante.Update(t);
        }
    }
}
