using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Service
{
    public class GamesService(GamesDbContext context)
    {
        private readonly GamesDbContext _context = context;

        public async Task<bool> AddGameLogo(int id, string fileName)
        {
            var game = await _context.GamesLw23s.FirstOrDefaultAsync(g=> g.IdGame == id);

            if (game is null)
                return false;

            game.LogoFile = fileName;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task AddScreenshot(ScreenshotsLw23 screenshot)
        {
            _context.ScreenshotsLw23s.Add(screenshot);
            await _context.SaveChangesAsync();
        }

        public async Task AddUser()
            => throw new NotImplementedException();

    }
}
