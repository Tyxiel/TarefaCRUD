using System;
using Microsoft.EntityFrameworkCore;

namespace TarefaCRUD.Models
{
    public partial class TarefaDBContext : DbContext
    {
        public TarefaDBContext()
        {
        }

        public TarefaDBContext(DbContextOptions<TarefaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Tarefa> Tarefas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa);

                entity.ToTable("Pessoa");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.NomePessoa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomePessoa");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.HasKey(e => e.IdTarefa);

                entity.ToTable("Tarefa");

                entity.Property(e => e.IdTarefa).HasColumnName("idTarefa");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .IsRequired()
                    .HasColumnName("dataInicio");

                entity.Property(e => e.Prazo)
                    .HasColumnType("date") 
                    .IsRequired()
                    .HasColumnName("prazo");

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa");

                entity.Property(e => e.Prioridade)
                    .HasConversion<string>()
                    .HasMaxLength(10)
                    .IsRequired()
                    .HasColumnName("prioridade");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Tarefas)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_Tarefa_Pessoa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
