using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImprovShowPlanner.Data;
using ImprovShowPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Primitives;

namespace ImprovShowPlanner.Controllers
{
    public class ShowsController : Controller
    {
        private readonly ImprovShowContext _context;

        public ShowsController(ImprovShowContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index(int? id)
        {
            var improvShowContext = _context.Shows.Include(s => s.Game).Include(s => s.IndivShow).Include(s => s.Player).;
            if (id != null)
            {
                var show = await _context.Shows
                   .Include(s => s.Game)
                   .Include(s => s.IndivShow)
                   .Include(s => s.Player)
                   .FirstOrDefaultAsync(m => m.ShowId == id);
                return View(show);
            }
            return View(await improvShowContext.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Game)
                .Include(s => s.IndivShow)
                .Include(s => s.Player)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            ViewData["IndivShowId"] = new SelectList(_context.IndivShows, "IndivShowId", "IndivShowId");
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "FirstName");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,PlayerId,GameId")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", show.GameId);
            ViewData["IndivShowId"] = new SelectList(_context.IndivShows, "IndivShowId", "IndivShowId", show.IndivShowId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "FirstName", show.PlayerId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", show.GameId);
            ViewData["IndivShowId"] = new SelectList(_context.IndivShows, "IndivShowId", "IndivShowId", show.IndivShowId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "FirstName", show.PlayerId);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,PlayerId,GameId,IndivShowId")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", show.GameId);
            ViewData["IndivShowId"] = new SelectList(_context.IndivShows, "IndivShowId", "IndivShowId", show.IndivShowId);
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "FirstName", show.PlayerId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Game)
                .Include(s => s.IndivShow)
                .Include(s => s.Player)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }

        public async Task<IActionResult> CreateDatePage()
        {
            return View();
        }

        public async Task<IActionResult> CreateShowPage()
        {
            ViewData["ShowDate"] = HelperClass.ShowBuildHelper.ShowDate;
            

            return View(); ;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateShowPage([Bind("Date")] IndivShow indivShow)
        {
            HelperClass.ShowBuildHelper.ShowDate = indivShow.Date;
            if (ModelState.IsValid)
            {
                _context.Add(indivShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateShowPage));
            }

            return View(indivShow);
        }

        public IActionResult ChooseGames()
        {
            var gameNames = from d in _context.Games
                            orderby d.Name
                            select d;
            ViewData["GameList"] = new SelectList(gameNames, "Name", "Name");
            return View();
        }
        
        public IActionResult ChoosePlayers([Bind("Name")] Game game)
        {
            HelperClass.ShowBuildHelper.GameName = game.Name;
            
            var PlayerNames = from p in _context.Players
                orderby p.FirstName
                select p;

            var PlayerNumber =
                (from g in _context.Games where g.Name == game.Name select g.NumPlayers).FirstOrDefault();

            ViewData["PlayerList"] = new SelectList(PlayerNames, "FirstName", "FirstName");
            ViewData["PlayerNumber"] = PlayerNumber;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(IFormCollection players)
        {
            ArrayList dataToAdd = new ArrayList();
            var showId = (from s in _context.IndivShows
                where s.Date == HelperClass.ShowBuildHelper.ShowDate
                select s.IndivShowId).FirstOrDefault();
            var gameId = (from g in _context.Games
                where g.Name == HelperClass.ShowBuildHelper.GameName
                select g.GameId).FirstOrDefault();
            foreach (var player in players)
            {
                var playerId = (from p in _context.Players
                    where p.FirstName == player.Value
                    select p.PlayerId).FirstOrDefault();
                dataToAdd.Add(new Show{PlayerId=playerId,GameId=gameId,IndivShowId=showId});
                
            }
            dataToAdd.RemoveAt(dataToAdd.Count - 1);
            if (ModelState.IsValid)
            {
                foreach (var piece in dataToAdd)
                {
                    _context.Add(piece);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateShowPage));
            }
            return RedirectToAction(nameof(ChoosePlayers));
        }
    }
}
