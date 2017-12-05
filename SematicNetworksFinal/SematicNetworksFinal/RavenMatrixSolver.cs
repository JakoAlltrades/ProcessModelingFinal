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
        public RavenMatrixSolver(int?[,] matrix)
        {
            curMatrix = matrix;
        }

        public void SolveMatrix()
        {
            int[,] solvedMatrix = new int[curMatrix.GetLength(0), curMatrix.GetLength(1)];
            CheckByAddition();
        }

        private int? CheckByAddition()
        {
            int? addBy = null;
            int maxCount = 10;
            int colAddBy, rowAddBy;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                colAddBy = 1;
                while (colAddBy <= maxCount)
                {
                    bool colAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(1) - 1 && colAddWorks; y++)
                    {
                        for (int z = y + 1; y < curMatrix.GetLength(1) - 2 && colAddWorks; z++)
                        {
                            if (curMatrix[j, y] != null && curMatrix[j, z] != null)
                            {
                                int dif = curMatrix[j, y].Value - curMatrix[j, z].Value;
                                if (Math.Abs(dif) != addBy)
                                {
                                    colAddWorks = false;
                                }
                            }
                        }
                    }
                    if (!colAddWorks)
                    {
                        colAddBy++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for(int j = 0; j < curMatrix.GetLength(1); j++)
            {
                rowAddBy = 1;
                while(rowAddBy <= maxCount)
                {
                    bool rowAddWorks = true;
                    for (int y = 0; y < curMatrix.GetLength(0) - 1 && rowAddWorks; y++)
                    {
                        for (int z = y + 1; y < curMatrix.GetLength(0) && rowAddWorks; z++)
                        {
                            if (curMatrix[y, j] != null && curMatrix[z, j] != null)
                            {
                                int dif = curMatrix[y, j].Value - curMatrix[z, j].Value;
                                if (Math.Abs(dif) != addBy)
                                {
                                    rowAddWorks = false;
                                }
                            }
                        }
                    }
                    if (!rowAddWorks)
                    {
                        rowAddBy++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            return addBy;
        }

        private int? CheckBySubtraction()
        {
            int? addBy = null;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return addBy;
        }

        private int? CheckByMultiplication()
        {
            int? addBy = null;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return addBy;
        }

        private int? CheckByDivision()
        {
            int? addBy = null;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return addBy;
        }
    }
}
