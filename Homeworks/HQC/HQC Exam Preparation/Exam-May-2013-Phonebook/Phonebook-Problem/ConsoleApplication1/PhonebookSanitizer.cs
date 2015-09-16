namespace Phonebook
{
    using System.Text;

    public class PhonebookSanitizer : IPhonebookSanitizer
    {
        private const string Code = "+359";

        public string Sanitize(string phoneNumber)
        {
            StringBuilder phoneNumberSanitazed = new StringBuilder();
            
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberSanitazed.Append(ch);
                }
            }

            if (phoneNumberSanitazed.Length >= 2 && phoneNumberSanitazed[0] == '0' && phoneNumberSanitazed[1] == '0')
            {
                phoneNumberSanitazed.Remove(0, 1);
                phoneNumberSanitazed[0] = '+';
            }

            while (phoneNumberSanitazed.Length > 0 && phoneNumberSanitazed[0] == '0')
            {
                phoneNumberSanitazed.Remove(0, 1);
            }

            if (phoneNumberSanitazed.Length > 0 && phoneNumberSanitazed[0] != '+')
            {
                phoneNumberSanitazed.Insert(0, Code);
            }

            return phoneNumberSanitazed.ToString();
        }
    }
}
