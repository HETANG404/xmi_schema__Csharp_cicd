using XmiSchema.Core.Entities;
using XmiSchema.Core.Relationships;
using XmiSchema.Core.Models;
using XmiSchema.Core.Managers;
using XmiSchema.Core.Interfaces;

namespace XmiSchema.Core.Modules;

public class XmiSchemaModuleModelBuilder
{
    private readonly XmiModel _model;
    private readonly EntityManager<XmiBaseEntity> _entityManager;
    private readonly RelationshipManager<XmiBaseRelationship> _relationshipManager;

    public XmiSchemaModuleModelBuilder()
    {
        _model = new XmiModel(); // 构建空模型，包含空的 Entity/Relationship 列表
        _entityManager = new EntityManager<XmiBaseEntity>(_model.Entities);
        _relationshipManager = new RelationshipManager<XmiBaseRelationship>(_model.Relationships);

        Console.WriteLine("Model Here!");
    }

    // 通过只读属性暴露 Manager
    public IEntityManager<XmiBaseEntity> EntityManager => _entityManager;

    public IRelationshipManager<XmiBaseRelationship> RelationshipManager => _relationshipManager;

    //暴露构建完成的 XmiModel
    public XmiModel Build() => _model;
}