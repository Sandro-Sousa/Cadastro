namespace cadastro.service.DTOs
{
  public class TelefoneDTOInsert
  {
    public int TelefoneId { get; set; }
    public int ClienteId { get; set; }
    public string Ddd { get; set; }
    public string Numero { get; set; }

  }
}
