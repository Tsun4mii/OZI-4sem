using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_6
{
    public class RSA
    {
        public long e;
        public long n;
        public long d;
        public string input;
        public List<string> encoded;
        public string output;

        public RSA()
        {
            Console.WriteLine("Введите е ");
            e = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите n ");
            n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите d ");
            d = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите текст для шифрования ");
            input = Console.ReadLine();

            encoded = RSA_Encode(input, e, n);

            foreach(string item in encoded)
            {
                Console.WriteLine(item);
            }

            output = RSA_Decode(encoded, d, n);

            Console.WriteLine(output);

        }

        public List<string> RSA_Encode(string input, long e, long n)
        {
            List<string> result = new List<string>();
            BigInteger bi;
            for(int i = 0; i < input.Length; i++)
            {
                long index = Convert.ToInt64(input[i]);
                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger _n = new BigInteger((int)n);

                bi = bi % _n;
                result.Add(bi.ToString());
            }
            return result;
        }

        public string RSA_Decode(List<string> input, long d, long n)
        {
            string result = "";
            BigInteger bi;

            foreach(string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger _n = new BigInteger((int)n);
                bi = bi % _n;

                result += (char)bi;
            }
            return result;
        }
    }
}
