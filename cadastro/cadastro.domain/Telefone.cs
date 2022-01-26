using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro.domain.Entities
{
  public class Telefone
  {
    public int ClienteId { get; set; }
    public string Ddd { get; set; }
    public string Numero { get; set; }
  }
}
