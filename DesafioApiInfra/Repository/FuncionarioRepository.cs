using DesafioApiDomain.Entities.Funcionario;
using DesafioApiInfra.DBContext;
using DesafioApiInfra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiInfra.Repository
{
 
    public class FuncionarioRepository : IFuncionarioRepository
    {
        #region Fiels
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<FuncionarioDomain> AddAsync(FuncionarioDomain funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<bool> ExistingDocumentAsync(string cpf)
        {
            return await _context.Funcionarios.AnyAsync(x => x.Cpf == cpf);
        }

        public async Task<List<FuncionarioDomain>> GetAllAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<FuncionarioDomain?> GetByIdAsync(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return false;
            }
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FuncionarioDomain?> UpdateAsync(FuncionarioDomain funcionario)
        {
            var existingFuncionario = await _context.Funcionarios.FindAsync(funcionario.Id);
            if (existingFuncionario == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }
    }
    #endregion
}
