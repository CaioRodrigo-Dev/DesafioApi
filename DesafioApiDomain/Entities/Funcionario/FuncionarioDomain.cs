using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiDomain.Entities.Funcionario
{
    public class FuncionarioDomain
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public int Idade { get; set; }

        public List<string> Telefones { get; set; }

        public string? NomeGestor { get; set; }

        [Required]
        public string Senha { get; set; }
    }

}

