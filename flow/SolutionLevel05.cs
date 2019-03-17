using System.Collections.Generic;
using System.Linq;

namespace Flow
{
    public class SolutionLevel05 : ISolution
    {
		public string Name { get; set; }
		public int Id { get; set; }
		
		public void SolveProblem(ProblemInstance pi)
		{
			// Implement Solution Logic
			
			
			// Don't forget to write data to the output file
		}

		public OutputWriter OutputWriter { get; set; }

		public SolutionLevel05()
        {
            OutputWriter = new OutputWriter();
			Name = GetType().Name;
			Id = 1;
        }
	}
}
