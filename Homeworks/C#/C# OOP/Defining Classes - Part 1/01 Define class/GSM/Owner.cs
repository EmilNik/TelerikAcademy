namespace DefineClass
{
    using System;
    public struct Owner
    {
        private string firstName;
        private string secondName;

        public Owner(string firstName, string secondName)
            : this()
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length < 2 || !char.IsLetter(value[0]))
                {
                    throw new ArgumentException("Unacceptable owner first name (less than two chars or do not start with letter).");
                }
                this.firstName = value;
            }
        }
        public string SecondName
        {
            get
            {
                return this.secondName;
            }
            set
            {
                if (value.Length < 2 || !char.IsLetter(value[0]))
                {
                    throw new ArgumentException("Unacceptable owner second name (less than two chars or do not start with letter).");
                }
                this.secondName = value;
            }
        }
    }
}