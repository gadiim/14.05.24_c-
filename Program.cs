using _14._05._24_c_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Тема: Вступ до LINQ
//Модуль 13. Частина 1

namespace _14._05._24_c_
{  
    internal class Program
    {
        static void Main(string[] args)
        {

            //Завдання 1:
            //Реалізуйте користувацький тип «Фірма». В ньому має бути
            //інформація про назву фірми, дату заснування, профіль бізнесу
            //(маркетинг, IT, і т. д.), ПІБ директора, кількість працівників,
            //адреса.
            //Для масиву фірм реалізуйте такі запити:
            // Отримати інформацію про всі фірми.
            // Отримати фірми, які мають у назві слово «Food».
            // Отримати фірми, які працюють у галузі маркетингу.
            // Отримати фірми, які працюють у галузі маркетингу або IT.
            // Отримати фірми з кількістю працівників більшою, ніж 100.
            // Отримати фірми з кількістю працівників у діапазоні від 100
            //до 300.
            // Отримати фірми, які знаходяться в Лондоні.
            // Отримати фірми, в яких прізвище директора White.
            // Отримати фірми, які засновані більше двох років тому.
            // Отримати фірми з дня заснування яких минуло 123 дні.
            // Отримати фірми, в яких прізвище директора Black і мають у
            //назві фірми слово «White».

            Console.WriteLine($"Task 1\n");

            List<Firm> firms = GetFirmsAndEmployees();

            Console.Write("all firms:\t\t\t");
            var all_firms = firms.Select(i => i.Name).ToList();
            Display(all_firms);

            Console.Write("food name firms:\t\t");
            var food_firms = firms.Where(i => i.Name.Contains("Food")).Select(i => i.Name).ToList();
            Display(food_firms);

            Console.Write("marketing firms:\t\t");
            var marketing_firms = firms.Where(i => i.BusinessProfile.ToLower().Contains("marketing")).Select(i => i.Name).ToList();
            Display(marketing_firms);

            Console.Write("marketing or IT firms:\t\t");
            var marketing_or_it_firms = firms.Where(i => (i.BusinessProfile.ToLower().Contains("marketing") || i.BusinessProfile.ToLower().Contains("it"))).Select(i => i.Name).ToList();
            Display(marketing_or_it_firms);

            Console.Write("more 100 employees:\t\t");
            var more_100_employees = firms.Where(i => i.NumberOfEmployees >= 100).Select(i => i.Name).ToList();
            Display(more_100_employees);

            Console.Write("range 100-300 employees:\t");
            var range_100_300_employees = firms.Where(i => i.NumberOfEmployees >= 100 && i.NumberOfEmployees <= 300).Select(i => i.Name).ToList();
            Display(range_100_300_employees);

            Console.Write("london firms:\t\t\t");
            var london_firms = firms.Where(i => i.Address.Any(a => a.City.ToLower() == "london")).Select(i => i.Name).ToList();
            Display(london_firms);

            Console.Write("director white firms:\t\t");
            var director_white_firms = firms.Where(i => i.DirectorName.ToLower().Contains("white")).Select(i => i.Name).ToList();
            Display(director_white_firms);

            Console.Write("2 years ago founded firms:\t");
            DateTime years_ago = DateTime.Now.AddYears(-2);
            var years_ago_firms = firms.Where(i => i.FoundationYear <= years_ago).Select(i => i.Name).ToList();
            Display(years_ago_firms);

            Console.Write("123 days ago founded firms:\t");
            DateTime days_ago = DateTime.Now.AddDays(-123);
            var days_ago_firms = firms.Where(i => i.FoundationYear <= days_ago).Select(i => i.Name).ToList();
            Display(days_ago_firms);

            Console.Write("black & white firms:\t\t");
            var black_white_firms = firms.Where(i => i.DirectorName.ToLower().Contains("black") && i.Name.ToLower().Contains("white")).Select(i => i.Name).ToList();
            Display(black_white_firms);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 2:
            //Реалізуйте запити з першого завдання з використанням
            //синтаксису методів розширень.

            Console.WriteLine($"Task 2\n");

            Console.WriteLine("Next . . .");

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 3:
            //Додайте до першого завдання клас, який містить інформацію про
            //працівників.Потрібно зберігати такі дані:
            // ПІБ співробітника
            // Посада
            // Контактний телефон
            // Email
            // Заробітна плата
            //Помістіть інформацію про працівників всередину фірми.
            //Для масиву співробітників фірми реалізуйте наступні запити:
            // Отримати список усіх працівників певної фірми.
            // Отримати список усіх працівників певної фірми, в яких
            //заробітна плата більша заданої.
            // Отримати список працівників усіх фірм, в яких є посада
            //«Менеджер».
            // Отримати список працівників, в яких телефон починається з
            //«23».
            // Отримати список працівників, в яких Email починається з
            //«di».
            // Отримати список працівників з ім'ям Lionel.

            Console.WriteLine($"Task 3\n");

            Console.Write("\"food company\" employees:\t");
            var food_employees = firms  .Where(f => f.Name.Contains("Food"))
                                        .SelectMany(f => f.Employees)
                                        .Select(e => e.FullName)
                                        .ToList();
            Display(food_employees);

            Console.Write("\"white company\" employees:\t");
            var white_employees = firms .Where(f => f.Name.Contains("White"))
                                        .SelectMany(f => f.Employees)
                                        .Select(e => e.FullName)
                                        .ToList();
            Display(white_employees);

            Console.Write("\"it company\" employees:\t\t");
            var it_employees = firms    .Where(f => f.Name.Contains("IT"))
                                        .SelectMany(f => f.Employees)
                                        .Select(e => e.FullName)
                                        .ToList();
            Display(it_employees);

            Console.WriteLine("salary more then 2000");

            Console.Write("\"food company\" employees:\t");
            var food_employees_salary = firms   .Where(f => f.Name.Contains("Food"))
                                                .SelectMany(f => f.Employees)
                                                .Where(e => e.Salary > 2000)
                                                .Select(e => e.FullName)
                                                .ToList();
            Display(food_employees_salary);

            Console.Write("\"white company\" employees:\t");
            var white_employees_salary = firms  .Where(f => f.Name.Contains("White"))
                                                .SelectMany(f => f.Employees)
                                                .Where(e => e.Salary > 2000)
                                                .Select(e => e.FullName)
                                                .ToList();
            Display(white_employees_salary);

            Console.Write("\"it company\" employees:\t\t");
            var it_employees_salary = firms     .Where(f => f.Name.Contains("IT"))
                                                .SelectMany(f => f.Employees)
                                                .Where(e => e.Salary > 2000)
                                                .Select(e => e.FullName)
                                                .ToList();
            Display(it_employees_salary);

            Console.Write("\"manager\" position employees:\t");
            var manager_position_employees = firms  .SelectMany(f => f.Employees)
                                                    .Where(e => e.Position.ToLower().Contains("manager"))
                                                    .Select(e => e.FullName)
                                                    .ToList();
            Display(manager_position_employees);

            Console.Write("starts \"23\" phone employees:\t");
            var starts_23_phone_employees = firms   .SelectMany(f => f.Employees)
                                                    .Where(e => e.Phone.StartsWith("23"))
                                                    .Select(e => e.FullName)
                                                    .ToList();
            Display(starts_23_phone_employees);

            Console.Write("starts \"di\" email employees:\t");
            var starts_di_email_employees = firms   .SelectMany(f => f.Employees)
                                                    .Where(e => e.Email.StartsWith("di"))
                                                    .Select(e => e.FullName)
                                                    .ToList();
            Display(starts_di_email_employees);

            Console.Write("\"lionel\" employees:\t\t");
            var lionel_employees = firms.SelectMany(f => f.Employees)
                                                    .Where(e => e.FullName.ToLower().Contains("lionel"))
                                                    .Select(e => e.FullName)
                                                    .ToList();
            Display(lionel_employees);

            Console.WriteLine("\n\nall data:");
            Console.ReadKey();
            Console.Clear();

            Display(firms);

            Console.WriteLine();

        }
        static void Display<T>(IEnumerable<T> collection)
        {
            if (collection.Any())
            {
                foreach (var item in collection)
                {
                    Console.Write($"{item}; ");
                }
            }
            else
            {
                Console.Write($"no data");
            }
            Console.WriteLine();
        }

