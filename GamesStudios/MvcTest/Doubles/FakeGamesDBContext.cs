using GamesStudios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesStudios.Models;
using System.Collections.ObjectModel;

namespace MvcTest.Doubles
{
    public class FakeGamesDBContext : IGamesStudiosDBContext
    {

        SetMap _map = new SetMap();

        public IQueryable<Genre> Genres
        {
            get { return _map.Get<Genre>().AsQueryable(); }
            set { _map.Use<Genre>(value); }
        }

        public IQueryable<Game> Games
        {
            get { return _map.Get<Game>().AsQueryable(); }
            set { _map.Use<Game>(value); }
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public void ChangeStateToModified<T>(T entity) where T : class
        {
            return;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        public void Dispose()
        {
            return;
        }

        public Genre FindGenreById(int? id)
        {
            Genre item = (from c in this.Genres
                           where c.ID == id
                           select c).FirstOrDefault();
            return item;
        }

        public Game FindGameById(int? id)
        {
            Game item = (from p in this.Games
                         where p.ID == id
                         select p).FirstOrDefault();
            return item;
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }
    }

    class SetMap : KeyedCollection<Type, object>
    {
        public HashSet<T> Use<T>(IEnumerable<T> sourceData)
        {
            var set = new HashSet<T>(sourceData);
            if (Contains(typeof(T)))
            {
                Remove(typeof(T));
            }
            Add(set);
            return set;
        }

        public HashSet<T> Get<T>()
        {
            return (HashSet<T>)this[typeof(T)];
        }

        protected override Type GetKeyForItem(object item)
        {
            return item.GetType().GetGenericArguments().Single();
        }
    }
}
