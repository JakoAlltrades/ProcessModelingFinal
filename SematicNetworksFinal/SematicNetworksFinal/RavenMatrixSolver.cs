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
        private int[,] solvedMatrix;
        public RavenMatrixSolver(int?[,] matrix)
        {
            curMatrix = matrix;
        }

        public void SolveMatrix()
        {
            solvedMatrix = new int[curMatrix.GetLength(0), curMatrix.GetLength(1)];
            if (CheckByAddition())
            {
                PrintSolvedMatrix();
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
                                if (Math.Abs(dif) != curColAddBy)
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
                                int dif = curMatrix[y, j].Value - curMatrix[z, j].Value;
                                if (Math.Abs(dif) != curRowAddBy)
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
                curMatrix[curMatrix.GetLength(0) - 1, curMatrix.GetLength(1) - 1] = curMatrix[curMatrix.GetLength(0) - 2, curMatrix.GetLength(1) - 2] + rowAddBy;
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
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return isSubtractable;
        }

        private bool CheckByMultiplication()
        {
            bool isMultiplication = false;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return isMultiplication;
        }

        private bool CheckByDivision()
        {
            bool isDivisable = false;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

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
