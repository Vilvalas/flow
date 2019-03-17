using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Flow
{
	public static class Program
	{
		private const string InputfilePath = "../../Input/";

		private static void Main(string[] args)
		{
			// *** Specify solution here ***
			ISolution solution = new SolutionLevel05();
			
            var problemInstances = InitInstances();

			foreach (var problemInstance in problemInstances)
			{
				Console.WriteLine("Start " + problemInstance.InputName + " " + solution.Name);
				solution.SolveProblem(problemInstance);
				solution.OutputWriter.WriteOutputFile(problemInstance.InputName + "_" + solution.Name);
				solution.OutputWriter.ResetOutput();
				Console.WriteLine("End " + problemInstance.InputName + " " + solution.Name);
			}
			
			OutputWriter.ExportSourceCodeZip();
		}
		
		private static List<ProblemInstance> InitInstances()
		{
			var probleminstances = new List<ProblemInstance>();

			foreach (var file in Directory.EnumerateFiles(InputfilePath, "*.in"))
			{
				var filename = System.IO.Path.GetFileName(file);
				var contents = File.ReadAllLines(file);
				probleminstances.Add(new ProblemInstance(filename, contents));
			}

			return probleminstances;
		}
	}
}
