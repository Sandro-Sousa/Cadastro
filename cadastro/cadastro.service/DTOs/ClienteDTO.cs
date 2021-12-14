using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro.service.DTOs
{
   public class ClienteDTO
    {
        public int idCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
