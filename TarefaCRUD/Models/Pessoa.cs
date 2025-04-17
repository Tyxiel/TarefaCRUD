using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TarefaCRUD.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Tarefas = new HashSet<Tarefa>();
        }

        [Key]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string? NomePessoa { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string? Email { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
