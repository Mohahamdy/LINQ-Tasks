namespace FirstTask
{
    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] subjects { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*----- first section -----*/
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            //Query 1 
            var q1 = numbers.Select(n => n).OrderBy(n=>n).Distinct();

            foreach (var num in q1)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("============================================");
            
            //Query 2
            var q2 = numbers.OrderBy(n => n).Distinct().Select(n =>new { Numbers = n, Multiplication = n*n });

            foreach (var num in q2)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("============================================");



            /*----- second section -----*/
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            //Query 1
            var q3 = names.Where(n => n.Length == 3);
            
            foreach (var n in q3)
            {
                Console.WriteLine(n);
            }


            var q4 = from n in names
                     where n.Length == 3
                     select n;

            foreach (var n in q4)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("============================================");

            //Query 2 
            var q5 = names.Where(n => n.ToLower().Contains("a")).OrderBy(n => n.Length);

            foreach(var n in q5)
            {
                Console.WriteLine(n);
            }


            var q6 = from n in names
                     where n.ToLower().Contains("a")
                     orderby n.Length
                     select n;

            foreach (var n in q6)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("============================================");

            //Query 3
            var q7 = names.Take(2);

            foreach (var n in q7)
            {
                Console.WriteLine(n);
            }


            var q8 = from n in names.Take(2)
                     select n;

            foreach (var n in q8)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("============================================");


            /*----- Third section -----*/
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    ID = 1,
                    FirstName = "Ali",
                    LastName = "Mohammed",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 22, Name = "EF" },
                        new Subject() { Code = 33, Name = "UML" }
                    }
                },
                new Student()
                {
                    ID = 2,
                    FirstName = "Mona",
                    LastName = "Gala",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 22, Name = "EF" },
                        new Subject() { Code = 34, Name = "XML" },
                        new Subject() { Code = 25, Name = "JS" }
                    }
                },
                new Student()
                {
                    ID = 3,
                    FirstName = "Yara",
                    LastName = "Yousf",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 22, Name = "EF" },
                        new Subject() { Code = 25, Name = "JS" }
                    }
                },
                new Student()
                {
                    ID = 1,
                    FirstName = "Ali",
                    LastName = "Ali",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 33, Name = "UML" }
                    }
                }
            };

            //Query 1
            var q9 = students.Select(s => new {FullName = s.FirstName+" "+s.LastName ,NoOfSubjects = s.subjects.Length});
            
            foreach(var s in q9)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("============================================");

            //Query 2
            var q10 = students.OrderByDescending(s=>s.FirstName).ThenBy(s=> s.LastName).Select(s=>s.FirstName+" "+s.LastName);

            foreach (var n in q10)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("============================================");

            //Query 3 
            var q11 =students.SelectMany(s => s.subjects.Select(sub=> new {Fullname = s.FirstName+" "+s.LastName,SubjectName= sub.Name}));
            var q13 = students.SelectMany(s=>s.subjects,(s,sub)=> new { Fullname = s.FirstName + " " + s.LastName, SubjectName = sub.Name });

            foreach (var s in q11)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("============================================");

            //Query 4 
            var q12 = students.GroupBy(s => s.FirstName + " " + s.LastName);

            foreach (var s in q12)
            {
                Console.WriteLine(s.Key);

                foreach (var stu in s)
                {
                    foreach (var sub in stu.subjects)
                    {
                        Console.WriteLine($"\t{sub.Name}");
                    }
                }
                
            }

            /*var q14 = students.GroupBy(s => s.FirstName + " " + s.LastName,s=>s.subjects,(s,sub) =>new { });*/
        }
    }
}
