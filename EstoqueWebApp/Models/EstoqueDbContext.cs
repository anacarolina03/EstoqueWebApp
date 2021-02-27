using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EstoqueWebApp.Models
{
    public partial class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext()
        {
        }

        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=estoque;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProduto);

                entity.ToTable("PRODUTO");

                entity.Property(e => e.CodProduto).HasColumnName("cod_produto");

                entity.Property(e => e.CodTipoProduto).HasColumnName("cod_tipo_produto");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_cadastro");

                entity.Property(e => e.DataLancamento)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_lancamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("txt_descricao");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("txt_marca");

                entity.Property(e => e.Preco).HasColumnName("vlr_preco");

                entity.HasOne(d => d.TipoProduto)
                    //.WithMany(p => p.Produtos)
                    .WithMany()
                    .HasForeignKey(d => d.CodTipoProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_tipo_produto");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.CodTipoProduto);

                entity.ToTable("TIPO_PRODUTO");

                entity.Property(e => e.CodTipoProduto).HasColumnName("cod_tipo_produto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("txt_descricao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodCliente);

                entity.ToTable("USUARIO");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("senha");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("txt_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
