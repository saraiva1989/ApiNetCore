using System;
namespace Aplicacao.Dominio.Entidades
{
    //Classe modelo
    public class PessoaEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        //Adicionado esse método para mostrar uma classe não anemica.
        public int CalcularIdade()
        {
            var dataAtual = DateTime.Now;
            var idade = dataAtual.Year - DataNascimento.Year;

            if (dataAtual < DataNascimento.AddYears(idade)) idade--;

            return idade;
        }

        public PessoaEntidade()
        {
        }
    }
}