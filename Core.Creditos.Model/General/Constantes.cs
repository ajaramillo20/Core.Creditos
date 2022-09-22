
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.General
{
    public static class MensajesError
    {
        public static string CATALOGO_NO_ENCONTRADO(string codigoCatalogo = "")
        {
            return $"Catalogo {codigoCatalogo} no existe";
        }

        public static string VALOR_INGRESOS_INCORRECTO(string ingreso = "")
        {
            return $"El valor {ingreso} no es un número";
        }

        public static string DEUDOR_NO_CUMPLE_POLITICA_EDAD(string edad="")
        {
            return $"Edad del deudor no cumple con la politica";
        }
    }
}
