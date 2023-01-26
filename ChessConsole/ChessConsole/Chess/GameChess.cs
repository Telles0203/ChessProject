

using ChessBoard;

namespace Chess
{
    class GameChess
    {
        public Board Board { get; set; }
        public int Turn { get; private set; }
        public Color PlayerActual { get; private set; }
        public bool GameEnd { get; private set; }


        public GameChess()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerActual = Color.White;
            GameEnd = false;
            InsertPieces();
        }

        public void ExecuteMoviment(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementAmountMoviment();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.InsertPiece(piece, destiny);
        }


        public void PerformsMove(Position origin, Position destiny)
        {
            ExecuteMoviment(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void OriginPositionValidation(Position position)
        {
            if (Board.piece(position) == null)
            {
                throw new ExceptionBoard("This position don´t have a piece");
            }
            if (PlayerActual != Board.piece(position).Color)
            {
                throw new ExceptionBoard("The origin piece isn´t your color");
            }
            if (!Board.piece(position).HavePossibleMoviments())
            {
                throw new ExceptionBoard("There are no moves possible for the chosen piece!");
            }
        }

        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Board.piece(origin).CanMoveFor(destiny))
            {
                throw new ExceptionBoard("Invalid destiny position!");
            }
            
        }


        private void ChangePlayer()
        {
            if (PlayerActual == Color.White)
            {
                PlayerActual = Color.Black;
            }
            else
            {
                PlayerActual = Color.White;
            }
        }
        private void InsertPieces()
        {
            Board.InsertPiece(new Tower(Color.Black, Board), new ChessPosition('a', 7).ToPosition());
            Board.InsertPiece(new Tower(Color.Black, Board), new ChessPosition('h', 8).ToPosition());
            Board.InsertPiece(new King(Color.Black, Board), new ChessPosition('d', 8).ToPosition());
            Board.InsertPiece(new Tower(Color.White, Board), new ChessPosition('a', 1).ToPosition());
            Board.InsertPiece(new Tower(Color.White, Board), new ChessPosition('h', 1).ToPosition());
            Board.InsertPiece(new King(Color.White, Board), new ChessPosition('d', 1).ToPosition());
        }
    }
}
