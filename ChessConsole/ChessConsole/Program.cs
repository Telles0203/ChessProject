using Chess;
using ChessBoard;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);
                board.InsertPiece(new Tower(Color.Black, board), new Position(0, 0));
                board.InsertPiece(new Tower(Color.Black, board), new Position(0, 7));
                board.InsertPiece(new King(Color.Black, board), new Position(0, 3));
                Screen.PrintBoard(board);
            }
            catch (ExceptionBoard exception)
            {
                Console.WriteLine(exception.Message);
            }

            





            

        }
    }
}