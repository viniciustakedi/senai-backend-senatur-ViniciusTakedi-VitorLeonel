using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senatur.Domains
{
    [Table("Pacotes")]
    public class Pacotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPacote { get; set; }

        [Column(TypeName = "VARCHAR (255)")]
        // [Required(ErrorMessage = "O nome do pacote é obrigatório!")]
        public string NomePacote { get; set; }

        [Column(TypeName = "VARCHAR (500)")]
        // [Required(ErrorMessage = "A descrição do pacote é necessaria")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de ida é obrigatória!")]
        public DateTime DataIda { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de volta é obrigatória!")]
        public DateTime DataVolta { get; set; }

        [Column(TypeName = "DECIMAL (18,2)")]
        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Preco { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "É necessário saber se o pacote está ativo ou não")]
        public bool Ativo { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        // [Required(ErrorMessage = "É obrigatório informar o nome da cidade")]
        public string NomeCidade { get; set; }
    }
}