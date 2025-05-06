using XmiSchema.Core.Entities;


namespace XmiSchema.Core.Geometries;

public abstract class XmiBaseGeometry : XmiBaseEntity
{
    public XmiBaseGeometry(string id, string name, string ifcGuid,string nativeId, string description)
        : base(id, name, ifcGuid, nativeId, description, nameof(XmiBaseGeometry))
    {
    }
}
