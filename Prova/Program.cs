
using Prova;
using System;
using System.Collections.Generic;

class Program
{
    static ILogger _logger = new ConsoleLogger();
    static ProdutoRepository _produtoRepo = new ProdutoRepository(_logger);
    static ClienteRepository _clienteRepo = new ClienteRepository(_logger);
    static PedidoRepository _pedidoRepo = new PedidoRepository(_logger);
    static CalculadoraDeDescontos _calculadora;

    static void Main(string[] args)
    {
        ExibirCabecalho();

        CadastrarProdutos();
        CadastrarClientes();
        CriarPedidos();

        GerarRelatorio();

        _logger.Registrar("Execução finalizada com sucesso.");
        Console.WriteLine("\nPressione qualquer tecla para encerrar...");
        Console.ReadKey();
    }

    static void ExibirCabecalho()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("      SISTEMA DE GESTÃO DE PEDIDOS         ");
        Console.WriteLine("===========================================");
    }

    static void CadastrarProdutos()
    {
        _logger.Registrar("Cadastrando produtos...");
        _produtoRepo.Adicionar(new Produto(1, "Teclado", 150.00m, "Informática"));
        _produtoRepo.Adicionar(new Produto(2, "Mouse", 80.00m, "Informática"));
        _produtoRepo.Adicionar(new Produto(3, "Caderno", 20.00m, "Papelaria"));
    }

    static void CadastrarClientes()
    {
        _logger.Registrar("Cadastrando clientes...");
        _clienteRepo.Adicionar(new Cliente(1, "Maria", "maria@email.com", "12345678901"));
    }

    static void CriarPedidos()
    {
        _logger.Registrar("Criando pedido...");

        var cliente = _clienteRepo.ObterPorId(1);
        var factory = new PedidoFactory(_logger);

        var itens = new List<(Produto, int)>
        {
            (_produtoRepo.ObterPorId(1), 1),
            (_produtoRepo.ObterPorId(2), 3),
            (_produtoRepo.ObterPorId(3), 2)
        };

        var pedido = factory.CriarPedido(1, cliente, itens);
        _pedidoRepo.Adicionar(pedido);

        _calculadora = new CalculadoraDeDescontos(new List<IDescontoStrategy>
        {
            new DescontoPorCategoria("Informática", 0.10m),
            new DescontoPorQuantidade(3, 0.15m)
        }, _logger);
    }

    static void GerarRelatorio()
    {
        Console.WriteLine("\n\n======= RELATÓRIO DE PEDIDOS =======\n");
        var relatorio = new RelatorioDePedidos(_pedidoRepo, _calculadora, _logger);
        relatorio.Gerar();
    }
}
