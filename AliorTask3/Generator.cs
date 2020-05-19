using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliorTask3
{
    public class Generator
    {
        /// <description>
        /// In Romania each citizen has a Numerical Personal Code (Cod Numeric Personal - CNP),
        /// which is created by using the citizen's gender and century of birth (1/3/5/7 for male,
        /// 2/4/6/8 for female and 9 for foreign citizen), date of birth (encoded in six digits), 
        /// the country zone (encoded on 2 digits, from 1 to 52 or 99), followed by a serial number 
        /// (encoded on 3 digits) and a checksum (encoded on one digit) Ex: GYYMMDDCCNNNC.
        ///The first digit encodes the gender of person as follows:
        ///1
        ///male born between 1900 and 1999
        ///The country zone is a code of Romanian county in alphabetical order. For Bucharest the code is 4 followed by the sector number.
        ///The checksum is calculated as following: every digit from CNP is multiplied with the digit with 
        ///the same index from the number 279146358279, the results are sumed up and then divided by 11.
        ///If the remainder is 10 then the checksum digit is 1, otherwise is the remainder itself.
        /// </description>

        
      
        
        

        static void Main(string[] args)
        {
            int[] male = new int[1];
            var divider = 11;
            int count = 3;
            var minimal = 000;
            var maximal = 999;
            int[] bucharest = new int[1];
            int[] bucharestZoneNumArray = new int[1];
            int[] checkSumArray = new int[1];
            var date = GeneratorDaty.RandomDay();
            int[] sepOne =  new int[2];
            int[] sepTwo = new int[2];
            int[] sepThree = new int[2];
            int sum = 0;
            var CalculateMultTable = new int[12] { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };
            Separator separationOne = new Separator();
            Separator separationTwo = new Separator();
            Separator separationThree = new Separator();

            
            
            var stringCNPdate = date.ToString(CultureInfo.InvariantCulture).Substring(0, 8);
            char[] separator = new char[] {'/'}; 
            string[] stringCNPdateSeparated = stringCNPdate.Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
            int[] myInts = stringCNPdateSeparated.Select(int.Parse).ToArray();

            male[0] = 1;
            bucharest[0] = 4;
            if(myInts[0] < 10)
            {
                
                sepOne.SetValue(0,0);
                sepOne[1] = myInts[0];
            }
            else {sepOne = separationOne.NumbersIn(myInts[0]); }
            if (myInts[1] < 10)
            {
                sepTwo.SetValue(0, 0);
                sepTwo[1] = myInts[1];

            }
            else {sepTwo = separationOne.NumbersIn(myInts[1]); }
            if (myInts[2] < 10)
            {
                sepThree.SetValue(0, 0);
                sepThree[1] = myInts[2];

            }
            else {sepThree = separationOne.NumbersIn(myInts[2]); }
            //Generating 3 digits
            Random generateNumbers = new Random();
            var generateSerialNumber = generateNumbers.Next(minimal, maximal);
            //Random number generator for Bucharest Zone
            Random bucharestZone = new Random();
            var bucharestZoneNum = bucharestZone.Next(0, 6);
            bucharestZoneNumArray[0] = bucharestZoneNum;
            
            Separator sep = new Separator();
            var separatedSerialNumber = sep.NumbersIn(generateSerialNumber);

            int[] CNPpreMultiplied = new List<int>()
            .Concat(male)
            .Concat(sepOne)
            .Concat(sepTwo)
            .Concat(sepThree)
            .Concat(bucharest)
            .Concat(bucharestZoneNumArray)
            .Concat(separatedSerialNumber)
            .ToArray();

            for(int i = 0; i<12; i++)
            {
                
                int[] preChecksumArray = new int[12];
                preChecksumArray[i] = CNPpreMultiplied[i] * CalculateMultTable[i];
                sum += preChecksumArray[i];
                
                
                
            }
            var checkSum = sum % divider ;
            if(checkSum == 10)
            { checkSum = 1; }
            checkSumArray[0] = checkSum;
            int[] CNPArray = new List<int>()
            .Concat(male)
            .Concat(sepOne)
            .Concat(sepTwo)
            .Concat(sepThree)
            .Concat(bucharest)
            .Concat(bucharestZoneNumArray)
            .Concat(separatedSerialNumber)
            .Concat(checkSumArray)
            .ToArray();

            string CNP = string.Join("", CNPArray);
            Console.WriteLine("This is a CNP Generator . To generate CNP press any key");
            Console.ReadKey();
            Console.WriteLine("\n"+"*****************************************************************");
            Console.WriteLine(CNP);
            Console.ReadKey();
        }
    }
}
