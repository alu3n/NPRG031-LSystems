namespace NPRG031___L_Systems;

public class PolygonalLine
{
    public List<Vector> points { get; private set; } = new List<Vector>();
    public bool empty { get; private set; } = true;

    public void AddPoint(Vector point)
    {
        points.Add(point);
        empty = false;
    }
}