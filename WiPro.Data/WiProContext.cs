using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using WiPro.Domain.Entity;

namespace WiPro.Data
{
    public class WiProContext :  DbContext
    {
        private static IConfiguration _configuration { get; set; }
        
        public WiProContext(DbContextOptions<WiProContext> options) : base (options){}
        
        public WiProContext()
        {}

        public DbSet<Coin> Coin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbWiPro;Data Source=.\\sqlexpress");
        }
    }
}