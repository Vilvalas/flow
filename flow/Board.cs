using System.Collections.Generic;
using System.Data;

namespace Flow
{
    public class Board
    {
        public int Rows;
        public int Columns;
        public int NumOfPoints;
        public List<Point> Points = new List<Point>();
        public List<Line> Paths = new List<Line>();

        public Board(int rows, int columns, int numOfPoints)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.NumOfPoints = numOfPoints;

            int id = 1;
            
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    Point point = new Point(id, i, j, 0);
                    Points.Add(point);
                    id++;
                }
            }
        }
    }
}