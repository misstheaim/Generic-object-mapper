using Generic_object_mapper.DTOs;
using Generic_object_mapper.Models;

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
        }
    }
}
