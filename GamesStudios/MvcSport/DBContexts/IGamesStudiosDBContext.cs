using GamesStudios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStudios.DBContext
{
    public interface IGamesStudiosDBContext
    {
        IQueryable<Game> Games { get; }
        IQueryable<Genre> Genres { get; }
        Genre FindGenreById(int? id);
        Game FindGameById(int? id);

        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        int SaveChanges();
        void ChangeStateToModified<T>(T entity) where T : class;
        void Dispose();
    }
}
