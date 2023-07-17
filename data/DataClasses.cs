namespace EmployeeTest.data
{
    
    public abstract class Employee
    {
        private float _vacationDays = 0;
        public int _workDays = 0;
        public float VacationDays { get { return _vacationDays; } }
        public int WorkDays { get { return _workDays; } }
        public abstract float VacationDaysPerWorkYear { get; }

        public void Work(int days)
        {
            if (days < 0 || days > 260)
                throw new ArgumentException("Days worked must be a value between 0 and 260.");

            _vacationDays += days * (VacationDaysPerWorkYear / 260);
            _workDays += days;
        }

        public void TakeVacation(float days)
        {
            if (days < 0 || days > _vacationDays)
                throw new ArgumentException("Cannot take more vacation than is available.");

            _vacationDays -= days;
        }
    }

    
    public class HourlyEmployee : Employee
    {
        public override float VacationDaysPerWorkYear { get { return 10; } }
    }

    
    public class SalariedEmployee : Employee
    {
        public override float VacationDaysPerWorkYear { get { return 15; } }
    }

    
    public class Manager : Employee
    {
        public override float VacationDaysPerWorkYear { get { return 30; } }
    }
    
    public static class EmployeeFactory
    {
        public static Employee CreateEmployee(string type)
        {
            switch (type)
            {
                case "Hourly":
                    return new HourlyEmployee();
                case "Salaried":
                    return new SalariedEmployee();
                case "Manager":
                    return new Manager();
                default:
                    throw new ArgumentException("Invalid employee type.");
            }
        }
    }
    
    public class EmployeeService
    {
        public List<Employee> Employees { get; private set; }

        public EmployeeService()
        {
            Employees = new List<Employee>();
            for (int i = 0; i < 10; i++)
            {
                Employees.Add(EmployeeFactory.CreateEmployee("Hourly"));
                Employees.Add(EmployeeFactory.CreateEmployee("Salaried"));
                Employees.Add(EmployeeFactory.CreateEmployee("Manager"));
            }
        }
    }
}
