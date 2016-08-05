using System;

namespace Romans
{
    class Program
    {
        static void Main(string[] args)
        {
            ////consolidan sheyvana
            //while (true)
            //{
            //    Console.Write("Please enter a number: ");
            //    string S = Console.ReadLine().ToUpper();
            //    Console.WriteLine(correctRomans(S));
            //}


            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\ichedia\Desktop\output.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ichedia\Desktop\romans.txt");
            foreach (string line in lines)
            {
                file.WriteLine(correctRomans(line));

                //meore metodit
                //file.WriteLine(correctRomans2(line));
            }
            file.Close();

            // gamoaq consolshi romeli line gaaswora da sul ramdeni gaaswora
            int count = 0;
            int index = 0;
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\ichedia\Desktop\output.txt");
            foreach (string line in lines)
            {
                if (!line.Equals(lines2[index]))
                {
                    Console.WriteLine(line + "   " + lines2[index]);
                    count++;
                }
                index++;
            }
            Console.WriteLine(count);
        }

        public static string correctRomans(string S)
        {
            int sum = 0;
            int i = 0;
            for (i = 0; i < S.Length; i++)
            {
                if (i == S.Length - 1) sum += romansToNumber(S[i]);
                else if (romansToNumber(S[i]) >= romansToNumber(S[i + 1])) sum += romansToNumber(S[i]);
                else
                {
                    sum += romansToNumber(S[i + 1]) - romansToNumber(S[i]);
                    i++;
                }
            }
            return numbersToRoman(sum);
        }

        //romaulidan arabulshi
        public static int romansToNumber(char x)
        {
            if (x == 'I') return 1;
            else if (x == 'V') return 5;
            else if (x == 'X') return 10;
            else if (x == 'L') return 50;
            else if (x == 'C') return 100;
            else if (x == 'D') return 500;
            else if (x == 'M') return 1000;
            else return 0;
        }

        //arabulidan romaulshi
        public static string numbersToRoman(int sum)
        {
            string S = "";
            if (sum < 4) S += new String('I', sum);
            else if (sum == 4) S += "IV";
            else if (sum < 9) S += "V" + new String('I', sum - 5);
            else if (sum == 9) S += "IX";
            else if (sum < 40) S += new String('X', sum / 10) + numbersToRoman(sum % 10);
            else if (sum < 50) S += "XL" + numbersToRoman(sum % 10);
            else if (sum < 90) S += "L" + numbersToRoman(sum - 50);
            else if (sum < 100) S += "XC" + numbersToRoman(sum % 10);
            else if (sum < 400) S += new String('C', sum / 100) + numbersToRoman(sum % 100);
            else if (sum < 500) S += "CD" + numbersToRoman(sum % 100);
            else if (sum < 900) S += "D" + numbersToRoman(sum - 500);
            else if (sum < 1000) S += "CM" + numbersToRoman(sum % 100);
            else if (sum < 5000) S += new String('M', sum / 1000) + numbersToRoman(sum % 1000);
            else return "Dzalian didi ricxvia";
            return S;
        }

        //ufro martivad
        //meore varianti
        public static string correctRomans2(string S)
        {
            string K = S.Replace("VIIII", "IX");
            K = K.Replace("IIII", "IV");
            K = K.Replace("LXXXX", "XC");
            K = K.Replace("XXXX", "XL");
            K = K.Replace("DCCCC", "CM");
            K = K.Replace("CCCC", "CD");
            return K;
        }
    }
}
