using System;
using System.Collections.Generic;
using System.Text;

namespace PM02MVVM.Models
{
    public class Ordenes
    {
            public int ID { get; set; }
            public string NombreCliente { get; set; }
            public double MontoTotal { get; set; }
            public string Status { get; set; }
    }
}
