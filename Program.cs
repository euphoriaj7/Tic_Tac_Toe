namespace TicTacToe
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            string player = NextPlayer("");
            List<string> board = CreateBoard();

            while (!IsFinished(board) && !HasWinner(board))
            {
                DisplayBoard(board);
                MakeMove(player, board);
                player = NextPlayer(player);
            }

            DisplayBoard(board);
            Console.WriteLine("\nGood game. Thanks for playing.");
        }
        static List<string> CreateBoard()
        {
            List<string> board = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                int num = i + 1;
                board.Add(num.ToString());
                Console.WriteLine(board[i]);
            }
            return board;
        }
        static void DisplayBoard(List<string> board)
            {
                Console.WriteLine();
                Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
                Console.WriteLine("-+-+-");
                Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
                Console.WriteLine("-+-+-");
                Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
            }
        static bool IsFinished(List<string> board)
        {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != "x" && board[i] != "o")
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        static bool HasWinner(List<string> board)
        {
            return ((board[0] == "x" && board[1] == "x" && board[2] == "x") 
                    || (board[3] == "x" && board[4] == "x" && board[5] == "x") 
                    || (board[6] == "x" && board[7] == "x" && board[8] == "x") 
                    || (board[0] == "x" && board[3] == "x" && board[6] == "x") 
                    || (board[1] == "x" && board[4] == "x" && board[7] == "x") 
                    || (board[2] == "x" && board[5] == "x" && board[8] == "x") 
                    || (board[0] == "x" && board[4] == "x" && board[8] == "x")
                    || (board[2] == "x" && board[4] == "x" && board[6] == "x")
                    || (board[0] == "o" && board[1] == "o" && board[2] == "o") 
                    || (board[3] == "o" && board[4] == "o" && board[5] == "o") 
                    || (board[6] == "o" && board[7] == "o" && board[8] == "o") 
                    || (board[0] == "o" && board[3] == "o" && board[6] == "o") 
                    || (board[1] == "o" && board[4] == "o" && board[7] == "o") 
                    || (board[2] == "o" && board[5] == "o" && board[8] == "o") 
                    || (board[0] == "o" && board[4] == "o" && board[8] == "o")
                    || (board[2] == "o" && board[4] == "o" && board[6] == "o"));
        }
        static void MakeMove(string player, List<string> board)
        {
            Console.Write($"\n{player}'s turn to choose a square (1-9): ");
            int square = Convert.ToInt32(Console.ReadLine());
            board[square - 1] = player;
        }
        static string NextPlayer(string currentPlayer)
        {
            if (currentPlayer == "" || currentPlayer == "o")
            {
                return "x";
            }
            return "o";
        }
    }
}
