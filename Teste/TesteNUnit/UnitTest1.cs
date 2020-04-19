using System;
using Aplicacao.Dominio.Entidades;
using NUnit.Framework;

namespace TesteNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestarIdadeRetornoCorreto()
        {
            var pessoa = new PessoaEntidade();
            pessoa.DataNascimento = DateTime.Parse("1989-12-17 00:00:00");
            Assert.AreEqual(30, pessoa.CalcularIdade());
        }

        [Test]
        public void TestarIdadeRetornoIncorreto()
        {
            var pessoa = new PessoaEntidade();
            pessoa.DataNascimento = DateTime.Parse("1989-12-17 00:00:00");
            Assert.AreNotEqual(31, pessoa.CalcularIdade());
        }
    }
}