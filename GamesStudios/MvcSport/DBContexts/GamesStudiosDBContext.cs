using GamesStudios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GamesStudios.DBContext
{
    public class GamesStudiosDBContext : DbContext, IGamesStudiosDBContext
    {
        public GamesStudiosDBContext() : base("GamesStudiosDBContext"){
            Database.SetInitializer<GamesStudiosDBContext>(null);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }


        IQueryable<Game> IGamesStudiosDBContext.Games
        {
            get { return Games; }
        }

        IQueryable<Genre> IGamesStudiosDBContext.Genres
        {
            get { return Genres; }
        }

        Genre IGamesStudiosDBContext.FindGenreById(int? id)
        {
            Genre Genre = Genres.Find(id);
            return Genre;
        }

        Game IGamesStudiosDBContext.FindGameById(int? id)
        {
            Game Game = Games.Find(id);
            return Game;
        }

        T IGamesStudiosDBContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        T IGamesStudiosDBContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        int IGamesStudiosDBContext.SaveChanges()
        {
            return SaveChanges();
        }

        void IGamesStudiosDBContext.ChangeStateToModified<T>( T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IGamesStudiosDBContext.Dispose()
        {
            Dispose();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}