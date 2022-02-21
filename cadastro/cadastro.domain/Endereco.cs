namespace cadastro.domain.Entities
{
  public class Endereco
  {
    public int EnderecoId { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public int ClienteId { get; set; }
  }
}
