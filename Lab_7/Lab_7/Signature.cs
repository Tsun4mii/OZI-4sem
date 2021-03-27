using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_7
{
    public class Signature
    {
        public long e;
        public long n;
        public long d;
        public BigInteger h;
        public BigInteger h_2;
        public BigInteger h_3;
        public BigInteger s;
        public string input;
        
        public Signature()
        {
            Console.WriteLine("Введите е ");
            e = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите n ");
            n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите d ");
            d = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите текст для отправки ");
            input = Console.ReadLine();

            h = GetHashCode_ForInput(input);
            int res = 0;
            for (int i = 0; i < input.Length; i++)
            {
                res += input[i];
            }
            Console.WriteLine(res);
            Console.WriteLine(h);
            
            s = GetHashImage(h, d, n);

            h_2 = GetHashImage_Reciver(input);
            Console.WriteLine(h == h_2);

            h_3 = GetHashImage_ReciverSigniture(s, e, n);

            Console.WriteLine(h_2 == h_3);
        }
        static public BigInteger GetHashImage(BigInteger h, long d, long n)
        {
            BigInteger _n = new BigInteger((int)n);
            BigInteger s = BigInteger.Pow(h, (int)d) % _n;
            Console.WriteLine($"s: {s}");
            return s;
        }

        public BigInteger GetHashImage_Reciver(string input)
        {
            BigInteger h_2 =  new  BigInteger(GetHashCode_ForInput(input));
            Console.WriteLine($"h_2: {h_2}");
            return h_2;
        }

        public BigInteger GetHashImage_ReciverSigniture(BigInteger s, long e, long n)
        {
            BigInteger _n = new BigInteger((int)n);
            BigInteger h_3 = BigInteger.Pow(s, (int)e) % _n;
            Console.WriteLine($"h_3: {h_3}");
            return h_3;
        }

        public int GetHashCode_ForInput(string input)
        {
            int res = 0;
            for(int i = 0; i < input.Length; i++)
            {
                res += input[i]; 
            }
            return res;
        }
    }
}
