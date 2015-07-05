namespace DefineClass
{
    using System;
    public class Call
    {
        private DateTime callDate;
        private string calledNumber;
        private int callDuration;
        public Call(DateTime callDate, string calledNumber, int callDuration)
        {
            this.CallDate = callDate;
            this.CalledNumber = calledNumber;
            this.CallDuration = callDuration;
        }
        public DateTime CallDate
        {
            get
            {
                return this.callDate;
            }
            set
            {
                if (value.GetType() != typeof(DateTime))
                {
                    throw new ArgumentException("Invalid call date input. Should be DateTime format.");
                }
                this.callDate = value;
            }
        }
        public string CalledNumber
        {
            get
            {
                return this.calledNumber;
            }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Unacceptable called phone number (less than two chars).");
                }
                this.calledNumber = value;
            }
        }
        public int CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid call duration input. Call duration must be >0.");
                }
                this.callDuration = value;
            }
        }
    }
}