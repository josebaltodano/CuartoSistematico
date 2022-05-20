using Promedio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promedio.Aplications.Iservices
{
    public interface IEstudianteservice : Iservices<Estudiante>
    {
        Estudiante FinById(int id);
        Estudiante FindByCarnet(string carnet);
        double calculopromedio(Estudiante estudiante);
    }
}
