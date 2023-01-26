namespace ChessBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int AmountMoviment { get; protected set; }


        public Piece(Color color, Board board)
        {

            Color = color;
            Board = board;
            AmountMoviment = 0;
            Position = null;
        }

        public void IncrementAmountMoviment()
        {
            AmountMoviment++;
        }

        public bool HavePossibleMoviments()
        {
            bool[,] matriz = PossibleMoviments();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matriz[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveFor(Position position)
        {
            return PossibleMoviments()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoviments();


    }
}
