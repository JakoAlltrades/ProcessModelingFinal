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
            int?[,] exampleMatrix = { {2,4 }, {1, null } };
            matrixSolver = new RavenMatrixSolver(exampleMatrix);
            matrixSolver.SolveMatrix();
        }
    }
}
