namespace XmiCore;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

public class XmiStructuralCurveMember : XmiBaseEntity
{
    public XmiStructuralCrossSection CrossSection { get; set; }
    public XmiStructuralStorey Storey { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public XmiStructuralCurveMemberTypeEnum CurvememberType { get; set; }
    public List<XmiStructuralPointConnection> Nodes { get; set; }
    public List<XmiBaseEntity> Segments { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public XmiStructuralCurveMemberSystemLineEnum SystemLine { get; set; }
    public XmiStructuralPointConnection BeginNode { get; set; }
    public XmiStructuralPointConnection EndNode { get; set; }
    public double Length { get; set; }


    public string LocalAxisX { get; set; }
    public string LocalAxisY { get; set; }
    public string LocalAxisZ { get; set; }

    public double BeginNodeYOffset { get; set; }
    public double EndNodeYOffset { get; set; }
    public double BeginNodeZOffset { get; set; }
    public double EndNodeZOffset { get; set; }
    public double BeginNodeXOffset { get; set; }
    public double EndNodeXOffset { get; set; }


    public string EndFixityStart { get; set; }
    public string EndFixityEnd { get; set; }




    public XmiStructuralCurveMember(
        string id,
        string name,
        string ifcguid,
        string nativeId,
        string description,
        XmiStructuralCrossSection crossSection,
        XmiStructuralStorey storey,
        XmiStructuralCurveMemberTypeEnum curvememberType,
        List<XmiStructuralPointConnection> nodes,
        List<XmiBaseEntity> segments,
        XmiStructuralCurveMemberSystemLineEnum systemLine,
        XmiStructuralPointConnection beginNode,
        XmiStructuralPointConnection endNode,
        double length,

        string localAxisX,
        string localAxisY,
        string localAxisZ,
        double beginNodeXOffset,
        double endNodeXOffset,
        double beginNodeYOffset,
        double endNodeYOffset,
        double beginNodeZOffset,
        double endNodeZOffset,


        string endFixityStart,
        string endFixityEnd

    ) : base(id, name, ifcguid, nativeId, description, nameof(XmiStructuralCurveMember))
    {
        CrossSection = crossSection;
        Storey = storey;
        CurvememberType = curvememberType;
        Nodes = nodes;
        Segments = segments;
        SystemLine = systemLine;
        BeginNode = beginNode;
        EndNode = endNode;
        Length = length;
        LocalAxisX = localAxisX;
        LocalAxisY = localAxisY;
        LocalAxisZ = localAxisZ;
        BeginNodeYOffset = beginNodeYOffset;
        EndNodeYOffset = endNodeYOffset;
        BeginNodeZOffset = beginNodeZOffset;
        EndNodeZOffset = endNodeZOffset;
        BeginNodeXOffset = beginNodeXOffset;
        EndNodeXOffset = endNodeXOffset;
        EndFixityStart = endFixityStart;
        EndFixityEnd = endFixityEnd;

    }
}
