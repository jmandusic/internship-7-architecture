using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Helpers
{
    public static class ReadHelper
    {
        public static int InputNumberCheck()
        {
            while (true)
            {
                var isNumber = int.TryParse(Console.ReadLine(), out var number);
                if (isNumber && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(ResponseResultType.ValidationError);
                }
            }
        }

        public static string LineInputCheck()
        {
            while (true)
            {
                var readLine = Console.ReadLine();
                if (!string.IsNullOrEmpty(readLine))
                {
                    return readLine;
                }
                else
                {
                    Console.WriteLine(ResponseResultType.ValidationError);
                }
            }
        }

        public static bool TryReadLineIfNotEmpty(out string readValue)
        {
            var readLine = Console.ReadLine();
            if (string.IsNullOrEmpty(readLine))
            {
                readValue = null;
                return false;
            }

            readValue = readLine;
            return true;
        }
    }
}
