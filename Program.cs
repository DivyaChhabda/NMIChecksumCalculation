using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMICheckSum
{
    class Program
    {
       public  static void Main(string[] args)
        {
            string nmiInput;
            int length;
            Console.Write("Enetr the NMI Without CheckSum");
            nmiInput = Console.ReadLine();
            length = (nmiInput.Trim()).Length;
            if (length == 10)
            {
                int Checksum = getChecksum(nmiInput);
                Console.WriteLine("Checksum for Given NMI is" + Checksum);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enetr 10 Digit NMI");
                Console.ReadLine();
            }
        }
        public static int getChecksum(string nmiParam)
        {
                nmiParam = nmiParam.Trim();
                int length = nmiParam.Length,Total = 0,asciiValue = 0,finalChecksum = 0,checksum = 0;
                char letter;
                    for (int i = length - 1; i >= 0; i--)
                    {
                    int doubleValue = 0;
                    letter = nmiParam[i];
                        asciiValue = (int)(letter);
                        if (i % 2 != 0)
                        {
                            doubleValue = asciiValue * 2;
                            Total = getSumOfDigits(doubleValue);
                            checksum = checksum + Total;
                        }
                        else
                        {
                            Total = getSumOfDigits(asciiValue);
                            checksum = checksum + Total;
                        }
                    }
                    if (checksum % 10 != 0)
                    {
                        finalChecksum = calculateFinalChecksum(checksum);
                        return finalChecksum;
                    }
                    else return 0;   
        }
        private static int calculateFinalChecksum(int checksumParam)
        {
            int finalChecksumValue = 0;
            finalChecksumValue = (checksumParam / 10)+1;
            finalChecksumValue = finalChecksumValue * 10;
            finalChecksumValue = finalChecksumValue - checksumParam;
            return finalChecksumValue;   
        }
        private static int getSumOfDigits(int value)
        {
            int sum = 0, m;
            while(value>0)
            {
                m = value % 10;
                sum = sum + m;
                value = value / 10;
            }
            return sum;
        }
    }
}
