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
                while (curColAddBy <= maxCount && colAddBy == null)
                {
                    bool curColAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColAddWorks; y++)
                    {
                        for (int z = y + 1; z < curMatrix.GetLength(1) && curColAddWorks; z++)
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, z] != null)
                            {
                                int dif = curMatrix[j, y].Value - curMatrix[j, z].Value;
                                if (curMatrix[j, y].Value + curColAddBy != curMatrix[j, z].Value)
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
                        for (int z = y + 1; z < curMatrix.GetLength(0) && rowAddWorks; z++)
                        {
                            if (curMatrix[y, j] != null && curMatrix[z, j] != null)
                            {
                                if (curRowAddBy + curMatrix[j,y] != curMatrix[j,z])
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
                int curColSubtract = 1;
                while (curColSubtract <= maxCount && colSubtract == null)
                {
                    bool curColSubtractWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColSubtractWorks; y++)
                    {
                        for (int z = y + 1; z < curMatrix.GetLength(1) && curColSubtractWorks; z++)
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, z] != null)
                            {
                                int dif = curMatrix[j, z].Value - curMatrix[j, y].Value;
                                
                                if (curMatrix[j, y].Value - curColSubtract != curMatrix[j, z].Value)
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
                        for (int z = y + 1; z < curMatrix.GetLength(0) && rowSubtractWorks; z++)
                        {
                            if (curMatrix[y, j] != null && curMatrix[z, j] != null)
                            {
                                if (curMatrix[y, j].Value - curRowSubtract != curMatrix[z,j].Value)
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
                        for (int z = y + 1; z < curMatrix.GetLength(1) && curColMultWorks; z++)
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, z] != null)
                            {
                                int dif = curMatrix[j, z].Value - curMatrix[j, y].Value;

                                if (curMatrix[j, y].Value * curColMult != curMatrix[j, z].Value)
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
                        for (int z = y + 1; z < curMatrix.GetLength(0) && rowMultWorks; z++)
                        {
                            if (curMatrix[y, j] != null && curMatrix[z, j] != null)
                            {
                                if (curMatrix[y, j].Value * curRowMult != curMatrix[z, j].Value)
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
                        for (int z = y + 1; z < curMatrix.GetLength(1) && curColDivWorks; z++)
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, z] != null)
                            {
                                if (curMatrix[j, z].Value / curColDiv != curMatrix[j, y].Value)
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
                        for (int z = y + 1; z < curMatrix.GetLength(0) && rowDivWorks; z++)
                        {
                            if (curMatrix[y, j] != null && curMatrix[z, j] != null)
                            {
                                if (curMatrix[y, j].Value / curDivMult != curMatrix[z, j].Value )
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
            if (colDiv != null && rowDiv != null)
            {
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 2] * colDiv;
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
