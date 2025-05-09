using Newtonsoft.Json;

namespace XmiSchema.Core.Entities
{
    public class XmiBaseEntity
    {
        [JsonProperty(Order = 0)]
        public string ID { get; set; }

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public string IFCGUID { get; set; }

        [JsonProperty(Order = 3)]
        public string NativeId { get; set; }

        [JsonProperty(Order = 4)]
        public string Description { get; set; }

        [JsonProperty(Order = 5)]
        public string EntityType { get; set; }

        // 带参数构造函数
        public XmiBaseEntity(
            string id,
            string name,
            string ifcguid,
            string nativeId,
            string description,
            string entityType
        )
        {
            ID = id;
            Name = string.IsNullOrWhiteSpace(name) ? id : name;
            IFCGUID = ifcguid;
            NativeId = nativeId;
            Description = description;
            EntityType = string.IsNullOrEmpty(entityType) ? nameof(XmiBaseEntity) : entityType;
        }
    }
}
