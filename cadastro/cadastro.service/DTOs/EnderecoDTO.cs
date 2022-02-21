using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro.service.DTOs
{
  public class EnderecoDTO
  {
    public int EnderecoId { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public int ClienteId { get; set; }
  }
}
