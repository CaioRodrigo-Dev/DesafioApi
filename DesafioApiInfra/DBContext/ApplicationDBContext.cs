using DesafioApiDomain.Funcionario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioApiInfra.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        #region Constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {
        }
        #endregion

        #region DbSet
        public DbSet<FuncionarioDomain> Funcionarios { get; set; }
        #endregion
    }
}