        static List<Firm> GetFirmsAndEmployees()
        {
            List<Firm> firms = new List<Firm>();

            Firm foodCompany = new Firm("Food Company", new DateTime(2023, 1, 1), "Food Industry", "White", 5, new List<Address> { new Address("Main St", 123, "London", "UK", 10001) }, new List<Employee>());
            Firm whiteCompany = new Firm("White Company", new DateTime(2010, 5, 15), "Marketing", "Black", 5, new List<Address>(), new List<Employee>());
            Firm itCompany = new Firm("IT Company", new DateTime(2015, 9, 30), "IT", "Smith", 5, new List<Address> { new Address("Tech Blvd", 456, "Newcastle", "UK", 20002) }, new List<Employee>());

            foodCompany.Employees.Add(new Employee("Walter White", "Director", "+123456789", "walter.white@mail.com", 2000));
            foodCompany.Employees.Add(new Employee("Jesse Pinkman", "Marketer", "+123456789", "jesse.pinkman@mail.com", 2000));
            foodCompany.Employees.Add(new Employee("Skyler White", "Accountant", "+123456789", "skyler.white@mail.com", 2000));
            foodCompany.Employees.Add(new Employee("Hank Schrader", "Manager", "+123456789", "hank.schrader@mail.com", 2000));
            foodCompany.Employees.Add(new Employee("Gus Fring", "Chef", "+123456789", "gus.fring@mail.com", 2000));

            whiteCompany.Employees.Add(new Employee("John White", "Marketing Manager", "+123456789", "john.white@mail.com", 2500));
            whiteCompany.Employees.Add(new Employee("Jane Smith", "Marketing Specialist", "+123456789", "jane.smith@mail.com", 2200));
            whiteCompany.Employees.Add(new Employee("Michael Black", "Marketing Assistant", "+123456789", "dick.black@mail.com", 1800));
            whiteCompany.Employees.Add(new Employee("Emily Brown", "Marketing Analyst", "+123456789", "emily.brown@mail.com", 2000));
            whiteCompany.Employees.Add(new Employee("David Jones", "Marketing Coordinator", "+123456789", "david.jones@mail.com", 1900));

            itCompany.Employees.Add(new Employee("Lionel Smith", "IT Director", "+123456789", "lio.smith@mail.com", 3000));
            itCompany.Employees.Add(new Employee("Emma Johnson", "Software Developer", "+123456789", "emma.johnson@mail.com", 2800));
            itCompany.Employees.Add(new Employee("Daniel Davis", "Systems Analyst", "+123456789", "daniel.davis@mail.com", 2600));
            itCompany.Employees.Add(new Employee("Olivia Wilson", "Network Engineer", "+123456789", "olivia.wilson@mail.com", 2700));
            itCompany.Employees.Add(new Employee("William Taylor", "IT Technician", "+123456789", "william.taylor@mail.com", 2200));

            firms.Add(foodCompany);
            firms.Add(whiteCompany);
            firms.Add(itCompany);

            return firms;
        }
    }
    class Employee
    {
        private string fullName { get; set; }
        private string position { get; set; }
        private string phone { get; set; }
        private string email { get; set; }
        private int salary { get; set; }
        public Employee() { }
        public Employee(string fullName, string position, string phone, string email, int salary)
        {
            this.fullName = fullName;
            this.position = position;
            this.phone = phone;
            this.email = email;
            this.salary = salary;
        }
        public string FullName { get { return fullName; } set { fullName = value; } }
        public string Position { get { return position; } set { position = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Salary { get { return salary; } set { salary = value; } }

        public override string ToString()
        {
            return $"full name:\t\t{FullName}\n" +
                    $"position:\t\t{Position}\n" +
                    $"phone:\t\t\t{Phone}\n" +
                    $"email:\t\t\t{Email}\n" +
                    $"salary:\t\t\t{Salary}\n";
        }
    }
    class Address
    {
        private string street { get; set; }
        private int building { get; set; }
        private string city { get; set; }
        private string country { get; set; }
        private int index { get; set; }
        public Address() { }
        public Address(string street, int building, string city, string country, int index)
        {
            this.street = street;
            this.building = building;
            this.city = city;
            this.country = country;
            this.index = index;
        }
        public string Street { get { return street; } set { street = value; } }
        public int Building { get { return building; } set { building = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Country { get { return country; } set { country = value; } }
        public int Index { get { return index; } set { index = value; } }

        public override string ToString()
        {
            return $"street:\t\t\t{Street}\n" +
                    $"building:\t\t{Building}\n" +
                    $"city:\t\t\t{City}\n" +
                    $"country:\t\t{Country}\n" +
                    $"index:\t\t\t{Index}\n";
        }
    }
    class Firm
    {
        private string name { get; set; }
        private DateTime foundationYear { get; set; }
        private string businessProfile { get; set; }
        private string directorName { get; set; }
        private int numberOfEmployees { get; set; }
        private List<Address> address { get; set; }
        private List<Employee> employees { get; set; }
        public Firm() { }
        public Firm(string name, DateTime foundationYear, string businessProfile, string directorName, int numberOfEmployees, List<Address> address, List<Employee> employees)
        {
            this.name = name;
            this.foundationYear = foundationYear;
            this.businessProfile = businessProfile;
            this.directorName = directorName;
            this.numberOfEmployees = numberOfEmployees;
            this.address = address;
            this.employees = employees;
        }
        public string Name { get { return name; } set { name = value; } }
        public DateTime FoundationYear { get { return foundationYear; } set { foundationYear = value; } }
        public string BusinessProfile { get { return businessProfile; } set { businessProfile = value; } }
        public string DirectorName { get { return directorName; } set { directorName = value; } }
        public int NumberOfEmployees { get { return numberOfEmployees; } set { numberOfEmployees = value; } }
        public List<Address> Address { get { return address; } set { address = value; } }
        public List<Employee> Employees { get { return employees; } set { employees = value; } }
        public override string ToString()
        {
            string addressesStr = string.Join("\n", Address);
            string employeesStr = string.Join("\n", Employees);

            return $"-= \"{Name}\" information =-\n\n" +
                   $"company name:\t\t\"{Name}\"\n" +
                   $"foundation date:\t{FoundationYear}\n" +
                   $"business profile:\t{BusinessProfile}\n" +
                   $"director's name:\t{DirectorName}\n" +
                   $"number of employees:\t{NumberOfEmployees}\n\n" +
                   $"\"{Name}\" address:\n\n{addressesStr}\n" +
                   $"\"{Name}\" employees:\n\n{employeesStr}\n";
        }
    }
}
