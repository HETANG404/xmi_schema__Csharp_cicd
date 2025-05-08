using System.Text.Json.Serialization;

namespace XmiSchema.Core.Geometries;

public class XmiPoint3D : XmiBaseGeometry
{
    [JsonPropertyOrder(6)]
    public double X { get; set; }
    [JsonPropertyOrder(7)]
    public double Y { get; set; }
    [JsonPropertyOrder(8)]
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
    ) : base(id, name, ifcGuid, nativeId, description,nameof(XmiPoint3D))
    {
        X = x;
        Y = y;
        Z = z;
        EntityType = nameof(XmiPoint3D);
    }
}
