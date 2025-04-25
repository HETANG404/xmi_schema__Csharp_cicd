namespace XmiCore;

public class XmiStructuralStorey : XmiBaseEntity
{
    public double StoreyElevation { get; set; }
    public double StoreyMass { get; set; }
    public string StoreyHorizontalReactionX { get; set; }
    public string StoreyHorizontalReactionY { get; set; }
    public string StoreyVerticalReaction { get; set; }

    public XmiStructuralStorey(
        string id,
        string name,
        string ifcguid,
        string nativeId,
        string description,
        double storeyElevation,
        double storeyMass,
        string storeyHorizontalReactionX,
        string storeyHorizontalReactionY,
        string storeyVerticalReaction
    ) : base(id, name, ifcguid, nativeId, description, nameof(XmiStructuralStorey))
    {
        StoreyElevation = storeyElevation;
        StoreyMass = storeyMass;
        StoreyHorizontalReactionX = storeyHorizontalReactionX;
        StoreyHorizontalReactionY = storeyHorizontalReactionY;
        StoreyVerticalReaction = storeyVerticalReaction;
    }
}
