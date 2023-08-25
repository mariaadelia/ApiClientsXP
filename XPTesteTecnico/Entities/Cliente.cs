using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XPTesteTecnico.Entities
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [DataType(DataType.Text)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [JsonPropertyName("telefone_cel")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "CEP é obrigatório")]
        [DataType(DataType.PostalCode)]
        [JsonPropertyName("cep")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatório")]
        [DataType(DataType.Text)]
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [DataType(DataType.Text)]
        [JsonPropertyName("complemento_end")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [DataType(DataType.Text)]
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        [DataType(DataType.Text)]
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        [DataType(DataType.Text)]
        [JsonPropertyName("uf")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        [JsonPropertyName("numero_end")]
        public int Numero { get; set; }


        public Cliente() { }
    }
}
