using System.ComponentModel.DataAnnotations;

namespace Professor.Models
{
    public class ProfessorModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        public string Email { get; set; }

        public string Disciplina { get; set; }
    }
}