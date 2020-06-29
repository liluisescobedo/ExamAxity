using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamAxity.Models.Response
{
    public class ProductResponse
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; }
        public string Costo { get; set; }
        public string CantidadInventario { get; set; }
    }
}