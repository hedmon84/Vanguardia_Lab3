using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models.Rules;
using Chess.Tests.Builders;
using Moq;
using Xunit;

namespace Chess.Tests
{
    public class MovementsTests
    {


        [Theory]
        [InlineData("InvalidMovement")]
        public void ValidateMovement_PawnInvalidMovement_Fails(string jsonKey)
        {
            var movement = TestDataSource.GetMovement(jsonKey);
            var testBuilder = new MovementsTestLogic();
            var rule = testBuilder
                .WithPawnRule()
                .WithPawnPiece()
                .WithMovement(movement)
                .Build();

            Assert.NotNull(movement);

            var result = rule.ValidateMovement(testBuilder.Board, testBuilder.Piece, testBuilder.Movement);
            Assert.False(result);
        }
    }
}
