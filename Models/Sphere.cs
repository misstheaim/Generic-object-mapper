namespace Generic_object_mapper.Models;

internal record Sphere
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Radius { get; set; }

    public int Diameter
    {
        get
        {
            return Radius * 2;
        }
    }

    public double SectionLength
    {
        get
        {
            return Radius * 2  * Math.PI;
        }
    }
}
