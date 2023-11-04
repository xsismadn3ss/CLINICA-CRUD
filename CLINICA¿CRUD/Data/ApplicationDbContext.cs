using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CLINICA_CRUD.Models;

namespace CLINICA_CRUD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CLINICA_CRUD.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.Cita> Cita { get; set; } = default!;
        public DbSet<CLINICA_CRUD.Models.RegistroMedico> RegistroMedico { get; set; } = default!;
    }
}