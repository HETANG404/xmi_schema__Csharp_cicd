using XmiSchema.Core.Interfaces;
using XmiSchema.Core.Relationships;

namespace XmiSchema.Core.Managers;

public class RelationshipManager<T> : IRelationshipManager<T> where T : XmiBaseRelationship
{
    private readonly List<T> _backingList;
    private readonly Dictionary<string, T> _index = new();

    public RelationshipManager(List<T> backingList)
    {
        _backingList = backingList ?? throw new ArgumentNullException(nameof(backingList));

        // 构建初始索引
        foreach (var r in _backingList)
        {
            if (!string.IsNullOrWhiteSpace(r.ID))
                _index[r.ID] = r;
        }
    }

    public bool AddRelationship(T relationship)
    {
        if (relationship == null || string.IsNullOrWhiteSpace(relationship.ID))
            return false;

        if (_index.ContainsKey(relationship.ID))
            return false; // 避免重复

        _backingList.Add(relationship);
        _index[relationship.ID] = relationship;
        return true;
    }

    public bool RemoveRelationship(string id)
    {
        if (!_index.TryGetValue(id, out var rel)) return false;

        _backingList.Remove(rel);
        _index.Remove(id);
        return true;
    }

    public T? GetRelationship(string id)
    {
        return _index.TryGetValue(id, out var rel) ? rel : null;
    }

    public IEnumerable<T> GetAll()
    {
        return _backingList;
    }

    public IEnumerable<T> FindBySource(string sourceId)
    {
        return _backingList.Where(r => r.Source?.ID == sourceId);
    }

    public IEnumerable<T> FindByTarget(string targetId)
    {
        return _backingList.Where(r => r.Target?.ID == targetId);
    }

    public void Clear()
    {
        _backingList.Clear();
        _index.Clear();
    }
}
