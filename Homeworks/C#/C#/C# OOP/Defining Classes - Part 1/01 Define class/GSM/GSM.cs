namespace DefineClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class GSM
    {
        private static GSM iPhone4S = new GSM("Apple", "iPhone 4s", 500m, "Bill", "Gates", "Li-Po", 200, 14, BatteryType.LiIon, 3.5, 14);
        private string manufacturer = null;
        private string model = null;
        private decimal price;
        private Owner owner;
        private Battery battery;
        private Display display;
        private ICollection<Call> callHistory;
        public GSM(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Owner = new Owner();
            this.Battery = new Battery();
            this.Display = new Display();
            this.callHistory = new List<Call>();
        }
        public GSM(string manufacturer, string model, string ownerFirstName, string ownerSecondName)
            : this(manufacturer, model)
        {
            this.Owner = new Owner(ownerFirstName, ownerSecondName);
        }
        public GSM(string manufacturer, string model, decimal price, string ownerFirstName, string ownerSecondName, string batteryModel, int batteryHoursIdle, int batteryHoursTalk, BatteryType batteryType, double displaySize, int displayNumberOfColors)
            : this(manufacturer, model, ownerFirstName, ownerSecondName)
        {
            this.Price = price;
            this.Battery.Model = batteryModel;
            this.Battery.HoursIdle = batteryHoursIdle;
            this.Battery.HoursTalk = batteryHoursTalk;
            this.Display.Size = displaySize;
            this.Display.NumberOfColors = displayNumberOfColors;
        }

        public static GSM IPhone4s
        {
            get { return iPhone4S; }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (this.Manufacturer == null)
                {
                    if (value.Length < 2 || !char.IsLetter(value[0]))
                    {
                        throw new ArgumentException("Unacceptable manufacturer name (less than two chars or do not start with letter).");
                    }
                    this.manufacturer = value;
                }
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (this.Model == null)
                {
                    if (value.Length < 2 || !char.IsLetter(value[0]))
                    {
                        throw new ArgumentException("Unacceptable model name (less than two chars or do not start with letter).");
                    }
                    this.model = value;
                }
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Input phone price less than 0.");
                }
                this.price = value;
            }
        }
        public Owner Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public ICollection<Call> CallHistory
        {
            get { return this.callHistory; }
        }

        public void AddCall(DateTime callDate, string calledNumber, int callDuration)
        {
            this.callHistory.Add(new Call(callDate, calledNumber, callDuration));
        }
        public void RemoveCall(Call callToRemove)
        {
            if (!this.callHistory.Contains(callToRemove))
            {
                throw new ArgumentException("Invalid call input.");
            }
            this.CallHistory.Remove(callToRemove);
        }
        public decimal CallPriceCalculate(decimal pricePerMinute)
        {
            decimal totalPrice = 0m;
            foreach (var call in this.CallHistory)
            {
                totalPrice += pricePerMinute * call.CallDuration / 60;
            }
            return totalPrice;
        }
        public void ClearCallsHistory()
        {
            this.CallHistory.Clear();
        }
        public override string ToString()
        {
            StringBuilder mobilePhoneInformation = new StringBuilder();
            mobilePhoneInformation.Append(string.Format("Manufacturer: {0,12}\n", this.manufacturer));
            mobilePhoneInformation.Append(string.Format("Model: {0,19}\n", this.model));
            mobilePhoneInformation.Append(string.Format("Owner: {0} {1}", this.owner.FirstName, this.owner.SecondName));
            return mobilePhoneInformation.ToString();
        }
    }
}