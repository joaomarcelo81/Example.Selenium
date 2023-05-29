using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioTecnicoArtycs.Infra
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        protected readonly Settings settings;

        public DataContext(Settings _settings, IConfiguration configuration)
        {
            Configuration = configuration;
            settings = _settings;

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           
            options.UseSqlite(settings.ConnectionString);
        
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

                b.Property<DateTime>("DataCadastro")
                        .HasDefaultValue(DateTime.Now);

                b.HasKey("Id");

                b.ToTable("Cursos");
            });



            base.OnModelCreating(builder);
        }


    }
}
