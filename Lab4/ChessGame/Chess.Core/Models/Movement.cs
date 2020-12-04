using Chess.Core.Models.Pieces;

namespace Chess.Core.Models
{
    public class Movement
    {
        public PieceType Piece { get; set; }

        public BoardLayout StartPositionX { get; set; }

        private int _startPositiony;

        public int StartPositionY
        {
            get => _startPositiony;
            set => _startPositiony = value - 1;
        }

        public BoardLayout NewPositionX { get; set; }

        private int _newPositionY;

        public int NewPositionY
        {
            get => _newPositionY;
            set => _newPositionY = value - 1;
        }

        public bool WhitePiece { get; set; }
    }
}
