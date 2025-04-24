namespace XmiCore;

public class XmiHasStructuralStorey : XmiBaseRelationship
{
    public XmiHasStructuralStorey(
        string id,
        XmiBaseEntity source,
        XmiBaseEntity target,
        string name,
        string description,
        string entityName,
        string umlType
    ) : base(id, source, target, name, description, nameof(XmiHasStructuralStorey), "Association")
    {
    }

    public XmiHasStructuralStorey(
        XmiBaseEntity source,
        XmiBaseEntity target
    ) : base(source, target, nameof(XmiHasStructuralStorey), "Association")
    {
    }
}
