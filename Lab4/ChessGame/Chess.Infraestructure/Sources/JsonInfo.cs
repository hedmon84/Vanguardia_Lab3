using System.IO;
using Chess.Core.Interfaces;

namespace Chess.Infrastructure.Sources
{
    public class JsonInfo : IGameInfo
    {
        public string GetInfo()
        {
            return File.ReadAllText("game.json");
        }
    }
}