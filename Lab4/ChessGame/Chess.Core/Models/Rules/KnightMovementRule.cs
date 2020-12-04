using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models.Pieces;

namespace Chess.Core.Models.Rules
{
    public class KnightMovementRule : RuleBase
    {
        public override bool IsMatch(Piece piece)
        {
            return piece.PieceType == PieceType.C;
        }

        public override bool ValidateMovement(int[,] board, Piece piece, Movement movement)
        {
            if (board[(int)movement.NewPositionX, movement.NewPositionY] != 0)
            {
                Logger.Log($"Invalid movement, there is a piece in {movement.NewPositionX}{movement.NewPositionY}");
            }
            var validMovements = new List<(int, int)>
            {
                (1, 2),
                (1, -2),
                (2, 1),
                (2, -1),
                (-1, -2),
                (-1, 2),
                (-2, -1),
                (-2, 1)
            };

            return validMovements.Any(c =>
                (int) movement.StartPositionX + c.Item1 == (int) movement.NewPositionX &&
                movement.StartPositionY + c.Item2 == movement.NewPositionY);
        }

        public KnightMovementRule(ILogger logger) 
            : base(logger)
        {
        }
    }
}
