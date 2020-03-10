using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senatur.Domains
{
    [Table("Usuarios")] //Define o nome da table
    public class Usuarios
    {
        [Key] //Define que é uma chave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Indica que é Identity
        public int IdUsuario { get; set; }  //Define o nome do Id

        [Column(TypeName = "VARCHAR(255)")] //Define uma coluna, de datatype VARCHAR 
        //Indica que se o campo estiver vazio ele precisa ser preenchido por algum motivo indicado pela mensagem
        [Required(ErrorMessage = "É obrigatório informar o Email")] 
        public string Email { get; set; } //Define o nome da coluna

        [Column(TypeName = "VARCHAR(255)")] //Define uma coluna, de datatype VARCHAR 
        //Indica que se o campo estiver vazio ele precisa ser preenchido por algum motivo indicado pela mensagem
        [Required(ErrorMessage = "É obrigatório informar o Senha")] 
        public string Senha { get; set; } //Define o nome da coluna
        
        //Indica que se o campo estiver vazio ele precisa ser preenchido por algum motivo indicado pela mensagem
        [Required(ErrorMessage = "É necessário informar o tipo de usuario")] 
        public int IdTipoUsuario { get; set; } //Define o nome da coluna

        [ForeignKey("IdTipoUsuario")] //Indica e define que ele será uma chave estrangeira
        public TiposUsuarios TipoUsuario { get; set; } //Define o nome da coluna
    }
}