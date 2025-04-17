using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefaCRUD.Models
{
    public enum PrioridadeEnum
    {
        Alta,
        Media,
        Baixa
    }

    public partial class Tarefa : IValidatableObject
    {
        [Key]
        public int IdTarefa { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(250, ErrorMessage = "A descrição não pode ter mais que 250 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }

        [Required(ErrorMessage = "O prazo é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime? Prazo { get; set; }

        public int? IdPessoa { get; set; }

        [ForeignKey("IdPessoa")]
        public virtual Pessoa? IdPessoaNavigation { get; set; }

        [Required(ErrorMessage = "A prioridade é obrigatória.")]
        public PrioridadeEnum? Prioridade { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataInicio.HasValue && Prazo.HasValue)
            {
                if (Prazo.Value < DataInicio.Value)
                {
                    yield return new ValidationResult(
                        "O prazo deve ser uma data posterior à data de início.",
                        new[] { nameof(Prazo), nameof(DataInicio) }
                    );
                }
            }

            if (!Prioridade.HasValue)
            {
                yield return new ValidationResult(
                    "A prioridade é obrigatória.",
                    new[] { nameof(Prioridade) }
                );
            }
        }
    }
}
