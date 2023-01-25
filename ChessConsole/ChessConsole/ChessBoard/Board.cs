using System;


namespace ChessBoard
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public void InsertPiece(Piece piece, Position position)
        {
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
