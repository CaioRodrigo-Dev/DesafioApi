using DesafioApiDomain.Entities.Funcionario;
using DesafioApiDTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiService.Interfaces
{
    public interface IFuncionarioService
    {
        public Task<FuncionarioDomain> CreateFuncionario(CreateFuncionarioRequestDTO funcionario);
        public Task<FuncionarioDomain?> GetById(int id);

        public Task<List<FuncionarioDomain>> GetAllFuncionarios();
        public  Task<FuncionarioDomain> UpdateFuncionario(int id, UpdateFuncionarioRequestDTO request);
        public  Task<bool> DeleteById(int id);

    }
}
