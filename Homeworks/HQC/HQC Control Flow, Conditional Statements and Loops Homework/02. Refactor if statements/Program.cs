using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_if_statements
{
    class Program
    {
        static void Main(string[] args)
        {
            //first if
            Potato potato;
            //... 
            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }

            //second if
            bool isXInRange = IsInRange(x, MinX, MaxX);
            bool isYInRange = IsInRange(y, MinY, MaxY);

            if (isXInRange && isYInRange && shouldVisitCell)
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
            throw new NotImplementedException("TODO");
        }
    }
}