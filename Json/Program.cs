using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Json
{
    static class Program
    {
        static void Main()
        {
            #region Serialization

            Console.WriteLine("Serialization");
            Employee employee = FillEmployee();

            string result = JsonConvert.SerializeObject(employee);
            Console.WriteLine(result);

            #endregion

            #region Deserialization

            Console.WriteLine("\nDeserialization");
            try
            {
                Employee newEmployee = JsonConvert.DeserializeObject<Employee>(result);
                Console.WriteLine($"Name :{newEmployee.FirstName} {newEmployee.MiddleName} {newEmployee.LastName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("We had a problem: " + ex.Message);
            }

            #endregion

            #region Collection

            Console.WriteLine("\nSerialization of Collection");
            ICollection<Employee> employees = new List<Employee>();
            for (int i = 0; i < 10; i++)
            {
                employees.Add(FillEmployee());
            }

            var collectionResult = JsonConvert.SerializeObject(employees);
            Console.WriteLine(collectionResult);

            Console.WriteLine("\nDeserialization of Collection");
            try
            {
                var newEmployees = JsonConvert.DeserializeObject<ICollection<Employee>>(collectionResult);
                foreach (var itemEmployee in newEmployees)
                {
                    Console.WriteLine(
                        $"Name :{itemEmployee.FirstName} {itemEmployee.MiddleName} {itemEmployee.LastName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("We had a problem: " + ex.Message);
            }

            #endregion
        }

        #region FillEmployee

        static Employee FillEmployee()
        {
            Employee employee = new Employee
            {
                EmployeeId = Employee.Count++,
                FirstName = "Ibrahim",
                MiddleName = "Mohamed",
                LastName = "Radi",
                Age = 23,
                JobTitle = ".Net Developer"
            };
            return employee;
        }

        #endregion
    }
}