namespace Generic_object_mapper.Models;

internal record Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public int Salary { get; set; } = 0;

    public required Department Department { get; set; }
}
