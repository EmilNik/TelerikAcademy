namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        private string name;
        private string nameForConparison;

        public SortedSet<string> PhoneNumbers { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameForConparison = value.ToLowerInvariant();
            }
        }

        public override string ToString()
        {
            StringBuilder entryToString = new StringBuilder();
            entryToString.Append('[');
            entryToString.Append(this.Name);
            entryToString.Append(": ");

            var first = true;

            foreach (var phone in this.PhoneNumbers)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    entryToString.Append(", ");
                }

                entryToString.Append(phone);
            }

            entryToString.Append(']');

            return entryToString.ToString();
        }

        public int CompareTo(PhoneEntry other)
        {
            var comparison = this.nameForConparison.CompareTo(other.nameForConparison);
            return comparison;
        }
    }
}
