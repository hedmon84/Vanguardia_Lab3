using System;
using System.Collections.Generic;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;

namespace Chess.Core
{
    public class Factory
    {
        private readonly ILogger _logger;
        private readonly Dictionary<PieceType, string> _pieces;
        public Factory(ILogger logger)
        {
            _logger = logger;
            _pieces = new Dictionary<PieceType, string>()
            {
                { PieceType.C, "Knight" },
                { PieceType.T, "Rook"}
            };
        }

        public Piece Create(Movement movement)
        {
            _logger.Log($"Creating piece of type [{movement.Piece}]");
            try
            {
                return (Piece) Activator.CreateInstance(
                    Type.GetType($"Chess.Core.Models.Pieces.{_pieces[movement.Piece]}Piece"), new object[]
                    {
                        movement.Piece,
                        _logger,
                        movement.WhitePiece
                    });
            }
            catch
            {
                return new Pawn(PieceType.P, _logger, movement.WhitePiece);
            }
        }
    }
}
