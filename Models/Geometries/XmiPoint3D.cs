namespace XmiCore;

public class XmiPoint3D : XmiBaseGeometry
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public XmiPoint3D(
        string id,
        string name,
        string ifcGuid,
        string nativeId,
        string description,
        double x,
        double y,
        double z
    ) : base(id, name, ifcGuid, nativeId, description)
    {
        X = x;
        Y = y;
        Z = z;
        EntityType = nameof(XmiPoint3D);
    }
}
