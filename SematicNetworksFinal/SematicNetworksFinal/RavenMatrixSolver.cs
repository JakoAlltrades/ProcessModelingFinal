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
        }

        private int? CheckByAddition()
        {
            int? addBy = null;
            bool[] rowsWork;
            for(int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {
                
            }
            return addBy;
        }

        private int? CheckBySubtraction()
        {
            int? addBy = null;
            bool[] rowsWork;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return addBy;
        }

        private int? CheckByMultiplication()
        {
            int? addBy = null;
            bool[] rowsWork;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return addBy;
        }

        private int? CheckByDivision()
        {
            int? addBy = null;
            bool[] rowsWork;
            for (int j = 0; j < curMatrix.GetLength(0); j++)//each row
            {

            }
            return addBy;
        }
    }
}
