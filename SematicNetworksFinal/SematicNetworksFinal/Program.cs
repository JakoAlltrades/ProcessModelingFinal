using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SematicNetworksFinal
{
    public class Program
    {
        static RavenMatrixSolver matrixSolver;
        public static void Main(string[] args)
        {
            int?[,] exampleMatrix = { {2,8 }, {4, null } };
            int?[,] subtractSolve = { { 7, 5, 3 }, { 6, 4, null } };
            int?[,] diviSolve = { { 9, 3 }, { 12, null } };
            matrixSolver = new RavenMatrixSolver(exampleMatrix);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(subtractSolve);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(diviSolve);
            matrixSolver.SolveMatrix();
        }
    }
}
