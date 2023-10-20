using System.Security.Cryptography;

namespace _2M_07_VeryBigInt
{
    class VBInt
    {
        public string vbint { get; private set; }
        private bool czyLiczba = true;
        public VBInt(string liczba="0")
        {
            //sprawdzić czy składa się z samych cyfr
            vbint = liczba;
        }
        public static VBInt operator+(VBInt a, VBInt b)
        {
            int n1 = a.vbint.Length - 1;
            int n2 = b.vbint.Length - 1;
            int n = Math.Min(n1, n2);
            int p = 0;
            string w = "";
            for(int i = 0; i<=n; i++)
            {
                int x1 = int.Parse(a.vbint[n1-i].ToString());
                int x2 = int.Parse(b.vbint[n2-i].ToString());
                int x = p + x1 + x2;
                w = (x % 10).ToString() + w;
                p = x / 10;                
            }
            string s;
            if (n1 > n2)
                s = a.vbint;
            else
                s = b.vbint;
            int m = Math.Max(n1, n2);
            for (int i = 0; i<m - n; i++)
            {
                int x1 = int.Parse(s[m - n - 1 -i].ToString());
                int x = x1 + p;
                w = (x % 10).ToString() + w;
                p = x / 10;
            }

            return new VBInt(w);
        }
        public override string ToString()
        {
            if(czyLiczba)
                return vbint;
            else 
                return "ERR";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            VBInt n1 = new VBInt("343254343");
            Console.WriteLine(n1);
            VBInt n2 = new VBInt( "349284");
            Console.WriteLine(n2);
            Console.WriteLine(n1+ n2);
        }
    }
}