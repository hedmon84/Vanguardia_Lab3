using Chess.Core.Models;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Interfaces
{
    public interface IRuleLogic
    {
        void SetRules(int [,] board, Piece piece, Movement movement);
    }
}