using BoardGameGroup.DAL;
using BoardGameGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace BoardGameGroup.Controllers
{
    public class WebserviceController : ApiController
    {
        private IRepository repo;

        public WebserviceController(IRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public IEnumerable<string> GetBoardgameNames(int? count = null)
        {
            var result = repo.GetAllBoardgames().Select(boardgame => boardgame.BoardgameName);
            if(count != null)
            {
                result = result.OrderByDescending(name => name).Take((int)count);
            }
            return result;
        }

        [HttpGet]
        public BoardgameModel GetDetails(int boardgameID)
        {
            var boardgame = repo.GetBoardgameByID(boardgameID);
            if (boardgame != null)
            {
                BoardgameDisplayModel newDisplay = new BoardgameDisplayModel
                {
                    BoardgameID = boardgame.ID,
                    DisplayDate = DateTime.Now,
                    Source = DisplaySource.Webservice
                };
                repo.AddNewDisplay(newDisplay);
            }
            return boardgame;
        }
    }
}