using System;
using System.Collections.Generic;
using System.Text;

namespace ContravarianceDemo4_5
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DeptID { get; set; }

        public Employee(int id, string name, int did)
        {
            ID = id;
            Name = name;
            DeptID = did;
        }
    }

    public class Manager : Employee
    {
        public int Incentives { get; set; }

        public Manager(int id, string name, int did, int inc)
            : base(id, name, did)
        {
            Incentives = inc;
        }
    }

    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x.DeptID > y.DeptID)
                return 1;
            else if (x.DeptID < y.DeptID)
                return -1;

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee(101, "Allister", 30));
            empList.Add(new Employee(102, "Vel", 20));
            empList.Add(new Employee(103, "Steve", 40));
            empList.Add(new Employee(104, "Jasmine", 30));
            empList.Add(new Employee(105, "Rosy", 10));
            empList.Add(new Employee(106, "Stella", 20));

            EmployeeComparer empComparer = new EmployeeComparer();
            empList.Sort(empComparer);

            Console.WriteLine("Employee Details : ");
            foreach (var e in empList)
            {
                Console.WriteLine(e.ID + "\t" + e.Name + "\t" + e.DeptID);
            }

            List<Manager> mgrList = new List<Manager>();

            mgrList.Add(new Manager(201, "Robert", 40, 3899));
            mgrList.Add(new Manager(202, "Walt", 20, 4000));
            mgrList.Add(new Manager(203, "Jason", 20, 3899));
            mgrList.Add(new Manager(204, "Jasmin", 10, 5000));
            mgrList.Add(new Manager(205, "Maria", 30, 2000));
            mgrList.Add(new Manager(206, "Ruby", 40, 3899));

            mgrList.Sort(empComparer);

            Console.WriteLine("\nManager Details");
            foreach (Manager m in mgrList)
            {
                Console.WriteLine(m.ID + "\t" + m.Name + "\t" + m.DeptID + "\t" + m.Incentives);
            }

            Console.ReadKey();
        }
    }
}
