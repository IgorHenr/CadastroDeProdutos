using CadastroDeProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeProdutos.Services
{
    internal class ProdutosService
    {
        private static List<Produtos> ListaDeProdutos = new List<Produtos>();

        public static Produtos CadastrarProduto(string nome, string categoria, decimal valor, DateTime dataDeFabricacao, DateTime dataDeValidade,decimal estoque ) { 
            Produtos produtos = new Produtos { 
                Nome = nome,
                Categoria = categoria,
                Valor = valor,
                DataDeFabricacao = dataDeFabricacao,
                DataDeValidade = dataDeValidade,
                Estoque = estoque
            };
            return produtos;
        }
    }
}
