using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;
using Chess.Core.Models.Rules;

[assembly: InternalsVisibleTo("Chess.Tests")]
namespace Chess.Core.Rules
{
    public class MoveLogic : IRuleLogic
    {
        private readonly IEnumerable<RuleBase> _rules;

        public MoveLogic(IEnumerable<RuleBase> rules)
        {
            _rules = rules;
        }

        public void SetRules(int[,] board, Piece piece, Movement movement)
        {
            if (_rules.Where(rule => rule.IsMatch(piece)).Any(rule => !rule.ValidateMovement(board, piece, movement)))
            {
                throw new ApplicationException(
                    $"Invalid movement {piece.PieceType}{movement.StartPositionX}{movement.StartPositionY}-{movement.NewPositionX}{movement.NewPositionY}");
            }
        }
    }
}
