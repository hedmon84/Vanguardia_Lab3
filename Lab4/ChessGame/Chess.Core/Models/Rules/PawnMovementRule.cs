using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Models.Rules
{
    public class PawnMovementRule : RuleBase
    {
        public override bool IsMatch(Piece piece)
        {
            return piece.PieceType == PieceType.P;
        }

        public override bool ValidateMovement(int[,] board, Piece piece, Movement movement)
        {
            if (board[(int)movement.NewPositionX, movement.NewPositionY] != 0)
            {
                Logger.Log($"Invalid movement, there is a piece in {movement.NewPositionX}{movement.NewPositionY}");
                return false;
            }
            var validXPositionAfterMove = (int)movement.StartPositionX;
            var validYPositionsAfterMove =
                GetWhiteValidResults(piece, movement).Union(GetBlackValidResults(piece, movement));
            return validXPositionAfterMove == (int) movement.NewPositionX &&
                   validYPositionsAfterMove.Contains(movement.NewPositionY);

        }

        private static IEnumerable<int> GetBlackValidResults(Piece piece, Movement movement)
        {
            var validResults = new List<int>();
            if (piece.IsWhitePiece)
            {
                return Enumerable.Empty<int>();
            }

            if (movement.StartPositionY == 6)
            {
                validResults.Add(5);
                validResults.Add(4);
            }
            validResults.Add(++movement.StartPositionY);
            return validResults;
        }

        private static IEnumerable<int> GetWhiteValidResults(Piece piece, Movement movement)
        {
            var validResults = new List<int>();
            if (!piece.IsWhitePiece)
            {
                return Enumerable.Empty<int>();
            }

            if (movement.StartPositionY == 1)
            {
                validResults.Add(2);
                validResults.Add(3);
            }
            validResults.Add(++movement.StartPositionY);
            return validResults;
        }

        public PawnMovementRule(ILogger logger) 
            : base(logger)
        {
        }
    }
}
