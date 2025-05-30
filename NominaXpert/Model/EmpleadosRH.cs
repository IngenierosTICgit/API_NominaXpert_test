using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaXpert.Model
{
    public class EmpleadosRH
    {
        public string matricula { get; set; }
        public string nombreEmpleado { get; set; }
        public string estatusEmpleado { get; set; }
        public string estatusContrato { get; set; }
        public int diasTrabajados { get; set; }
        public int salario { get; set; }

        //Fechas:
        public DateTime? fechainicio { get; set; }
        public DateTime? fechafin { get; set; }
    }
}
