namespace XmiCore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

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
                [e.GetType().Name] = GetAttributes(e)
            }).ToList();

            var edges = _model.Relationships.Select(r => new Dictionary<string, object>
            {
                [r.GetType().Name] = GetAttributes(r)
            }).ToList();

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
                .OrderBy(p => p.MetadataToken); // 声明顺序排序

            foreach (var prop in props)
            {
                var value = prop.GetValue(obj);
                if (value == null)
                    continue;

                var type = prop.PropertyType;

                if (type.IsPrimitive || type == typeof(string) || type.IsEnum ||
                    type == typeof(decimal) || type == typeof(DateTime) ||
                    type == typeof(float) || type == typeof(double))
                {
                    dict[prop.Name] = value;
                }
                else if (value is XmiBaseEntity entityRef)
                {
                    dict[prop.Name] = entityRef.ID;
                }
                else if (value is IEnumerable<XmiBaseEntity> entityList)
                {
                    dict[prop.Name] = entityList.Select(e => e.ID).ToList();
                }
            }

            return dict;
        }
    }
}
