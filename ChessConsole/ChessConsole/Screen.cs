using Chess;
using ChessBoard;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} |");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("-|");
                    }
                    else
                    {
                        PrintPiece(board.piece(i, j));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"   a b c d e f g h");
        }

        public static ChessPosition ReadChessPosition()
        {
            string var1 = Console.ReadLine();
            char column = var1[0];
            int line = int.Parse(var1[1]+" ");
            return new ChessPosition(column, line);
        } 


        public static void PrintPiece(Piece piece)
        {
            if(piece.Color== Color.White)
            {
                ConsoleColor var1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{piece}");
                Console.ForegroundColor = var1;
                Console.Write("|");
            }
            else
            {
                ConsoleColor var1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{piece}");
                Console.ForegroundColor = var1;
                Console.Write("|");
            }
        }
    }

}
