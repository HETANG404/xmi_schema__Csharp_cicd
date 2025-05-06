using XmiSchema.Core.Entities;
using XmiSchema.Core.Relationships;


namespace XmiSchema.Core.Models;

    public class XmiModel
    {
        public List<XmiBaseEntity> Entities { get; set; } = new();
        public List<XmiBaseRelationship> Relationships { get; set; } = new();
    }

