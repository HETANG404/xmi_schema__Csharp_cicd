using XmiSchema.Core.Entities;


namespace XmiSchema.Core.Geometries;

public abstract class XmiBaseGeometry : XmiBaseEntity
{
    public XmiBaseGeometry(
        string id,
        string name,
        string ifcGuid,
        string nativeId, 
        string description,
        string? entityType = null)
        : base(id, name, ifcGuid, nativeId, description,
               string.IsNullOrEmpty(entityType) ? nameof(XmiBaseGeometry) : entityType)
    {
    }
}
