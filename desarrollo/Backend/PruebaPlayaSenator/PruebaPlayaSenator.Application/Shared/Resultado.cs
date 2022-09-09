using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPIWithEF.Application.Shared
{
    public class Resultado<T>
    {
        public string Mensaje { get; set; }
        public bool ResultadoOperacion { get; set; }
        public T Respuesta { get; set; }
        public string MensajeError {get;set;}
    }
}
