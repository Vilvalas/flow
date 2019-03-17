using System.Collections.Generic;
using System.Linq;

namespace Flow
{
    public class SolutionLevel02 : ISolution
    {
		public string Name { get; set; }
		public int Id { get; set; }
		
		public void SolveProblem(ProblemInstance pi)
		{
			// Implement Solution Logic
			for (int i = 0; i < pi.Board.NumOfPoints / 2; i++)
			{
				List<Point> points = pi.Board.Points.Where(p => p.Color == i + 1).ToList();
				var manhattanDistance = points[0].CalcManhattanDistance(points[1]).ToString();
				OutputWriter.AddString(manhattanDistance);
			}

			// Don't forget to write data to the output file
		}

		public OutputWriter OutputWriter { get; set; }

		public SolutionLevel02()
        {
            OutputWriter = new OutputWriter();
			Name = GetType().Name;
			Id = 1;
        }
	}
}
