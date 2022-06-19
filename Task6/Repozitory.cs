using System;


namespace Task6
{
    struct Repozitory
    {
        public Employee[] employee;

        public Employee this[int index]
        {
            get { return employee[index]; }
            set { employee[index] = value; }
        }
        public Repozitory(params Employee[] Args)
        {
            employee = Args;
        }

        public void SortingInAscedingOrder()
        {
            Array.Sort(employee, new Comparison<Employee>((a, b) => a.Date.CompareTo(b.Date)));
        }

        public void SortingByDescedingOrder()
        {
            Array.Sort(employee, new Comparison<Employee>((a, b) => b.Date.CompareTo(a.Date)));
        }
    }
}
