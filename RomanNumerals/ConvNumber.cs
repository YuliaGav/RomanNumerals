using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class ConvNumber : IConvNumbers
    {

        public int ToArabicNumerals(string romanNumeral)
        {
            int sum = 0;
            int prev = 0;
            int current = 0;
            foreach (char c in romanNumeral.Reverse())
            {
                current = myArabicNumeral(c);
                if (current >= prev)
                {
                    sum += current;
                    prev = current;
                }
                else sum -= current;
            }
            return sum;
        }

        public string ToRomanNumerals(int arabic)
        {
            int currentArabic = 0;

            if ((arabic > 2000) || (arabic <= 0)) throw new ArgumentOutOfRangeException(nameof(arabic));
            string[] res = { "", "", "", "" };
            for (int n = 0, currentRoman = 1, ancorRoman = 0, copy = arabic; n < 4 && copy > 0; n++, currentRoman *= 10, ancorRoman = 0, copy /= 10)
            {
                currentArabic = (copy < 10) ? copy : (copy % 10);
                if (currentArabic != 0)

                {
                    StringBuilder stringBuilder = new StringBuilder();
                    while (stringBuilder.Length == 0)
                    {
                        if (currentArabic == ancorRoman / currentRoman - 1)
                        {
                            stringBuilder = stringBuilder.Append(myRomanNumeral(currentRoman));
                            currentArabic++;

                        }
                        if (currentArabic >= ancorRoman / currentRoman && currentArabic <= ancorRoman / currentRoman + 3)
                        {
                            for (int k = ancorRoman / currentRoman; k <= currentArabic; k++)
                                stringBuilder = stringBuilder.Append(myRomanNumeral((k == ancorRoman / currentRoman) ? ancorRoman : currentRoman));
                        }
                        else
                        {
                            ancorRoman = (ancorRoman == 0) ? (currentRoman * 5): (currentRoman * 10);

                        }
                    }

                    res[n] = stringBuilder.ToString();

                }
            }
            StringBuilder stringresBuilder = new StringBuilder();
            for (int i = 3; i >= 0; i--)
                stringresBuilder = stringresBuilder.Append(res[i]);

            return stringresBuilder.ToString();
        }

        private string myRomanNumeral(int i) =>
            i switch
            {
                1 => "I",
                5 => "V",
                10 => "X",
                50 => "L",
                100 => "C",
                500 => "D",
                1000 => "M",
                _ => ""
            };

        int myArabicNumeral(char i) =>
            i switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
    }
}
