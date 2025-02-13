using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiDTO.Request
{
    public class UpdateFuncionarioRequestDTO
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public int Idade { get; set; }

        public List<string> Telefones { get; set; }

        public string? NomeGestor { get; set; }
    }
}
