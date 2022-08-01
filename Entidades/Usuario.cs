using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(14)]
        public string? Cpf { get; set; }
        [StringLength(14)]
        public string? Rg { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}