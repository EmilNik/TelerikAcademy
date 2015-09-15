using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class PhonebookSanitizer : IPhonebookSanitizer
    {
        private const string code = "+359";

        public string Sanitize(string phoneNumber)
        {
            StringBuilder sb = new StringBuilder();

            sb.Clear();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+')) sb.Append(ch);
            }

            if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
            {
                sb.Remove(0, 1); sb[0] = '+';
            }

            while (sb.Length > 0 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            if (sb.Length > 0 && sb[0] != '+')
            {
                sb.Insert(0, code);
            }

            sb.Clear();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    sb.Append(ch);
                }
            }

            if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
            {
                sb.Remove(0, 1); sb[0] = '+';
            }


            while (sb.Length > 0 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            if (sb.Length > 0 && sb[0] != '+')
            {
                sb.Insert(0, code);
            }

            sb.Clear();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    sb.Append(ch);
                }
            }

            if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
            {
                sb.Remove(0, 1); sb[0] = '+';
            }

            while (sb.Length > 0 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            if (sb.Length > 0 && sb[0] != '+')
            {
                sb.Insert(0, code);
            }
            return sb.ToString();
    }
    }
}
