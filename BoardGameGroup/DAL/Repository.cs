using BoardGameGroup.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameGroup.DAL
{
    public interface IRepository
    {
        List<BoardgameModel> GetAllBoardgames();
        BoardgameModel GetBoardgameByID(int? boardgameID);
        void AddBoardgame(BoardgameModel model);
        void EditBoardgame(BoardgameModel model);
        void DeleteBoardgame(BoardgameModel model);
        void AddNewDisplay(BoardgameDisplayModel newDisplay);
        List<BoardgameDisplayModel> GetLast10GameDisplays(int boardgameID);
    }

    public class Repository : IRepository
    {
        private DatabaseContext db = new DatabaseContext();

        public Repository() { }

        public void AddBoardgame(BoardgameModel model)
        {
            db.Boardgames.Add(model);
            db.SaveChanges();
        }

        public void AddNewDisplay(BoardgameDisplayModel newDisplay)
        {            
            db.BoardgameDisplays.Add(newDisplay);
            db.SaveChanges();
        }

        public void DeleteBoardgame(BoardgameModel model)
        {
            var gameDisplays = db.BoardgameDisplays.Where(display => display.BoardgameID == model.ID);
            foreach (var display in gameDisplays)
            {
                db.BoardgameDisplays.Remove(display);
            }
            
            db.Boardgames.Remove(model);
            db.SaveChanges();
        }

        public void EditBoardgame(BoardgameModel model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<BoardgameModel> GetAllBoardgames()
        {
            return db.Boardgames.ToList();
        }

        public BoardgameModel GetBoardgameByID(int? boardgameID)
        {
            return db.Boardgames.Where(boardgame => boardgame.ID == boardgameID).FirstOrDefault();
        }

        public List<BoardgameDisplayModel> GetLast10GameDisplays(int boardgameID)
        {
            return db.BoardgameDisplays.Where(display => display.BoardgameID == boardgameID).OrderByDescending(display => display.DisplayDate).Take(10).ToList();
        }
    }
}