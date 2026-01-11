using AspNetCoreVotaciones2026.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreVotaciones2026.Data
{
    public class VotacionesDbContext : DbContext
    {
        public VotacionesDbContext(DbContextOptions<VotacionesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Votante> Votantes { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }
    }
}
