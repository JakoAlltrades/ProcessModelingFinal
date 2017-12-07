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
            int?[,] diviSolve = { { 27, 9, 3 }, { 36, 12, null } };
            int?[,] example = { { 1, 4 }, { 4, 7 }, { 7, null } };
            int?[,] ex = { { 25, 15, 10 }, { 20, 10, null } };
            int?[,] mult5 = { { 5, 25 }, { 10, 50 }, {15,  null} };
            int?[,] div3 = { { 27, 9 }, { 9, 3 }, { 6, null } };
            int?[,] baseCase = { { 16, 8, 4 }, { 100, 50, 25 }, { 60, 30, null } };
            int?[,] exa = { { 3, 9, 27, 81 }, { 5, 15, 45, null } };
            int?[,] exa2 = { { 56 , 28, 14, 7}, { 64, 32, 16, null } };
            matrixSolver = new RavenMatrixSolver(exampleMatrix);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(subtractSolve);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(diviSolve);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(example);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(ex);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(mult5);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(div3);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(baseCase);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(exa);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(exa2);
            matrixSolver.SolveMatrix();
        }
    }
}
