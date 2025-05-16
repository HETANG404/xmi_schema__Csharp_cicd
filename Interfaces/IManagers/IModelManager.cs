using System.Collections.Generic;
using XmiSchema.Core.Entities;
using XmiSchema.Core.Relationships;

namespace XmiSchema.Core.Interfaces;

    public interface IModelManager
    {
        void AddEntity(XmiBaseEntity entity);

        void CreateRelationship(XmiBaseRelationship relationship);

        List<XmiBaseEntity> GetAllEntities();

        List<XmiBaseRelationship> GetAllRelationships();
    }

