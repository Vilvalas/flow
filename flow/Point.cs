using System;

namespace Flow
{
    public class Point
    {
        public int Id;
        public int Row;
        public int Column;
        public int Color;
        public bool Handled = false;

        public Point(int id, int row, int column, int color)
        {
            this.Id = id;
            this.Row = row;
            this.Column = column;
            this.Color = color;
        }
        
        public Point(int id, int color, Board board)
        {
            var row = 1;
            int column;

            while (id > row * board.Columns)
            {
                row++;
            }

            column = id - ((row - 1) * board.Columns);

            this.Id = id;
            this.Row = row;
            this.Column = column;
            this.Color = color;
        }

        public int CalcManhattanDistance(Point point2)
        {
            return Math.Abs(Row - point2.Row) +
                   Math.Abs(Column - point2.Column);
        }
    }
}