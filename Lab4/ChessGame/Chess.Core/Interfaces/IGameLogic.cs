using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Models;

namespace Chess.Core.Interfaces
{
    public interface IGameLogic
    {
        void StartGame();

        void ExecuteMovement(Movement movement);

        void StopGame();
    }
}
