namespace Generic_object_mapper.Models;

internal record Department
{
    public required string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
