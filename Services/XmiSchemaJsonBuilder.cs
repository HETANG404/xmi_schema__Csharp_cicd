using XmiSchema.Core.Entities;
using XmiSchema.Core.Relationships;
using XmiSchema.Core.Models;
using XmiSchema.Core.Managers;
using XmiSchema.Core.Modules;

namespace XmiSchema.Core.Results;

public class XmiSchemaJsonBuilder
{
    private readonly XmiSchemaModuleModelBuilder _builder;
    private bool _relationshipsBuilt;

    public XmiSchemaJsonBuilder()
    {
        _builder = new XmiSchemaModuleModelBuilder();
        _relationshipsBuilt = false;
    }

    // 添加实体
    public void AddEntity(XmiBaseEntity entity)
        => _builder.EntityManager.AddEntity(entity);

    public void AddEntities(IEnumerable<XmiBaseEntity> entities)
    {
        foreach (var e in entities)
            _builder.EntityManager.AddEntity(e);
    }

    // 第一次显式调用：生成关系（只做一次）
    public void CreateRelationships()
    {
        if (_relationshipsBuilt) return;
        var model = _builder.Build();
        var relBuilder = new XmiSchemaRelationshipBuilder(_builder.RelationshipManager);
        relBuilder.CreateRelationships(model);
        _relationshipsBuilt = true;
    }

    // 分析之前确保调用过 CreateRelationships()
    private XmiModel EnsureModelWithRelationships()
    {
        CreateRelationships();
        return _builder.Build();
    }

    // 拓扑排序
    public List<XmiBaseEntity> GetTopologicallySortedEntities()
    {
        var model = EnsureModelWithRelationships();
        return new XmiSchemaModuleDependencyAnalyzer(model.Entities, model.Relationships)
                   .GetTopologicallySortedEntities();
    }

    // 循环检测
    public List<List<XmiBaseEntity>> GetCycles()
    {
        var model = EnsureModelWithRelationships();
        return new XmiSchemaModuleDependencyAnalyzer(model.Entities, model.Relationships)
                   .DetectCycles();
    }

    // 导出
    public void ExportJson(string outputPath)
    {
        var model = EnsureModelWithRelationships();
        new XmiSchemaModuleJsonBuilder(model).Save(outputPath);
    }

    public string BuildJsonString()
    {
        var model = EnsureModelWithRelationships();
        return new XmiSchemaModuleJsonBuilder(model).BuildJson();
    }
}
