using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSupport.RandomDataGenerator
{
    public static class RandomDataGenerator
    {
        private static Random random = new Random();

        public static string RandomStringOnlyLetters(int numberOfLetters)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, numberOfLetters).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringOnlyNumbers(int numberOfNumbers)
        {
            string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, numberOfNumbers).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomAlphaNumericString(int numberOfLetters)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, numberOfLetters).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomEmailAddress()
        {
            string domainChars = "abcdefghijklmnopqrstuvwxyz";
            string emailChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789._";

            string emailLocalPart = new string(Enumerable.Repeat(emailChars, random.Next(8, 13)).Select(s => s[random.Next(s.Length)]).ToArray());
            string emailDomain = new string(Enumerable.Repeat(domainChars, random.Next(4, 7)).Select(s => s[random.Next(s.Length)]).ToArray());

            return $"{emailLocalPart}@{emailDomain}.com";
        }

        public static bool RandomBool()
        {
            return random.Next(2) == 0;
        }

        public static int RandomNumber(int min = 0, int max = 2147483647)
        {
            return random.Next(min, max);
        }

        public static long RandomLongNumber(long min = 0, long max = 9223372036854775807)
        {
            int num1 = RandomNumber();

            if (max <= 2147483647) return num1;

            int num2 = RandomNumber();
            bool halved = RandomBool();

            return halved ? (num1 + num2) / 2 : (num1 + num2);

        }

        public static T RandomItemFromList<T>(List<T> list) where T : class
        {
            return list.ElementAt(RandomNumber(0, list.Count - 1));
        }
    }
}

