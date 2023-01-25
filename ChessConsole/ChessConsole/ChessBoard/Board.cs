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


        public Piece piece(Position position)
        {
            return pieces[position.Line, position.Column];
        }


        public bool HavePiece(Position position)
        {
            ValidPosition(position);
            return piece(position) != null;
        }


        public void InsertPiece(Piece piece, Position position)
        {
            if (HavePiece(position))
            {
                throw new ExceptionBoard("You have a piece in this position!");
            }
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }




        public bool ValidPosition(Position position)
        {
            return (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns) ? false : true;
        }

        public void PositionValid(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new ArgumentException("Posição Inválida");
            }
        }
    }
}
