using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class FilmeRepositorio : IRepositorioF<Filme>
    {
			private List<Filme> listaFilme = new List<Filme>();
        public void AtualizaF(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
        }

        public void ExcluiF(int id)
        {
            listaFilme[id].Excluir();
        }

        public void InsereF(Filme objeto)
        {
            listaFilme.Add(objeto);	
        }

        public List<Filme> ListaF()
        {
            return listaFilme;
        }

        public int ProximoIdF()
        {
            return listaFilme.Count;
        }

        public Filme RetornaPorIdF(int id)
        {
            return listaFilme[id];
        }
    }
}