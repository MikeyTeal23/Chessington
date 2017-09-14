using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {

        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> availableMoves = StandardPawnMove(currentPosition);

            //yield return StandardPawnMove(currentPosition);
            if (NeverMoved)
            {
                availableMoves.AddRange(FirstPawnMove(currentPosition));
            }

            foreach (Square move in availableMoves)
            {
                yield return move;
            }
        }

        private List<Square> StandardPawnMove(Square currentPosition)
        {
            List<Square> moveList = new List<Square>();

            if (Player == 0)
            {
                moveList.Add(new Square(currentPosition.Row - 1, currentPosition.Col));
            }
            else
            {
                moveList.Add(new Square(currentPosition.Row + 1, currentPosition.Col));
            }

            return moveList;
        }

        
        private List<Square> FirstPawnMove(Square currentPosition)
        {
            List<Square> moveList = new List<Square>();

            if (Player == 0)
            {
                moveList.Add(new Square(currentPosition.Row - 2, currentPosition.Col));
            }
            else
            {
                moveList.Add(new Square(currentPosition.Row + 2, currentPosition.Col));
            }

            return moveList;
        }
    }
}