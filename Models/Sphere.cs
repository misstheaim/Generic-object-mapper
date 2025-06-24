namespace Generic_object_mapper.Models;

internal record Sphere
{
    private const double numberPi = 3.14;
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

    public double sectionLength
    {
        get
        {
            return Radius * 2  * numberPi;
        }
    }
}
