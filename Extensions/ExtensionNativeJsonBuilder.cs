using Newtonsoft.Json;
using System.Reflection;
using XmiSchema.Core.Models;
using XmiSchema.Core.Entities;
using XmiSchema.Core.Enums;

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
            var nodes = _model.Entities
                .Select(e => GetAttributes(e))
                .ToList();

            var edges = _model.Relationships
                .Select(r => GetAttributes(r))
                .ToList();

            var graphJson = new
            {
                nodes,
                edges
            };

            return JsonConvert.SerializeObject(graphJson, Formatting.Indented);
        }

        public void Save(string path)
        {
            File.WriteAllText(path, BuildJson());
            Console.WriteLine($"JSON 图文件保存成功：{path}");
        }

        private Dictionary<string, object> GetAttributes(object obj)
        {
            var dict = new Dictionary<string, object>();

            var props = obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .OrderBy(p => p.MetadataToken); // 按声明顺序输出

            foreach (var prop in props)
            {
                var value = prop.GetValue(obj);
                if (value == null) continue;

                var type = prop.PropertyType;
                object finalValue = null;

                if (type.IsEnum)
                {
                    var enumName = value.ToString();
                    if (!string.IsNullOrEmpty(enumName))
                    {
                        var field = type.GetField(enumName);
                        var enumValueAttr = field?.GetCustomAttribute<EnumValueAttribute>();
                        finalValue = enumValueAttr?.Value ?? enumName;
                    }
                    else
                    {
                        finalValue = value;
                    }
                }
                else if (type.IsPrimitive || type == typeof(string) ||
                         type == typeof(decimal) || type == typeof(DateTime) ||
                         type == typeof(float) || type == typeof(double))
                {
                    finalValue = value;
                }
                else if (value is XmiBaseEntity entityRef)
                {
                    finalValue = entityRef.ID;
                }
                else if (value is IEnumerable<XmiBaseEntity> entityList)
                {
                    finalValue = entityList.Select(e => e.ID).ToList();
                }

                if (finalValue != null)
                {
                    dict[prop.Name] = finalValue;
                }
            }

            return dict;
        }
    }
}
