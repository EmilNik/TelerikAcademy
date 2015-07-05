namespace Range_Exceptions
{
    using System;

    class InvalidRangeException<T> : Exception
    {
        private T startRange;
        private T endRange;

        public InvalidRangeException(string msg, T start, T end, Exception innerEx)
            : base(msg, innerEx)
        {
            this.StartRange = start;
            this.EndRange = end;
        }

        public InvalidRangeException(string msg, T start, T end)
            : this(msg, start, end, null)
        {
            this.StartRange = start;
            this.EndRange = end;
        }

        public T StartRange
        {
            get { return this.startRange; }
            private set { this.startRange = value; }
        }

        public T EndRange
        {
            get { return this.endRange; }
            private set { this.endRange = value; }
        }
    }
}
