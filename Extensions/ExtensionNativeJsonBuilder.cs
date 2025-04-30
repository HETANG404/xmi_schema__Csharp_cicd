namespace XmiCore;
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
        var nodes = _model.Entities.Select(e => new
        {
            id = e.ID,
            label = e.Name,
            type = e.EntityType,
            attributes = GetAttributes(e)
        }).ToList();

        var edges = _model.Relationships.Select(r => new
        {
            id = r.ID,
            label = r.EntityType,
            source = r.Source?.ID,
            target = r.Target?.ID,
            attributes = GetAttributes(r)
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
        var props = obj.GetType().GetProperties();

        foreach (var prop in props)
        {
            var value = prop.GetValue(obj);
            if (value == null)
                continue;

            var type = prop.PropertyType;

            // 基础类型 + 字符串 + 枚举
            if (type.IsPrimitive || type == typeof(string) || type.IsEnum || 
                type == typeof(decimal) || type == typeof(DateTime) ||
                type == typeof(float) || type == typeof(double))
            {
                dict[prop.Name] = value;
            }
            // 如果是单个 XmiBaseEntity 派生类 -> 取 ID
            else if (value is XmiBaseEntity entityRef)
            {
                dict[prop.Name] = entityRef.ID;
            }
            // 如果是 IEnumerable<XmiBaseEntity> 类型（比如 List<XmiPoint>）
            else if (value is IEnumerable<XmiBaseEntity> entityList)
            {
                dict[prop.Name] = entityList.Select(e => e.ID).ToList();
            }
            // 其他复杂类型跳过（避免嵌套）
        }

        return dict;
    }
}
