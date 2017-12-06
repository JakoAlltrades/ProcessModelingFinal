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
            if(CheckBySubtraction())
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
                    bool curColAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) && curColAddWorks; y++)
                    {
                        for (int z = y + 1; z < curMatrix.GetLength(1) && curColAddWorks; z++)
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, z] != null)
                            {
                                int dif = curMatrix[j, z].Value - curMatrix[j, y].Value;
                                
                                if (curMatrix[j, y].Value - curColSubtract != curMatrix[j, z].Value)
                                {
                                    curColAddWorks = false;
                                }
                            }
                        }
                    }
                    if (!curColAddWorks)
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
                    bool rowAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) && rowAddWorks; y++)
                    {
                        for (int z = y + 1; z < curMatrix.GetLength(0) && rowAddWorks; z++)
                        {
                            if (curMatrix[y, j] != null && curMatrix[z, j] != null)
                            {
                                if (curMatrix[y, j].Value - curRowSubtract != curMatrix[z,j].Value)
                                {
                                    rowAddWorks = false;
                                }
                            }
                        }
                    }
                    if (!rowAddWorks)
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
