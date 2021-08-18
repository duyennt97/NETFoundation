using System;
using System.IO;
using System.Reflection;

namespace NetFoundation
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student(){RollNr = 100, Name = "ABC"};
            GetObjInfo(a);
            
        }

        public static string RockPaperScissors(string first, string second)
            => (first, second) switch
            {
                ("rock", "paper") => "rock is covered by paper. Paper wins.",
                ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                ("paper", "rock") => "paper covers rock. Paper wins.",
                ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                (_, _) => "tie"
            };

        private static void GetObjInfo(object student)
        {
            var type = student.GetType();
            Console.WriteLine($"Class {type.Name}");

            foreach (var pro in student.GetType().GetProperties())
            {
                Console.WriteLine("{0}={1}", pro.Name, pro.GetValue(student));
            }


            //Get and display the method.
            var methods = type.GetMethods();
            foreach (var med in methods)
            {
                Console.WriteLine("Method " + med.Name + " return " +  med.ReturnType);
                foreach(ParameterInfo param in med.GetParameters())
                {
                    Console.WriteLine(param.ParameterType.Name + " - " + param.Name);
                }
            }
        }

        static void WriteFile()
        {
            using (StreamWriter c = new StreamWriter(@"E:\Training\testfile.txt", true))
            {
                c.WriteLine("hello");
            }

            //try
            //{
            //    StreamWriter c = new StreamWriter(@"C:\Users\xxx\Desktop\important.txt", true);
            //}
            //finally
            //{
            //    c.Close();
            //}
        }

        class Student
        {
            public int RollNr { get; set; }
            public string Name { get; set; }
            public Student()
            {
                
            }

            protected Student(int roll, string name)
            {
                RollNr = roll;
                Name = name;
            }

            public void MedthodABC(float score, DateTime time)
            {

            }
        }
    }
}
