using XmiSchema.Core.Enums;

namespace XmiSchema.Core.Entities;

public class XmiStructuralSurfaceMember : XmiBaseEntity
{
    public XmiStructuralMaterial Material { get; set; }
    public XmiStructuralSurfaceMemberTypeEnum SurfaceMemberType { get; set; }
    public double Thickness { get; set; }
    public XmiStructuralSurfaceMemberSystemPlaneEnum SystemPlane { get; set; }
    public List<XmiStructuralPointConnection> Nodes { get; set; }
    public XmiStructuralStorey Storey { get; set; }

    public List<XmiSegment> Segments { get; set; }
    public double Area { get; set; }
    public double ZOffset { get; set; }
    public string LocalAxisX { get; set; }
    public string LocalAxisY { get; set; }
    public string LocalAxisZ { get; set; }
    public double Height { get; set; }
    public XmiStructuralSurfaceMember(
        string id,
        string name,
        string ifcguid,
        string nativeId,
        string description,
        XmiStructuralMaterial material,
        XmiStructuralSurfaceMemberTypeEnum surfaceMemberType,
        double thickness,
        XmiStructuralSurfaceMemberSystemPlaneEnum systemPlane,

        List<XmiStructuralPointConnection> nodes,
        XmiStructuralStorey storey,
        List<XmiSegment> segments,
        double area,
        double zOffset,
        string localAxisX,
        string localAxisY,
        string localAxisZ,
        double height

    ) : base(id, name, ifcguid, nativeId, description, nameof(XmiStructuralSurfaceMember))
    {

        Material = material;
        SurfaceMemberType = surfaceMemberType;
        Thickness = thickness;
        SystemPlane = systemPlane;
        Nodes = nodes;
        Storey = storey;
        Segments= segments;
        Area = area;
        ZOffset = zOffset;
        LocalAxisX = localAxisX;
        LocalAxisY = localAxisY;
        LocalAxisZ = localAxisZ;
        Height = height;
    }
}
