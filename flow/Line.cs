using System.Collections.Generic;
using System.Linq;

namespace Flow
{
    public class Line
    {
        public int Color;
        public Point StartingPoint;
        public Point CurrentPoint;
        public Point EndingPoint;
        // Starting position is not included here, so we don't overwrite its color
        public List<Point> linePoints = new List<Point>();
        public int Length;
        public List<Step> Steps = new List<Step>();
        public bool IsValid;

        public Line(int color, Point startingPosition)
        {
            this.Color = color;
            this.StartingPoint = startingPosition;
            this.CurrentPoint = startingPosition;
            this.Length = 0;
            
            if (startingPosition.Color == this.Color)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
        }

        public int PerformStep(int stepNumber, Board board)
        {
            var step = Steps[stepNumber];
            var validStep = false;
            Length++;
            Point nextPoint = null;
            
            switch (step)
            {
                case Step.N:
                    if (CurrentPoint.Row > 1)
                    {
                        nextPoint = board.Points[CurrentPoint.Id - board.Columns - 1];
                    }
                    break;
                case Step.E:
                    if (CurrentPoint.Column < board.Columns)
                    {
                        nextPoint = board.Points[CurrentPoint.Id];
                    }
                    break;
                case Step.S:
                    if (CurrentPoint.Row < board.Rows)
                    {
                        nextPoint = board.Points[CurrentPoint.Id + board.Columns - 1];
                    }
                    break;
                case Step.W:
                    if (CurrentPoint.Column > 1)
                    {
                        nextPoint = board.Points[CurrentPoint.Id - 2];
                    }
                    break;
            }

            if (nextPoint != null)
            {
                // Special handling for last step
                if (stepNumber == Steps.Count - 1)
                {
                    if (nextPoint.Color == this.Color)
                    {
                        CurrentPoint = nextPoint;
                        EndingPoint = nextPoint;
                        validStep = true;
                    }
                } else if (nextPoint.Color == 0)
                {
                    CurrentPoint = nextPoint;
                    linePoints.Add(nextPoint);
                    nextPoint.Color = this.Color;
                    validStep = true;
                }
            }

            if (validStep == false)
            {
                // Reset point colors if line is invalid
                foreach (var point in linePoints)
                {
                    point.Color = 0;
                }
                this.IsValid = false;
            }
            
            return Length;
        }
    }
}