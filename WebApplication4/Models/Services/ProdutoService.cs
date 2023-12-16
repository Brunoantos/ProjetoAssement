using SuaLojaDeComputadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SuaLojaDeComputadores.Services
{
    public class ProdutoService
    {
        private List<Produto> _produtos;

        public ProdutoService()
        {
            // Inicialize a lista de produtos (simulação de um banco de dados)
            _produtos = new List<Produto>
            {
                  new Produto
        {


            Id = 1,
            Nome = "Notebook Profissional",
            Descricao = "Notebook ideal para uso profissional e corporativo",
            Quantidade = 15,
            Preco = 2499.99,
            DataCadastro = DateTime.Now,
            EmEstoque = true,
            ImagemUri = "/images/notebook_profissional.jpg"
        },
        new Produto
        {
            Id = 2,
            Nome = "Monitor UltraWide",
            Descricao = "Monitor de alta resolução e formato ultra panorâmico",
            Quantidade = 8,
            Preco = 899.99,
            DataCadastro = DateTime.Now,
            EmEstoque = true,
            ImagemUri = "/images/monitor_ultrawide.jpg"
        },
        new Produto
        {
            Id = 3,
            Nome = "Teclado Mecânico RGB",
            Descricao = "Teclado mecânico com iluminação RGB personalizável",
            Quantidade = 20,
            Preco = 149.99,
            DataCadastro = DateTime.Now,
            EmEstoque = true,
            ImagemUri = "/images/teclado_rgb.jpg"
        },
        new Produto
        {
            Id = 4,
            Nome = "Mouse Gamer",
            Descricao = "Mouse projetado para jogos com sensor de alta precisão",
            Quantidade = 12,
            Preco = 79.99,
            DataCadastro = DateTime.Now,
            EmEstoque = true,
            ImagemUri = "/images/mouse_gamer.jpg"
        },
                // Adicione mais produtos conforme necessário
            };
        }

        public List<Produto> ObterTodos()
        {
            return _produtos;
        }

        public Produto ObterPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = _produtos.Count + 1;
            _produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            var produtoExistente = _produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoExistente != null)
            {
                // Atualize as propriedades do produtoExistente com as do produto recebido
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Quantidade = produto.Quantidade;
                produtoExistente.Preco = produto.Preco;
                produtoExistente.DataCadastro = produto.DataCadastro;
                produtoExistente.EmEstoque = produto.EmEstoque;
            }
        }

        public void Excluir(int id)
        {
            var produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);
            if (produtoExistente != null)
            {
                _produtos.Remove(produtoExistente);
            }
        }
    }
}
