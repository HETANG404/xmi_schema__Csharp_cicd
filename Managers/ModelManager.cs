using XmiSchema.Core.Models;
using XmiSchema.Core.Interfaces;
using XmiSchema.Core.Entities;
using XmiSchema.Core.Relationships;


namespace XmiSchema.Core.Managers;

    public class ModelManager : IModelManager
    {
        private readonly XmiModel _model;

        public ModelManager(XmiModel model)
        {
            _model = model;
        }

        public void AddEntity(XmiBaseEntity entity)
        {
            if (entity != null)
                _model.Entities.Add(entity);
        }

        public void CreateRelationship(XmiBaseRelationship relationship)
        {
            if (relationship != null)
                _model.Relationships.Add(relationship);
        }

        public List<XmiBaseEntity> GetAllEntities()
        {
            return _model.Entities;
        }

        public List<XmiBaseRelationship> GetAllRelationships()
        {
            return _model.Relationships;
        }
    }

