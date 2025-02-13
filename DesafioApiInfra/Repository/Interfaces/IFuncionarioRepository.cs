using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioApiDomain.Entities.Funcionario;

namespace DesafioApiInfra.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<FuncionarioDomain> AddAsync(FuncionarioDomain funcionario);
        Task<FuncionarioDomain?> GetByIdAsync(int id);
        Task<List<FuncionarioDomain>> GetAllAsync();
        Task<FuncionarioDomain?> UpdateAsync(FuncionarioDomain funcionario);
        Task<bool> RemoveAsync(int id);
        Task<bool> ExistingDocumentAsync(string documento);
    }
}
