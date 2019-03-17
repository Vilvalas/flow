using System;

namespace Flow
{
    public class Parameters
    {
        public int NumberOfRows;
        public int NumberOfColumns;

        public Parameters(string firstInputLine)
        {
            string[] elementsStr = firstInputLine.Split(' ');

            // Convert all input parameters to integer
            int[] elements = Array.ConvertAll(elementsStr, int.Parse);

            // TODO: Initialize local variables
            NumberOfRows = elements[0];
            NumberOfColumns = elements[1];
            // ...
        }

    }
}
