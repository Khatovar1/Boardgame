using BoardGameGroup.DAL;
using BoardGameGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace BoardGameGroup.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repo;

        public HomeController(IRepository repository)
        {
            repo = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewGame()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewGame([Bind(Include = "BoardgameName,MinPlayers,MaxPlayers,MinAge")] BoardgameModel model)
        {
            if (ModelState.IsValid)
            {
                repo.AddBoardgame(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult EditGame(int? boardgameID)
        {
            if(boardgameID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BoardgameModel boardgame = repo.GetBoardgameByID(boardgameID);
            if(boardgame == null)
            {
                return HttpNotFound();
            }

            return View(boardgame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGame([Bind(Include = "ID,BoardgameName,MinPlayers,MaxPlayers,MinAge")] BoardgameModel model)
        {
            if (ModelState.IsValid)
            {
                repo.EditBoardgame(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult DeleteGame(int? boardgameID)
        {
            if (boardgameID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BoardgameModel boardgame = repo.GetBoardgameByID(boardgameID);
            if (boardgame == null)
            {
                return HttpNotFound();
            }

            return View(boardgame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int? boardgameID)
        {
            if (boardgameID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BoardgameModel boardgame = repo.GetBoardgameByID(boardgameID);
            if (boardgame == null)
            {
                return HttpNotFound();
            }

            repo.DeleteBoardgame(boardgame);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GameDetails(int? boardgameID)
        {
            if (boardgameID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BoardgameModel boardgame = repo.GetBoardgameByID(boardgameID);
            if (boardgame == null)
            {
                return HttpNotFound();
            }

            BoardgameDisplayModel newDisplay = new BoardgameDisplayModel
            {
                BoardgameID = boardgame.ID,
                DisplayDate = DateTime.Now,
                Source = DisplaySource.WWW
            };
            repo.AddNewDisplay(newDisplay);

            List<BoardgameDisplayModel> gameDisplaysList = repo.GetLast10GameDisplays(boardgame.ID);

            var model = new GameDetailsViewModel
            {
                Boardgame = boardgame,
                GameDisplaysList = gameDisplaysList
            };

            return View(model);
        }

        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDirection = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault().ToLower();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var invoiceList = repo.GetAllBoardgames();
                SearchWord(ref invoiceList, searchValue);
                invoiceList = invoiceList.OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                recordsTotal = invoiceList.Count();
                var data = invoiceList.Skip(skip).Take(pageSize).Select(x => new { x.ID, x.BoardgameName }).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SearchWord(ref List<BoardgameModel> list, string searchValue)
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                var properties = typeof(BoardgameModel).GetProperties().Where(a => a.Name == "BoardgameName").ToArray();
                list = list.Where(boardgame => properties.Any(prop => ((prop.GetValue(boardgame, null) == null) ? "" : prop.GetValue(boardgame, null).ToString().ToLower()).Contains(searchValue))).ToList();
            }
        }
    }
}