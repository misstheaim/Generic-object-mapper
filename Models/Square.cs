namespace Generic_object_mapper.Models;

internal record Square
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Area { get; set; }

    public int SideLength { get; set; }

    public Square(int side)
    {
        SideLength = side;
        Area = side * side;
    }
}
