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
                Console.WriteLine("Row Add by: " + rowAddBy);
                Console.WriteLine("Col Add by: " + rowAddBy);
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
                Console.WriteLine("Col Subtract by: " + colSubtract);
                Console.WriteLine("Row Subtract by: " + rowSubtract);
                ConvertTo2DArray();
                isSubtractable = true;
            }

            return isSubtractable;
        }

        private bool CheckByMultiplication()
        {
            bool isMultiplication = false;
            int? rMult = null, cMult = null;
            int maxCount = 10;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                int curRowMult = 2;
                while (curRowMult <= maxCount && rMult == null)
                {
                    bool curRowMultWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curRowMultWorks; y++)
                    {
                        if(y+1 < curMatrix.GetLength(1))
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, y+1] != null)
                            {
                                if (curMatrix[j, y].Value * curRowMult != curMatrix[j, y+1].Value)
                                {
                                    curRowMultWorks = false;
                                }
                            }
                        }
                    }
                    if (!curRowMultWorks)
                    {
                        curRowMult++;
                    }
                    else
                    {
                        rMult = curRowMult;
                    }
                }
            }
            for (int j = 0; j < curMatrix.GetLength(1); j++)
            {
                int curColDiv = 2;
                while (curColDiv <= maxCount && cMult == null)
                {
                    bool colDivWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && colDivWorks; y++)
                    {
                        if(y+1 < curMatrix.GetLength(0))
                        {
                            if (curMatrix[y, j] != null && curMatrix[y+1, j] != null)
                            {
                                if (curMatrix[y, j].Value / curColDiv != curMatrix[y+1, j].Value || curMatrix[y, j].Value * curColDiv != curMatrix[y + 1, j].Value)
                                {
                                    colDivWorks = false;
                                }
                            }
                        }
                    }
                    if (!colDivWorks)
                    {
                        curColDiv++;
                    }
                    else
                    {
                        cMult = curColDiv;
                    }

                }
            }
            if (rMult != null && cMult != null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 2] * rMult;
                Console.WriteLine("Row Multiply by: " + rMult);
                Console.WriteLine("Col Divided/mult by: " + cMult);
                ConvertTo2DArray();
                isMultiplication = true;
            }
        
            return isMultiplication;
        }

        private bool CheckByDivision()
        {
            bool isDivisable = false;
            int? rowDiv = null, colDiv = null;
            int maxCount = 10;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                int curRowDiv = 2;
                while (curRowDiv <= maxCount && rowDiv == null)
                {
                    bool curRowDivWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curRowDivWorks; y++)
                    {
                        if(y+1 < curMatrix.GetLength(1))
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, y+1] != null)
                            {
                                if (curMatrix[j, y].Value / curRowDiv != curMatrix[j, y+1].Value)
                                {
                                    curRowDivWorks = false;
                                }
                            }
                        }
                    }
                    if (!curRowDivWorks)
                    {
                        curRowDiv++;
                    }
                    else
                    {
                        rowDiv = curRowDiv;
                    }
                }
            }
            for (int j = 0; j < curMatrix.GetLength(1); j++)
            {
                int curColDiv = 2;
                while (curColDiv <= maxCount && colDiv == null)
                {
                    bool colDivWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && colDivWorks; y++)
                    {
                        if(y+1< curMatrix.GetLength(0))
                        {
                            if (curMatrix[y, j] != null && curMatrix[y+1, j] != null)
                            {
                                if (curMatrix[y, j].Value / curColDiv != curMatrix[y+1, j].Value )
                                {
                                    colDivWorks = false;
                                }
                            }
                        }
                    }
                    if (!colDivWorks)
                    {
                        curColDiv++;
                    }
                    else
                    {
                        colDiv = curColDiv;
                    }

                }
            }
            if (rowDiv != null && colDiv!=null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 2] / rowDiv;
                Console.WriteLine("Col Divide by: " + rowDiv);
                Console.WriteLine("Row divide by: " + colDiv);
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
