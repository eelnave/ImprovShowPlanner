using System.Data.Entity;
using ImprovShowPlanner.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ImprovShowPlanner.Views.Games
{
    public class GameTypePageModel : PageModel
    {
        public SelectList GameTypeSl { get; set; }

        public void PopulateGameTypeDropDownList(ImprovShowContext context,
            object selectedGameType = null)
        {
            var gameTypeQuery = from d in context.GameTypes
                                orderby d.GameForm
                                select d;
            
            GameTypeSl = new SelectList(gameTypeQuery.AsNoTracking(), "GameTypeId", "GameForm", selectedGameType);
        }
    }
}
