using ChessBoard;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write("|");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("__|");
                    }
                    else
                    {
                        Console.Write($"{board.piece(i, j)}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
