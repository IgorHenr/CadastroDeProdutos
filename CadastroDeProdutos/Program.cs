using CadastroDeProdutos.DataBase;
using CadastroDeProdutos.Models;
using CadastroDeProdutos.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("----------Cadastro de Produtos----------");
        Console.WriteLine("----------------------------------------");

        Produtos novoProduto = PreencherDadosProdutos();

        Console.WriteLine("\n\nPor favor, revise os dados inseridos:");
        ExibirDetalhesProdutos(novoProduto);
        Console.WriteLine("\n\nDeseja enviar ou editar os dados inseridos?\n(1- Enviar)\n(2- Editar)\n(3- Cancelar)");

        string opcao = Console.ReadLine().ToLower();
        if (opcao == "1")
        {
            //Enviar os dados inseridos!
            Console.WriteLine("\nProduto cadastrado com sucesso!");
        }
        else if (opcao == "2")
        {
            Console.WriteLine("\nEdição do produto iniciada, insira novos dados!");
            novoProduto = PreencherDadosProdutos();
            Console.WriteLine("Edição concluída. Por favor, revise os novos dados!");
            ExibirDetalhesProdutos(novoProduto);

            Console.WriteLine("\nDeseja enviar os dados alterados?\n(1-Sim)\n(2-Não)");
            string opcaoEditar = Console.ReadLine().ToLower();
            if (opcaoEditar == "1")
            {
                Console.WriteLine("Dados editados enviado com sucesso!");
            }
            else
            {
                Console.WriteLine("Ação cancelada! os dados não serão enviados.");
            }
        }
        else if (opcao == "3")
        {
            Console.WriteLine("Cadastro cancelado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nOpção inválida! nenhum produto foi cadastrado.");
        }
    }
    static Produtos PreencherDadosProdutos()
    {
        //Dados dos produtos!

        Console.WriteLine("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Categoria do produto: ");
        string categoria = Console.ReadLine();

        Console.WriteLine("Valor do produto: ");
        decimal valor;
        while (!decimal.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Valor inválido. Insira um valor numérico!");
        }

        Console.WriteLine("Data de fabricação do produto *(AAAA/MM/DD)*: ");
        DateTime dataDeFabricacao;
        while (!DateTime.TryParse(Console.ReadLine(), out dataDeFabricacao))
        {
            Console.WriteLine("Data de fabricação inválida, insira uma data no formato (AAAA/MM/DD)!");
        }

        Console.WriteLine("Data de validade do produto *(AAAA/MM/DD)*: ");
        string inputdataDeValidade = Console.ReadLine();
        DateTime dataDeValidade = default;

        if (!string.IsNullOrWhiteSpace(inputdataDeValidade))
        {
            while (!DateTime.TryParse(inputdataDeValidade, out dataDeValidade))
            {
                Console.WriteLine("Data de validade inválida, insira uma data no formato (AAAA/MM/DD) ou deixe em branco!");
                inputdataDeValidade = Console.ReadLine();
            }
        }

        Console.WriteLine("Estoque do produto: ");
        decimal estoque;
        while (!decimal.TryParse(Console.ReadLine(), out estoque))
        {
            Console.WriteLine("Valor inserido inválido, insira um número inteiro!");
        }
        return ProdutosService.CadastrarProduto(nome, categoria, valor, dataDeFabricacao, dataDeValidade, estoque);
    }

    static void ExibirDetalhesProdutos(Produtos produtos)
    {
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Detalhes do produto!");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Nome: {produtos.Nome}");
        Console.WriteLine($"Categoria: {produtos.Categoria}");
        Console.WriteLine($"Valor: {produtos.Valor}");
        Console.WriteLine($"Data de fabricação: {produtos.DataDeFabricacao}");
        Console.WriteLine($"Data de validade: {produtos.DataDeValidade}");
        Console.WriteLine($"Estoque: {produtos.Estoque}");
        Console.WriteLine("---------------------------------------------------");
    }
}