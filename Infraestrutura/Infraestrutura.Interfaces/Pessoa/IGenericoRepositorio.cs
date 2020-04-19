using System;
using System.Collections.Generic;

namespace Infraestrutura.Interfaces.Pessoa
{
    public interface IGenericoRepositorio<T> where T : class
    {
        IEnumerable<T> ListarTodos();
        T ConsultarPorId(int id);
        int Cadastrar(T objeto);
        int Atualizar(T objeto);
        int Deletar(int id);
    }
}
