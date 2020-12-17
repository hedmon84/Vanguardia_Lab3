using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Pieces;

namespace Chess.Core
{
    public class GameLogic : IGameLogic
    {
        private readonly ILogger _logger;
        private readonly Factory _pieceFactory;
        private readonly IRuleLogic _ruleLogic;
        private readonly int[,] _board;

        public GameLogic(
            ILogger logger,
            Factory pieceFactory,
            IRuleLogic ruleLogic)
        {
            _logger = logger;
            _pieceFactory = pieceFactory;
            _ruleLogic = ruleLogic;
            _board = new [,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        }

        public void StartGame()
        {
            _logger.Log("Comenzando .....");
        }

        public void ExecuteMovement(Movement movement)
        {
            try
            {
                _logger.Log("Ejecutando en el Tablero");
                var piece = _pieceFactory.Create(movement);
                _ruleLogic.SetRules(_board, piece, movement);
                piece.Move(_board, movement);
            }
            catch (Exception e)
            {
                _logger.Log("Movimiento Invalido  :" + e);
                throw;
            }
        }

        public void StopGame()
        {
            _logger.Log("Finalizado ....");
        }

    }
}
