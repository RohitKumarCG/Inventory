using System;

namespace TupleExample

{
    class Program
    {
        static dynamic GetPersonDetails()
        {
            var person = new { personName = "Scott", age = 20, email = "scott@gmail.com", dateOfJoining = Convert.ToDateTime("2019-9-5") };
            return person;
        }
        static Tuple<string, int, string, DateTime> GetPersonDetails2()
        {
            var person = new Tuple<string, int, string, DateTime>("sai", 20, "sai@gmail.com", Convert.ToDateTime("2019-9-5"));
            return person;
        }
        static(string, int, string, DateTime) GetPersonDetails3()
        {

            string personName = "sai";
            int age = 20;
            string email = "sai@gmail.com";
            var person = (personName, age, email, Convert.ToDateTime("2019-9-5"));
            return person;
        }
        static void Sample(out int x)
        {
            x = 10;
        }

        private static void Main()
        {
            var p = Program.GetPersonDetails3();
            var s = Program.GetPersonDetails2();

            Console.WriteLine(p.Item2);
            p.Item2 = 60;
            Console.WriteLine(p.Item2);
            (string personName, int age, _, DateTime dateOfJoining)= Program.GetPersonDetails3();

            Console.WriteLine(s.Item1+s.Item2);
            Program.Sample(out _);
            Console.WriteLine("hello"+"o".ToUpper());
            string sai = "Capgemini";
            sai.Remove(3);
            Console.WriteLine(sai);
            char[] ch = new char[] { (char)67, (char)97 };
            string s2 = new string(ch);
            Console.WriteLine(sai.IndexOf("i"));
            Console.WriteLine(sai.IndexOf("i",7));
            Console.WriteLine($"{sai} is located at");
            Console.WriteLine("{0} is located at", sai);
            Console.ReadKey();
        }
    }
}
