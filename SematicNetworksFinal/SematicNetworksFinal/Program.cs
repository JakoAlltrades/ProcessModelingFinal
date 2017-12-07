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
            int?[,] exampleMatrix = {
                {2,4 }, 
                {1, null }
            };
            int?[,] example2Matrix = {
                {2,1 },
                {4, null }
            };
            int?[,] subtractSolve = { 
                { 7, 5, 3 }, 
                { 6, 4, null }
            };
            int?[,] diviSolve = { 
                { 27, 9, 3 },
                { 9, 3, null }
            };
            int?[,] badexample = {
                { 1, 10 },
                { 10, 100 },
                { 7, null }
            };
            int?[,] ex = {
                { 40, 20, 10 },
                { 20, 10, null }
            };
            int?[,] mult5 = { 
                { 5, 25 },
                { 10, 50 },
                {15,  null}
            };
            int?[,] div3 = {
                { 27, 9 },
                { 9, 3 }, 
                { 3, null } };
            int?[,] baseCase = {
                {  500, 100, 20 },
                { 100, 20, 5 },
                { 20, 5, null } };
            int?[,] exa = { 
                { 3, 9, 27, 81 },
                { 9, 27, 81, null }
            };
            int?[,] exa2 = 
                { 
                { 10000 , 1000, 100, 10}, 
                { 1000, 100, 10, null }
            };
            matrixSolver = new RavenMatrixSolver(badexample);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(exampleMatrix);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(example2Matrix);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(subtractSolve);
            matrixSolver.SolveMatrix();
            matrixSolver = new RavenMatrixSolver(diviSolve);
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
