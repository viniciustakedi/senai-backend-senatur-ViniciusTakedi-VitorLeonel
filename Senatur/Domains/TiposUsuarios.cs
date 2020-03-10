using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senatur.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "É necessário inserir um titulo")]
        public string Titulo { get; set; }
    }
}