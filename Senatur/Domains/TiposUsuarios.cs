using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senatur.Domains
{
    [Table("TiposUsuarios")] //Define o nome da table
    public class TiposUsuarios
    {
        [Key] //Define que é uma chave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Indica que é Identity
        public  int IdTipoUsuario { get; set; } //Define o nome do Id

        [Column(TypeName = "VARCHAR(255)")] //Define uma coluna, de datatype VARCHAR
        //Indica que se o campo estiver vazio ele precisa ser preenchido por algum motivo indicado pela mensagem 
        [Required(ErrorMessage = "É necessário inserir um titulo")]
        public string Titulo { get; set; } //Define o nome da coluna
    }
}