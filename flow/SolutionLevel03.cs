using System.Collections.Generic;
using System.Linq;

namespace Flow
{
    public class SolutionLevel03 : ISolution
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

				string output = "";
				if (path.IsValid)
				{
					output += "1";
				}
				else
				{
					output += "-1";
				}
				output = output + " " + path.Length;
				OutputWriter.AddString(output);
			}

			// Don't forget to write data to the output file
		}

		public OutputWriter OutputWriter { get; set; }

		public SolutionLevel03()
        {
            OutputWriter = new OutputWriter();
			Name = GetType().Name;
			Id = 1;
        }
	}
}
