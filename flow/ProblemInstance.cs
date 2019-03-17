using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flow
{
    public class ProblemInstance
    {
        public Board Board;
        public string InputName;

        public ProblemInstance(string inputName, IReadOnlyList<string> inputLines)
        {
            this.InputName = inputName;
            var firstLine = inputLines[0];
            string[] elementsStr = firstLine.Split(' ');

            // Convert all input parameters to integer
            // int[] elements = Array.ConvertAll(elementsStr, int.Parse);

            // Initialize board
            Board = new Board(int.Parse(elementsStr[0]), int.Parse(elementsStr[1]), int.Parse(elementsStr[2]));
            
            // Set color of points
            for (int j = 0; j < Board.NumOfPoints; j++)
            {
                var point = Board.Points[int.Parse(elementsStr[j * 2 + 3]) - 1];
                point.Color = int.Parse(elementsStr[j*2 + 4]);
            }
            
            // Initialize Path
            var pathsOffset = 3 + (Board.NumOfPoints * 2);
            int numOfPaths = int.Parse(elementsStr[pathsOffset]);

            for (int k = 0; k < numOfPaths; k++)
            {
                var path = new Line(int.Parse(elementsStr[pathsOffset + 1]), Board.Points[int.Parse(elementsStr[pathsOffset + 2]) - 1]);
                var numOfSteps = int.Parse(elementsStr[pathsOffset + 3]);
            
                for (int j = pathsOffset + 4; j < pathsOffset + 4 + numOfSteps; j++)
                {
                    Step myStep;
                    Enum.TryParse(elementsStr[j], out myStep);
                    path.Steps.Add(myStep);
                }
            
                Board.Paths.Add(path);
                pathsOffset = pathsOffset + 3 + numOfSteps;
            }
        }
    }
}
