using Chess.Core.Models;

namespace Chess.Core.Interfaces
{
    public interface IMoveSerializer
    {
        Movement SerializeMovement(string data);
    }
}
