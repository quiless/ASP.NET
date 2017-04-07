using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Padaria.Models
{
    public class pedidos
    {
        [Key]
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Produto { get; set; }
    }

}