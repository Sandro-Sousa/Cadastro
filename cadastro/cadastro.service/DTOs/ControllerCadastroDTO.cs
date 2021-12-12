namespace cadastro.service.DTOs
{
    public class ControllerCadastroDTO
    {
        public class ClienteDTO
        {
            public int idCliente { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
        }

        public class ClienteDTOInsert
        {
            public string Nome { get; set; }
            public string Cpf { get; set; }
        }

        public class EnderecoDTO
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
        }

        public class TelefoneDTO
        {
            public string Telefone { get; set; }
        }
    }
}
