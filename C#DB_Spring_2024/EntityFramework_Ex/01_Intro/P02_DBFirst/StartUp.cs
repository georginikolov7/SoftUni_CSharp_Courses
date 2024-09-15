using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new();
            Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            return String.Join(Environment.NewLine, context.Employees
                .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
                .ToList());
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var richEmployees = context.Employees
                .Where(e => e.Salary > 50_000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new();
            foreach (var e in richEmployees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            StringBuilder sb = new();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            Employee employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
            {
                employee.Address = address;
                context.SaveChanges();
            }
            List<string> employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            return string.Join(Environment.NewLine, employees);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Take(10)
                .Select(e => new
                {
                    EmployeeName = $"{e.FirstName} {e.LastName}",
                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep =>
                        ep.Project.StartDate.Year >= 2001 &&
                        ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ep.Project.StartDate,
                            EndDate = ep.Project.EndDate.HasValue ?
                            ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                        })
                });


            //Projects:


            //Result string:
            StringBuilder sb = new();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.EmployeeName} - Manager: {e.ManagerName}");
                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        sb.AppendLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {p.EndDate}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                });
            StringBuilder sb = new();

            foreach (var e in addresses)
            {
                sb.AppendLine($"{e.AddressText}, {e.TownName} - {e.EmployeesCount} employees");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .Select(ep => ep.Project.Name)
                    .ToList()
                }).SingleOrDefault();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var p in employee147.Projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d.Employees.Select(e => new
                    {
                        EmployeeName = $"{e.FirstName} {e.LastName}",
                        e.JobTitle
                    })
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.EmployeeName} - {e.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var last10Projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                }).ToList();

            StringBuilder sb = new();
            foreach (var p in last10Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine($"{p.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return sb.ToString().Trim();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<string> departments = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };
            var employeesToUpdate = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .ToList();

            foreach (var employee in employeesToUpdate)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            //Output:
            StringBuilder sb = new();
            foreach (var e in employeesToUpdate.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            return sb.ToString().Trim();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();
            StringBuilder sb = new();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            const int ID = 2;
            var project = context.Projects.FirstOrDefault(p => p.ProjectId == ID);
            context.Projects.Remove(project!);
            context.SaveChanges();

            var top10Projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            StringBuilder sb = new();
            foreach (var p in top10Projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().Trim();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            const string TOWN_NAME = "Seattle";
            var employeesFromSeattle = context.Employees
                .Where(e => e.Address.Town.Name == TOWN_NAME)
                .ToList();

            employeesFromSeattle.ForEach(e =>
            {
                e.Address = null;
                e.AddressId = null;
            });

            var addresses = context.Addresses
                .Where(a => a.Town.Name == TOWN_NAME)
                .ToList();

            int count = addresses.Count;

            context.RemoveRange(addresses);
            context.SaveChanges();

            var town = context.Towns
                .FirstOrDefault(t => t.Name == TOWN_NAME);

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{count} addresses in {TOWN_NAME} were deleted";
        }
    }
}