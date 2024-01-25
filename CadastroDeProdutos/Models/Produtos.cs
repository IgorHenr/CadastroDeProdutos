using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeProdutos.Models
{
    internal class Produtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeFabricacao { get; set; }
        public DateTime? DataDeValidade { get; set; }
        public decimal Estoque { get; set; }
    }
}
