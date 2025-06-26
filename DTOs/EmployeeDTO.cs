namespace Generic_object_mapper.DTOs;

internal record EmployeeDTO
{
    public string? Name { get; set; }

    public int Age { get; set; }

    public int Salary { get; set; } = 0;

    public string? Department { get; set; }
}
