using System;
using Chess.Core;
using Chess.Core.Models.Pieces;
using Chess.Core.Models.Rules;
using Chess.Infrastructure.Loggers;
using Chess.Infrastructure.Serializers;
using Chess.Infrastructure.Sources;
using Newtonsoft.Json.Linq;
using RulesBuilder = Chess.Core.Rules.Builder.RulesBuilder;

namespace Chess.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContent = new JsonInfo().GetInfo();
            var boardMovements = JArray.Parse(fileContent);
            var gameSerializer = new JsonFile();
            var logger = new FLogger();
            var ruleLogic = new RulesBuilder(logger).WithKnightRules().WithRookRules().Build();
            var gameLogic = new GameLogic(logger, new Factory(logger), ruleLogic);
            gameLogic.StartGame();
            foreach (var movementData in boardMovements)
            {
                var movement = gameSerializer.SerializeMovement(movementData.ToString());
                gameLogic.ExecuteMovement(movement);
            }
            gameLogic.StopGame();
        }
    }
}
