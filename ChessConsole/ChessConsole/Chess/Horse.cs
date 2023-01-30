using ChessBoard;


namespace Chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board)
        {

        }


        private bool CanMove(Position position)
        {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }





        public override bool[,] PossibleMoviments()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);


            position.ValuesDefinition(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            position.ValuesDefinition(Position.Line - 2, Position.Column - 1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            position.ValuesDefinition(Position.Line - 2, Position.Column + 1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            position.ValuesDefinition(Position.Line - 1, Position.Column + 2);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            position.ValuesDefinition(Position.Line + 1, Position.Column + 2);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }



            position.ValuesDefinition(Position.Line + 2, Position.Column + 1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            position.ValuesDefinition(Position.Line + 2, Position.Column - 1);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }


            position.ValuesDefinition(Position.Line + 1, Position.Column - 2);

            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            return matrix;
        }




        public override string ToString()
        {
            return "H";
        }
    }
}
