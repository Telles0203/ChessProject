

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
        private void InsertPieces()
        {
            Board.InsertPiece(new Tower(Color.Black, Board), new ChessPosition('a', 8).ToPosition());
            Board.InsertPiece(new Tower(Color.Black, Board), new ChessPosition('h', 8).ToPosition());
            Board.InsertPiece(new King(Color.Black, Board), new ChessPosition('d', 8).ToPosition());
            Board.InsertPiece(new Tower(Color.White, Board), new ChessPosition('a', 1).ToPosition());
            Board.InsertPiece(new Tower(Color.White, Board), new ChessPosition('h', 1).ToPosition());
            Board.InsertPiece(new King(Color.White, Board), new ChessPosition('d', 1).ToPosition());
        }
    }
}
