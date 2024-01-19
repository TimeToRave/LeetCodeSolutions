using System.Linq;

namespace LeetCodeSolutions
{
    partial class Program
    {
        class ValidSudokuSolution
        {
            public bool IsValidSudokuNaive(char[][] board)
            {
                var result = true;

                result = CheckHorizontalLines(board);
                if (result)
                {
                    result = CheckVerticalLines(board);
                }
                if (result)
                {
                    result = CheckSquares(board);

                }

                return result;
            }

            private bool CheckHorizontalLines(char[][] board)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (!CheckSequence(board[i]))
                    {
                        return false;
                    }
                }
                return true;
            }

            private bool CheckVerticalLines(char[][] board)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    var column = new char[board[i].GetLength(0)];
                    for (int j = 0; j < column.Length; j++)
                    {
                        column[j] = board[j][i];
                    }

                    if (!CheckSequence(column))
                    {
                        return false;
                    }
                }
                return true;
            }

            private bool CheckSquares(char[][] board)
            {
                for (int i = 0; i < board.GetLength(0); i += 3)
                {
                    var group = new char[board[i].GetLength(0)];

                    for (int j = 0; j < group.Length; j += 3)
                    {

                        int groupIterator = 0;
                        for (int t = i; t < i + group.Length / 3; t++)
                        {
                            for (int x = j; x < j + group.Length / 3; x++)
                            {
                                group[groupIterator] = board[t][x];
                                groupIterator++;
                            }
                        }
                        
                        if (!CheckSequence(group))
                        {
                            return false;
                        }
                    }

                }
                return true;
            }

            private bool CheckSequence(char[] group)
            {
                if (group.Where(x => x != '.').GroupBy(x => x).Where(x => x.Count() > 1).ToArray().Length > 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
