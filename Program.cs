using System.Data.Linq;

namespace LINQ
{
    internal class Program
    {
        static string connection = "server=TEJASGOWDA05\\SQLEXPRESS;initial catalog=day1;Integrated Security=SSPI";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //insert();
            reaedAll();
        }
        public static void insert()
        {
            DAY1DataContext context = new DAY1DataContext(connection);
            employee emp = new employee();
            emp.id = 10;
            emp.salary=200;
            emp.gender="male";
            emp.fullname="tejas";
            emp.dept=null;

            context.employees.InsertOnSubmit(emp);
            context.SubmitChanges();


        }
        public static void reaedAll()
        {
            DAY1DataContext context = new DAY1DataContext(connection);
            Table<employee> emps = context.GetTable<employee>();
            /*foreach (employee emp in emps)
            {
                Console.WriteLine(emp.fullname+" "+emp.salary);
            }*/

            var records = from r in context.employees where r.gender=="M"
                          select r;

            foreach (var emp in records)
            {
                Console.WriteLine(emp.fullname+" "+emp.salary);
            }
        }
    }
}
