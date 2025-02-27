using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay.DB;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    #region Tabelas
    public DbSet<CarteiraEntity?> Carteiras { get; set; }
    public DbSet<TransferenciaEntity?> Transferencias { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarteiraEntity>()
            .HasIndex(w => new { w.CPFCNPJ, w.Email })
            .IsUnique();

        modelBuilder.Entity<CarteiraEntity>()
            .Property(t => t.SaldoConta)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<CarteiraEntity>()
            .Property(w => w.TipoUsuario)
            .HasConversion<string>();

        modelBuilder.Entity<TransferenciaEntity>()
            .HasKey(t => t.TransferenciaId);

        modelBuilder.Entity<TransferenciaEntity>()
            .HasOne(t => t.Remetente)
            .WithMany()
            .HasForeignKey(t => t.RemetenteId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transaction_Remetente");

        modelBuilder.Entity<TransferenciaEntity>()
            .Property(t => t.Valor)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<TransferenciaEntity>()
            .HasOne(t => t.Recebedor)
            .WithMany()
            .HasForeignKey(t => t.RecebedorId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transaction_Recebedor");
    }

}
