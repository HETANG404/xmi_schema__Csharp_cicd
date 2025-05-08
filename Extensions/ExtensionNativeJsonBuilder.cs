using System.Text.Json;
using System.Text.Json.Serialization;
using XmiSchema.Core.Models;
using XmiSchema.Core.Entities;

namespace XmiSchema.Core.Handlers
{
    public class ExtensionNativeJsonBuilder
    {
        private readonly XmiModel _model;

        public ExtensionNativeJsonBuilder(XmiModel model)
        {
            _model = model;
        }

        public string BuildJson()
        {
            var nodes = _model.Entities.Select(e => new Dictionary<string, object>
            {
                [e.GetType().Name] = e
            }).ToList();

            var edges = _model.Relationships.Select(r => new Dictionary<string, object>
            {
                [r.GetType().Name] = r
            }).ToList();

            var graphJson = new
            {
                nodes,
                edges
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = null, // 保持 PascalCase
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() }
            };

            return JsonSerializer.Serialize(graphJson, options);
        }

        public void Save(string path)
        {
            File.WriteAllText(path, BuildJson());
            Console.WriteLine($"JSON 图文件保存成功：{path}");
        }
    }
}
