using XmiSchema.Core.Interfaces;
using XmiSchema.Core.Entities;

namespace XmiSchema.Core.Managers;

public class EntityManager<T> : IEntityManager<T> where T : XmiBaseEntity
{
    private readonly List<T> _entityList;                      // 数据来源（外部传入）
    private readonly Dictionary<string, T> _index = new();     // 内部索引加速（ID -> 实体）

    public EntityManager(List<T> backingList)
    {
        _entityList = backingList ?? throw new ArgumentNullException(nameof(backingList));

        // 构建初始索引
        foreach (var entity in _entityList)
        {
            if (!string.IsNullOrWhiteSpace(entity.ID))
                _index[entity.ID] = entity;
        }
    }

    public bool AddEntity(T entity)
    {
        if (string.IsNullOrWhiteSpace(entity.ID)) return false;

        if (_index.ContainsKey(entity.ID))
            return false; // 避免重复

        _entityList.Add(entity);
        _index[entity.ID] = entity;
        return true;
    }

    public bool RemoveEntity(string id)
    {
        if (!_index.TryGetValue(id, out var entity)) return false;

        _entityList.Remove(entity);
        _index.Remove(id);
        return true;
    }

    public T? GetEntity(string id)
    {
        return _index.TryGetValue(id, out var entity) ? entity : null;
    }

    public IEnumerable<T> GetAllEntities()
    {
        return _entityList;
    }

    public IEnumerable<T> FindByName(string name)
    {
        return _entityList.Where(e => e.Name == name);
    }

    public IEnumerable<T> FindByEntityType(string entityType)
    {
        return _entityList.Where(e => e.EntityType == entityType);
    }

    public void Clear()
    {
        _entityList.Clear();
        _index.Clear();
    }
}
