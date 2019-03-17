using System.Collections.Generic;
using System.Linq;

namespace Flow
{
    public class SolutionLevel04 : ISolution
    {
		public string Name { get; set; }
		public int Id { get; set; }
		
		public void SolveProblem(ProblemInstance pi)
		{
			// Implement Solution Logic
			foreach (var path in pi.Board.Paths)
			{
				for (int i = 0; i < path.Steps.Count; i++)
				{
					if (path.IsValid)
					{
						path.PerformStep(i, pi.Board);
					}
				}
			}

			var output = "";
			foreach (var point in pi.Board.Points)
			{
				if (point.Color == 0)
				{
					output += "  ";
				}
				else
				{
					output += "B ";
				}

				if (point.Column == pi.Board.Columns)
				{
					OutputWriter.AddString(output);
					output = "";
				}
			}
			
			

			// Don't forget to write data to the output file
		}

		public OutputWriter OutputWriter { get; set; }

		public SolutionLevel04()
        {
            OutputWriter = new OutputWriter();
			Name = GetType().Name;
			Id = 1;
        }
	}
}
