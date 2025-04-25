namespace XmiCore;

public class XmiStructuralMaterial : XmiBaseEntity
{
    public XmiStructuralMaterialTypeEnum MaterialType { get; set; }                  // Type of material (Enum)
    public double Grade { get; set; }                  // Material grade (fck, fy, yield strength, etc.)
    public double UnitWeight { get; set; }             // Unit weight of the material
    public double EModulus { get; set; }               // Young's modulus
    public double GModulus { get; set; }               // Shear modulus
    public double PoissonRatio { get; set; }           // Poisson ratio
    public double ThermalCoefficient { get; set; }     // Thermal expansion coefficient

    public XmiStructuralMaterial(
        string id,
        string name,
        string ifcguid,
        string nativeId,
        string description,
        XmiStructuralMaterialTypeEnum materialType,
        double grade,
        double unitWeight,
        double eModulus,
        double gModulus,
        double poissonRatio,
        double thermalCoefficient
    ) : base(id, name, ifcguid, nativeId, description, nameof(XmiStructuralMaterial))
    {
        MaterialType = materialType;
        Grade = grade;
        UnitWeight = unitWeight;
        EModulus = eModulus;
        GModulus = gModulus;
        PoissonRatio = poissonRatio;
        ThermalCoefficient = thermalCoefficient;
    }
}
