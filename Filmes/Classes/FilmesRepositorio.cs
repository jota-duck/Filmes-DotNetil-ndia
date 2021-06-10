using System;
using System.Collections.Generic;
using Filmes.Interfaces;

namespace Filmes
{
    public class FilmesRepositorio : IRepositorio<FilmesBase>
    {
        private List<FilmesBase> listaFilmes = new List<FilmesBase>();
        public void Atualiza(int id, FilmesBase objeto)
		{
			listaFilmes[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFilmes[id].Excluir();
		}

		public void Insere(FilmesBase objeto)
		{
			listaFilmes.Add(objeto);
		}

		public List<FilmesBase> Lista()
		{
			return listaFilmes;
		}

		public int ProximoId()
		{
			return listaFilmes.Count;
		}

		public FilmesBase RetornaPorId(int id)
		{
			return listaFilmes[id];
		}
	}
}