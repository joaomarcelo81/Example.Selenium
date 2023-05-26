using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnicoArtycs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioTecnicoArtycs.Infra
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var cns = "Data Source=.\\DesafioTecnicoArtycsDB.db";//context.Configuration.GetConnectionString("DesafioTecnicoArtycsConnection");

            // connect to sqlite database
            options.UseSqlite(cns);
        
            options.EnableDetailedErrors(true);
        }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Curso>()
            // .ToTable("Cursos", t => t.ExcludeFromMigrations())
            // .HasKey(m => m.Id);

            builder
    .HasAnnotation("ProductVersion", "1.1.1");

            builder.Entity("DesafioTecnicoArtycs.Domain.Entities.Curso", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.HasKey("Id");

                b.ToTable("Cursos");
            });



            base.OnModelCreating(builder);
        }


    }
}
