using DesafioApiDomain.Entities.Funcionario;
using DesafioApiDTO.Request;
using DesafioApiDTO.Response;
using DesafioApiInfra.Repository.Interfaces;
using DesafioApiService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiService.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        #region Fields
        private readonly IFuncionarioRepository _funcionarioRepository;
        #endregion

        #region Constructor
     public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        #endregion

        #region Methods

        public async Task<FuncionarioDomain> CreateFuncionario(CreateFuncionarioRequestDTO request)
        {
            if (await _funcionarioRepository.ExistingDocumentAsync(request.Cpf))
                throw new Exception("Já existe um funcionário com este documento.");

            var funcionario = new FuncionarioDomain
            {
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Email = request.Email,
                Cpf = request.Cpf,
                Telefones = request.Telefones,
                NomeGestor = request.NomeGestor,
                Senha = request.Senha 
            };

            return await _funcionarioRepository.AddAsync(funcionario);
        }

        public async Task<FuncionarioDomain?> GetById(int id)
        {
            try
            {

                var funcionario = await _funcionarioRepository.GetByIdAsync(id);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar funcionario com o ID {id}: {ex.Message}");
            }
        }

        public async Task<List<FuncionarioDomain>> GetAllFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioRepository.GetAllAsync();
                return funcionarios ?? new List<FuncionarioDomain>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncionarioDomain> UpdateFuncionario(int id, UpdateFuncionarioRequestDTO request)
        {
            try
            {
                var funcionario = await _funcionarioRepository.GetByIdAsync(id);
                if (funcionario == null)
                {
                    throw new Exception($"Funcionario com o Id {id} não foi localizado.");
                }

                funcionario.Nome = request.Nome;
                funcionario.Sobrenome = request.Sobrenome;
                funcionario.Email = request.Email;
                funcionario.Telefones = request.Telefones;
                funcionario.NomeGestor = request.NomeGestor;

                
                await _funcionarioRepository.UpdateAsync(funcionario);

                
                return funcionario;
            }
            catch (Exception ex)
            {   
                throw new Exception($"Erro ao atualizar o funcionário: {ex.Message}");
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var funcionario = await _funcionarioRepository.RemoveAsync(id);
                if (!funcionario)
                {
                    throw new Exception($"Funcionario com Id {id} não foi encontrado ou nao pode ser deletado.");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar funcionario : {ex.Message}");
            }
        }

        #endregion
    }
}
