/*Завдання 3:
Додайте до першого завдання клас, який містить інформацію про
працівників. Потрібно зберігати такі дані:
 ПІБ співробітника
 Посада
 Контактний телефон
 Email
 Заробітна плата
Помістіть інформацію про працівників всередину фірми.
Для масиву співробітників фірми реалізуйте наступні запити:
 Отримати список усіх працівників певної фірми.
 Отримати список усіх працівників певної фірми, в яких
заробітна плата більша заданої.
 Отримати список працівників усіх фірм, в яких є посада
«Менеджер».
 Отримати список працівників, в яких телефон починається з
«23».
 Отримати список працівників, в яких Email починається з
«di».
 Отримати список працівників з ім'ям Lionel.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Company_And_Employee
{
    class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Profile { get; set; }
        public string CEO { get; set; }
        public int NumberOfWorkers { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }

        public Company(string name, DateTime foundationDate, string profile,
                       string ceo, int numberOfWorkers, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            Profile = profile;
            CEO = ceo;
            NumberOfWorkers = numberOfWorkers;
            Address = address;
            Employees = new List<Employee>();
        }
    }

    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public Employee(string fullName, string position, string contactPhone, string email, decimal salary)
        {
            FullName = fullName;
            Position = position;
            ContactPhone = contactPhone;
            Email = email;
            Salary = salary;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Company> companies = new List<Company>
            {
                new Company("Food For You", DateTime.Now.AddYears(-3), "Продукты питания", "John Tomas", 150, "New York"),
                new Company("IT Thought", DateTime.Now.AddYears(-2), "IT", "Jane Doe", 200, "San Francisco"),
                new Company("Marketing For Everyone", DateTime.Now.AddYears(-1), "Маркетинг", "Michael Duglas", 80, "London"),
                new Company("White Nights", DateTime.Now.AddYears(-4), "IT", "Terry White", 300, "London"),
                new Company("Black Doors", DateTime.Now.AddYears(-5), "Маркетинг", "Bob Black", 120, "Paris")
            };

            
            companies[0].Employees.AddRange(new List<Employee>
            {
                new Employee("German Reizvich", "Manager", "23123456", "ger.reizv@example.com", 50000),
                new Employee("Eric Milk", "Developer", "23123434", "er.mil@example.com", 55000)
            });

            companies[1].Employees.AddRange(new List<Employee>
            {
                new Employee("Dinoj Daltol", "Analyst", "23090909", "din.dal@example.com", 51000),
                new Employee("George Ganza", "Designer", "23808080", "geo.gan@example.com", 52300)
            });

            companies[2].Employees.AddRange(new List<Employee>
            {
                new Employee("Lionel Pink", "Manager", "22334455", "lion.pink@example.com", 56800),
                new Employee("Soul Helper", "Developer", "22446677", "sol.help@example.com", 57000)
            });

            companies[3].Employees.AddRange(new List<Employee>
            {
                new Employee("Dan Balan", "Analyst", "22113344", "dan.bal@example.com", 59000),
                new Employee("Emma Toys", "Designer", "22778899", "emma.tous@example.com", 69100)
            });

            companies[4].Employees.AddRange(new List<Employee>
            {
                new Employee("Robert Green", "Manager", "22554466", "robert.green@example.com", 55400),
                new Employee("Fisher Jock", "Developer", "22990011", "fish.joker@example.com", 56800)
            });

            

            
            var employeesOfFoodForYou = from c in companies
                                        where c.Name == "Food For You"
                                        from e in c.Employees
                                        select e;

            
            decimal minSalary = 58000;
            var highSalaryEmployees = from c in companies
                                      from e in c.Employees
                                      where e.Salary > minSalary
                                      select e;

            
            var managerEmployees = from c in companies
                                   from e in c.Employees
                                   where e.Position == "Manager"
                                   select e;

            
            var phoneStartsWith23Employees = from c in companies
                                             from e in c.Employees
                                             where e.ContactPhone.StartsWith("23")
                                             select e;

            
            var emailStartsWithDiEmployees = from c in companies
                                             from e in c.Employees
                                             where e.Email.StartsWith("di")
                                             select e;

            
            var lionelEmployees = from c in companies
                                  from e in c.Employees
                                  where e.FullName.Contains("Lionel")
                                  select e;

            Console.WriteLine("Работники Food For You:");
            DisplayEmployees(employeesOfFoodForYou);

            Console.WriteLine("\nРаботники с высокой зарплатой:");
            DisplayEmployees(highSalaryEmployees);

            Console.WriteLine("\nМенеджери:");
            DisplayEmployees(managerEmployees);

            Console.WriteLine("\nТелефон начинается с 23:");
            DisplayEmployees(phoneStartsWith23Employees);

            Console.WriteLine("\nEmail начинается с di:");
            DisplayEmployees(emailStartsWithDiEmployees);

            Console.WriteLine("\nРаботник с именем Lionel:");
            DisplayEmployees(lionelEmployees);

            Console.ReadKey();
        }

        static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FullName}, \t" +
                                  $"{employee.Position}, " +
                                  $"{employee.Salary} грн, " +
                                  $"Контактний телефон: {employee.ContactPhone}, " +
                                  $"Email: {employee.Email}");
            }
        }
    }
}

