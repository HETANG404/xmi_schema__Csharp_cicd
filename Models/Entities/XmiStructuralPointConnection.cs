using XmiSchema.Core.Enums;
using XmiSchema.Core.Geometries;

namespace XmiSchema.Core.Entities;

public class XmiStructuralPointConnection : XmiBaseEntity
{
    public XmiStructuralStorey Storey { get; set; }
    public XmiPoint3D Point { get; set; }

    public XmiStructuralPointConnection(
        string id,
        string name,
        string ifcGuid,
        string nativeId,
        string description,
        XmiStructuralStorey storey,
        XmiPoint3D point
    ) : base(id, name, ifcGuid, nativeId, description, nameof(XmiStructuralPointConnection))
    {
        Storey = storey;
        Point = point;
    }
}
