using Chess.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Chess.Test
{
    public class RuleLogicTest
    {
        [Fact]
        public void ApplyRules_InvalidMovement_Fails()
        {
            var testBuilder = new GameLogic();
            var engine = testBuilder
                .WithInvalidMovement()
                .WithValidPiece()
                .Build();

            Assert.Throws<ApplicationException>(() => engine.ApplyRules(testBuilder.Board, testBuilder.Piece, testBuilder.Movement));
        }

        [Fact]
        public void ApplyRules_ValidMovement_Fails()
        {
            var testBuilder = new GameLogic();
            var engine = testBuilder
                .WithValidMovement()
                .WithValidPiece()
                .Build();

            var exception = Record.Exception(() =>
                engine.ApplyRules(testBuilder.Board, testBuilder.Piece, testBuilder.Movement));
            Assert.Null(exception);
        }
    }
}
