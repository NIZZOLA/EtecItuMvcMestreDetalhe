using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.AulaEtec.Models;

namespace MVC.AulaEtec.Data
{
    public class MVCAulaEtecContext : DbContext
    {
        public MVCAulaEtecContext (DbContextOptions<MVCAulaEtecContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.AulaEtec.Models.ClienteModel> ClienteModel { get; set; }

        public DbSet<MVC.AulaEtec.Models.ClienteEnderecoModel> ClienteEnderecoModel { get; set; }
    }
}
