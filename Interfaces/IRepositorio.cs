using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
    public interface IRepositorioF<F>
    {
        List<F> ListaF();
        F RetornaPorIdF(int id);        
        void InsereF(F entidade);        
        void ExcluiF(int id);        
        void AtualizaF(int id, F entidade);
        int ProximoIdF();
    }
}