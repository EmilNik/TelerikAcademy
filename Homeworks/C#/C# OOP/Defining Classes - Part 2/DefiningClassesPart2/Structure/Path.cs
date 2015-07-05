namespace Space3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }

        public int Count
        {
            get
            {
                return this.points.Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.points[index];
            }
            set
            {
                this.points[index] = value;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public void AddPoints(params Point3D[] point)
        {
            this.points.AddRange(point);
        }

        public void AddPoints(ICollection<Point3D> point)
        {
            this.points.AddRange(point);
        }

        public override string ToString()
        {
            return String.Join(" -> ", this.points);
        }
    }
}