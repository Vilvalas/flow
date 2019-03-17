namespace Flow
{
	public interface ISolution
	{
		OutputWriter OutputWriter { get; set; }
		string Name { get; set; }
		int Id { get; set; }

		void SolveProblem( ProblemInstance problemInstance );

	}
}
