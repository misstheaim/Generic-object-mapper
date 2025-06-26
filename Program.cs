using Generic_object_mapper.DTOs;
using Generic_object_mapper.Models;
using System.Reflection;

namespace Generic_object_mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                Name = "Test",
                Age = 20,
                Salary = 6666,
                Department = "IT"
            };

            SphereDTO sphereDTO = new SphereDTO
            {
                Name = "Ball",
                Radius = 10,
            };

            SquareDTO squareDTO = new SquareDTO
            {
                Name = "Cube",
                SideLength = 1,
            };

            Console.WriteLine(employeeDTO);

            Employee employeeModel = Mapper.Map<EmployeeDTO, Employee>(employeeDTO, source => new Employee() { Department = new Department() { Name = source.Department} });

            Console.WriteLine(employeeModel);

            Console.WriteLine(sphereDTO);

            Sphere sphereModel = Mapper.Map<SphereDTO, Sphere>(sphereDTO);

            Console.WriteLine(sphereModel);

            Console.WriteLine(squareDTO);

            Square squareModel = Mapper.Map<SquareDTO, Square>(squareDTO, source => new Square(source.SideLength));

            Console.WriteLine(squareModel);

            try
            {
                Square squareModelWithError = Mapper.Map<SquareDTO, Square>(squareDTO);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Employee employeeWithError = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            }
            catch (TargetException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Sphere sphereWithError = Mapper.Map<SphereDTO, Sphere>(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
