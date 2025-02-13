using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiDTO.Response
{
   public class CreateFuncionarioResponseDTO
    {
        public bool IsCreated { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
