using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SematicNetworksFinal
{
    public class RavenMatrixSolver
    {
        private int?[,] curMatrix;
        private int?[,] solvableMatrix;
        private int[,] solvedMatrix;
        public RavenMatrixSolver(int?[,] matrix)
        {
            solvableMatrix = matrix;
        }

        private void PrintSolvableMatix()
        {
            string matrix = "";
            for (int j = 0; j < solvableMatrix.GetLength(0); j++)
            {
                matrix += "| ";
                for (int k = 0; k < solvableMatrix.GetLength(1); k++)
                {
                    if (solvableMatrix[j, k] != null)
                    {
                        matrix += solvableMatrix[j, k] + " ";
                    }
                    else
                    {
                        matrix += "? ";
                    }
                }
                matrix += "|\n";
            }
            Console.WriteLine(matrix);
        }

        public void SolveMatrix()
        {
            Console.WriteLine("Current solvable matrix::");
            PrintSolvableMatix();
            solvedMatrix = new int[solvableMatrix.GetLength(0), solvableMatrix.GetLength(1)];
            curMatrix = solvableMatrix;
            if (CheckByAddition())
            {
                Console.WriteLine("Addition Solve:");
                PrintSolvedMatrix();
                curMatrix = solvableMatrix;
            }
            else if (CheckBySubtraction())
            {
                Console.WriteLine("Subtraction Solve:");
                PrintSolvedMatrix();
                curMatrix = solvableMatrix;
            }
            if (CheckByMultiplication())
            {
                Console.WriteLine("Multiplication Solve:");
                PrintSolvedMatrix();
                curMatrix = solvableMatrix;
            }
            else if(CheckByDivision())
            {
                Console.WriteLine("Division Solve:");
                PrintSolvedMatrix();
                curMatrix = solvableMatrix;
            }
        }

        private bool CheckByAddition()
        {
            bool isAddable = false;
            int maxCount = 10;
            int? colAddBy = null, rowAddBy = null;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                int curColAddBy = 1;
                if (j > 0 && colAddBy == null)
                {
                    break;
                }
                while (curColAddBy <= maxCount && colAddBy == null)
                {
                    bool curColAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColAddWorks; y++)
                    {
                        if (y + 1 < curMatrix.GetLength(1))
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, y+1] != null)
                            {
                                if (curMatrix[j, y].Value + curColAddBy != curMatrix[j, y+1].Value)
                                {
                                    curColAddWorks = false;
                                }
                            }
                        }
                    }
                    if (!curColAddWorks)
                    {
                        curColAddBy++;
                    }
                    else
                    {
                        colAddBy = curColAddBy;
                    }
                }
            }
            for (int j = 0; j < curMatrix.GetLength(1); j++)
            {
                int curRowAddBy = 1;
                while (curRowAddBy <= maxCount && rowAddBy == null)
                {
                    bool rowAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && rowAddWorks; y++)
                    {
                        if(y + 1 < curMatrix.GetLength(0))
                        { 
                            if (curMatrix[y, j] != null && curMatrix[y+1, j] != null)
                            {
                                if (curRowAddBy + curMatrix[y,j] != curMatrix[y+1,j])
                                {
                                    rowAddWorks = false;
                                }
                            }
                        }
                    }
                    if (!rowAddWorks)
                    {
                        curRowAddBy++;
                    }
                    else
                    {
                        rowAddBy = curRowAddBy;
                    }

                }
            }
            if (colAddBy != null && rowAddBy != null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 2] + rowAddBy;
                Console.WriteLine("Add by: " + rowAddBy);
                ConvertTo2DArray();
                isAddable = true;
            }

            return isAddable;
        }

        private void ConvertTo2DArray()
        {
            for (int j = 0; j < curMatrix.GetLength(0); j++)
            {
                for (int k = 0; k < curMatrix.GetLength(1); k++)
                {
                    if (curMatrix[j, k] != null)
                    {
                        solvedMatrix[j, k] = curMatrix[j, k].Value;
                    }
                }
            }
        }

        private bool CheckBySubtraction()
        {
            bool isSubtractable = false;
            int? colSubtract = null, rowSubtract = null;
            int maxCount = 10;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                if (j > 0 && colSubtract == null)
                {
                    break;
                }
                int curColSubtract = 1;
                while (curColSubtract <= maxCount && colSubtract == null)
                {
                    bool curColSubtractWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColSubtractWorks; y++)
                    {
                        if (y + 1 < curMatrix.GetLength(1))
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, y+1] != null)
                            {
                                if (curMatrix[j, y].Value - curColSubtract != curMatrix[j, y+1].Value)
                                {
                                    curColSubtractWorks = false;
                                }
                            }
                        }
                    }
                    if (!curColSubtractWorks)
                    {
                        curColSubtract++;
                    }
                    else
                    {
                        colSubtract = curColSubtract;
                    }
                }
            }
            for (int j = 0; j < curMatrix.GetLength(1); j++)
            {
                int curRowSubtract = 1;
                while (curRowSubtract <= maxCount && rowSubtract == null)
                {
                    bool rowSubtractWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && rowSubtractWorks; y++)
                    {
                        if(y+1 < curMatrix.GetLength(0))
                        {
                            if (curMatrix[y, j] != null && curMatrix[y+1, j] != null)
                            {
                                if (curMatrix[y, j].Value - curRowSubtract != curMatrix[y+1,j].Value)
                                {
                                    rowSubtractWorks = false;
                                }
                            }
                        }
                    }
                    if (!rowSubtractWorks)
                    {
                        curRowSubtract++;
                    }
                    else
                    {
                        rowSubtract = curRowSubtract;
                    }

                }
            }
            if (colSubtract != null && rowSubtract != null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1)-2] - colSubtract;
                Console.WriteLine("Subtract by: " + colSubtract);
                ConvertTo2DArray();
                isSubtractable = true;
            }

            return isSubtractable;
        }

        private bool CheckByMultiplication()
        {
            bool isMultiplication = false;
            int? colMult = null, rowMult = null;
            int maxCount = 10;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                int curColMult = 1;
                while (curColMult <= maxCount && colMult == null)
                {
                    bool curColMultWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColMultWorks; y++)
                    {
                        if(y+1 < curMatrix.GetLength(1))
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, y+1] != null)
                            {
                                if (curMatrix[j, y].Value * curColMult != curMatrix[j, y+1].Value)
                                {
                                    curColMultWorks = false;
                                }
                            }
                        }
                    }
                    if (!curColMultWorks)
                    {
                        curColMult++;
                    }
                    else
                    {
                        colMult = curColMult;
                    }
                }
            }
            for (int j = 0; j < curMatrix.GetLength(1); j++)
            {
                int curRowMult = 1;
                while (curRowMult <= maxCount && rowMult == null)
                {
                    bool rowMultWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && rowMultWorks; y++)
                    {
                        if(y+1 > curMatrix.GetLength(0))
                        {
                            if (curMatrix[y, j] != null && curMatrix[y+1, j] != null)
                            {
                                if (curMatrix[y, j].Value * curRowMult != curMatrix[y+1, j].Value)
                                {
                                    rowMultWorks = false;
                                }
                            }
                        }
                    }
                    if (!rowMultWorks)
                    {
                        curRowMult++;
                    }
                    else
                    {
                        rowMult = curRowMult;
                    }

                }
            }
            if (colMult != null && rowMult != null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 2] * colMult;
                Console.WriteLine("Multiply by: " + colMult);
                ConvertTo2DArray();
                isMultiplication = true;
            }
        
            return isMultiplication;
        }

        private bool CheckByDivision()
        {
            bool isDivisable = false;
            int? colDiv = null, rowDiv = null;
            int maxCount = 10;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                int curColDiv = 2;
                while (curColDiv <= maxCount && colDiv == null)
                {
                    bool curColDivWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColDivWorks; y++)
                    {
                        if(y+1 < curMatrix.GetLength(1))
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, y+1] != null)
                            {
                                if (curMatrix[j, y].Value / curColDiv != curMatrix[j, y+1].Value)
                                {
                                    curColDivWorks = false;
                                }
                            }
                        }
                    }
                    if (!curColDivWorks)
                    {
                        curColDiv++;
                    }
                    else
                    {
                        colDiv = curColDiv;
                    }
                }
            }
            for (int j = 0; j < curMatrix.GetLength(1); j++)
            {
                int curDivMult = 2;
                while (curDivMult <= maxCount && rowDiv == null)
                {
                    bool rowDivWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && rowDivWorks; y++)
                    {
                        if(y+1< curMatrix.GetLength(0))
                        {
                            if (curMatrix[y, j] != null && curMatrix[y+1, j] != null)
                            {
                                if (curMatrix[y, j].Value / curDivMult != curMatrix[y+1, j].Value )
                                {
                                    rowDivWorks = false;
                                }
                            }
                        }
                    }
                    if (!rowDivWorks)
                    {
                        curDivMult++;
                    }
                    else
                    {
                        rowDiv = curDivMult;
                    }

                }
            }
            if (colDiv != null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 2] / colDiv;
                Console.WriteLine("Divide by: " + colDiv);
                ConvertTo2DArray();
                isDivisable = true;
            }
            return isDivisable;
        }

        private void PrintSolvedMatrix()
        {
            string matrix = "";
            for(int j = 0; j < solvedMatrix.GetLength(0); j++)
            {
                matrix += "| ";
                for(int k = 0; k < solvedMatrix.GetLength(1); k++)
                {
                    matrix += solvedMatrix[j, k] + " ";
                }
                matrix += "|\n";
            }
            Console.WriteLine(matrix);
        }
    }
}
