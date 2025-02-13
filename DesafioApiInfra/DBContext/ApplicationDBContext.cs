using DesafioApiDomain.Entities.Funcionario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiInfra.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        #endregion

        #region DbSet
        public DbSet<FuncionarioDomain> Funcionarios { get; set; }
        #endregion
    }
}
