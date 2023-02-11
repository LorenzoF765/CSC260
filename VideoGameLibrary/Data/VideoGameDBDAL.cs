using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;
using System.Collections.Generic;

namespace VideoGameLibrary.Data
{
    public class VideoGameDBDAL : IDataAccessLayer
    {
        private AppDbContext db;
        public VideoGameDBDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddGame(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges(); // save or else lol
        }

        public void EditGame(Game game)
        {
            db.Games.Update(game);
            db.SaveChanges();
        }

        public Game GetGame(int? id)
        {
            return db.Games.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Game> GetGames()
        {
            return db.Games.OrderBy(g => g.Title).ToList();
        }

        public void RemoveGame(int? id)
        {
            db.Games.Remove(GetGame(id));
            db.SaveChanges();
        }

        public void Loan(int? id, string LoanOut)
        {
            GetGame(id).Loan(LoanOut);
            db.SaveChanges();
        }

		public IEnumerable<Game> Search(string key)
		{
            return GetGames().Where(k => k.Title.ToLower().Contains(key.ToLower()));
		}

        public IEnumerable<Game> Filter(string genere, string platform, string esrb)
        {
            IEnumerable<Game> games = GetGames();
            if (!string.IsNullOrEmpty(genere) && !string.IsNullOrEmpty(esrb) && !string.IsNullOrEmpty(platform))
            {
                IEnumerable<Game> genereGames = GetGames().Where(m => (!string.IsNullOrEmpty(m.Genere) && m.Genere.ToLower().Contains(genere.ToLower()))).ToList();
                IEnumerable<Game> platformGames = genereGames.Where(m => (!string.IsNullOrEmpty(m.Platform) && m.Platform.ToLower().Contains(platform.ToLower()))).ToList();
                games = platformGames.Where(m => (!string.IsNullOrEmpty(m.ESRB) && m.ESRB.ToLower().Equals(esrb.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(genere) && !string.IsNullOrEmpty(esrb))
            {
                IEnumerable<Game> genereGames = GetGames().Where(m => (!string.IsNullOrEmpty(m.Genere) && m.Genere.ToLower().Contains(genere.ToLower()))).ToList();
                games = genereGames.Where(m => (!string.IsNullOrEmpty(m.ESRB) && m.ESRB.ToLower().Equals(esrb.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(genere) && !string.IsNullOrEmpty(platform))
            {
                IEnumerable<Game> genereGames = GetGames().Where(m => (!string.IsNullOrEmpty(m.Genere) && m.Genere.ToLower().Contains(genere.ToLower()))).ToList();
                games = genereGames.Where(m => (!string.IsNullOrEmpty(m.Platform) && m.Platform.ToLower().Contains(platform.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(esrb) && !string.IsNullOrEmpty(platform))
            {
				IEnumerable<Game> platformGames = GetGames().Where(m => (!string.IsNullOrEmpty(m.Platform) && m.Platform.ToLower().Contains(platform.ToLower()))).ToList();
				games = platformGames.Where(m => (!string.IsNullOrEmpty(m.ESRB) && m.ESRB.ToLower().Equals(esrb.ToLower()))).ToList();
			}
            else if (!string.IsNullOrEmpty(genere))
            {
                games = GetGames().Where(m => (!string.IsNullOrEmpty(m.Genere) && m.Genere.ToLower().Contains(genere.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(platform))
            {
                games = GetGames().Where(m => (!string.IsNullOrEmpty(m.Platform) && m.Platform.ToLower().Contains(platform.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(esrb))
            {
                games = GetGames().Where(m => (!string.IsNullOrEmpty(m.ESRB) && m.ESRB.ToLower().Equals(esrb.ToLower()))).ToList();
            }
            return games;
        }
	}
}
