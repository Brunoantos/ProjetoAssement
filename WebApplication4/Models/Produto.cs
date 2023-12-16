using System;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace SuaLojaDeComputadores.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo Quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior que zero.")]
        public double Preco { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Em Estoque")]
        public bool EmEstoque { get; set; }

        public string ImagemUri { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
