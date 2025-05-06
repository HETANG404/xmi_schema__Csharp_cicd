using XmiSchema.Core.Enums;


namespace XmiSchema.Core.Entities;

public class XmiStructuralCrossSection : XmiBaseEntity
{
    public XmiStructuralMaterial Material { get; set; }     // Name of the material for element
    public XmiShapeEnum Shape { get; set; }                    // Shape of the cross section (Enum)
    public string[] Parameters { get; set; }               // Refer to "CrossSectionParameter temp ref" TAB
    public double Area { get; set; }                      // Cross-sectional area
    public double SecondMomentOfAreaXAxis { get; set; }                        // Second moment of area about x axis
    public double SecondMomentOfAreaYAxis { get; set; }                        // Second moment of area about y axis
    public double RadiusOfGyrationXAxis { get; set; }                        // Radius of gyration about x axis
    public double RadiusOfGyrationYAxis { get; set; }                        // Radius of gyration about y axis
    public double ElasticModulusXAxis { get; set; }                        // Elastic modulus about x axis
    public double ElasticModulusYAxis { get; set; }                        // Elastic modulus about y axis
    public double PlasticModulusXAxis { get; set; }                        // Plastic modulus about x axis
    public double PlasticModulusYAxis { get; set; }                        // Plastic modulus about y axis
    public double TorsionalConstant { get; set; }                         // Torsional constant

    public XmiStructuralCrossSection(
        string id,
        string name,
        string ifcguid,
        string nativeId,
        string description,
        XmiStructuralMaterial material,
        XmiShapeEnum shape,
        string[] parameters,
        double area,
        double secondMomentOfAreaXAxis,
        double secondMomentOfAreaYAxis,
        double radiusOfGyrationXAxis,
        double radiusOfGyrationYAxis,
        double elasticModulusXAxis,
        double elasticModulusYAxis,
        double plasticModulusXAxis,
        double plasticModulusYAxis,
        double torsionalConstant
    ) : base(id, name, ifcguid, nativeId, description, nameof(XmiStructuralCrossSection))
    {
        Material = material;
        Shape = shape;
        Parameters = parameters;
        Area = area;
        SecondMomentOfAreaXAxis = secondMomentOfAreaXAxis;
        SecondMomentOfAreaYAxis = secondMomentOfAreaYAxis;
        RadiusOfGyrationXAxis = radiusOfGyrationXAxis;
        RadiusOfGyrationYAxis = radiusOfGyrationYAxis;
        ElasticModulusXAxis = elasticModulusXAxis;
        ElasticModulusYAxis = elasticModulusYAxis;
        PlasticModulusXAxis = plasticModulusXAxis;
        PlasticModulusYAxis = plasticModulusYAxis;
        TorsionalConstant = torsionalConstant;
    }
}
