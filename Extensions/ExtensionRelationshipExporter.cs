using XmiSchema.Core.Entities;
using XmiSchema.Core.Relationships;
using XmiSchema.Core.Interfaces;
using XmiSchema.Core.Models;
using XmiSchema.Core.Geometries;

namespace XmiSchema.Core.Handlers;

    public class ExtensionRelationshipExporter
    {
        private readonly IRelationshipManager<XmiBaseRelationship> _relationshipManager;

        public ExtensionRelationshipExporter(IRelationshipManager<XmiBaseRelationship> relationshipManager)
        {
            _relationshipManager = relationshipManager;
        }

        public void ExportRelationships(XmiModel xmiModel)
        {
            foreach (var entity in xmiModel.Entities)
            {
                // StructuralPointConnection → Point
                if (entity is XmiStructuralPointConnection spc && spc.Point is XmiPoint3D point)
                {
                    _relationshipManager.AddRelationship(new XmiHasGeometry(spc, point));
                }

                if (entity is XmiStructuralPointConnection spcWithStorey && spcWithStorey.Storey is XmiStructuralStorey storey)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralStorey(spcWithStorey, storey));
                }

                // CrossSection → Material
                if (entity is XmiStructuralCrossSection crossSection && crossSection.Material != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralMaterial(crossSection, crossSection.Material));
                }

                // CurveMember → CrossSection
                if (entity is XmiStructuralCurveMember curve && curve.CrossSection != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralCrossSection(curve, curve.CrossSection));
                }

                // CurveMember → Storey
                if (entity is XmiStructuralCurveMember curveWithStorey && curveWithStorey.Storey != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralStorey(curveWithStorey, curveWithStorey.Storey));
                }

                // CurveMember → Segments
                if (entity is XmiStructuralCurveMember curveWithSegments)
                {
                    foreach (var segment in curveWithSegments.Segments)
                    {
                        _relationshipManager.AddRelationship(new XmiHasSegment(curveWithSegments, segment));
                    }
                }

                // CurveMember → Nodes
                if (entity is XmiStructuralCurveMember curveWithNodes)
                {
                    foreach (var node in curveWithNodes.Nodes)
                    {
                        _relationshipManager.AddRelationship(new XmiHasStructuralNode(curveWithNodes, node));
                    }
                }

                // CurveMember → BeginNode
                if (entity is XmiStructuralCurveMember curveWithBeginNode && curveWithBeginNode.BeginNode != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralNode(curveWithBeginNode, curveWithBeginNode.BeginNode));
                }

                // CurveMember → EndNode
                if (entity is XmiStructuralCurveMember curveWithEndNode && curveWithEndNode.EndNode != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralNode(curveWithEndNode, curveWithEndNode.EndNode));
                }


                // SurfaceMember → Material
                if (entity is XmiStructuralSurfaceMember surface && surface.Material != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralMaterial(surface, surface.Material));
                }

                // SurfaceMember → Storey
                if (entity is XmiStructuralSurfaceMember surfaceWithStorey && surfaceWithStorey.Storey != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasStructuralMaterial(surfaceWithStorey, surfaceWithStorey.Storey));
                }

                // SurfaceMember → Segments
                if (entity is XmiStructuralSurfaceMember surfaceWithSegments)
                {
                    foreach (var segment in surfaceWithSegments.Segments)
                    {
                        _relationshipManager.AddRelationship(new XmiHasSegment(surfaceWithSegments, segment));
                    }
                }

                // SurfaceMember → Nodes
                if (entity is XmiStructuralSurfaceMember surfaceWithNodes)
                {
                    foreach (var node in surfaceWithNodes.Nodes)
                    {
                        _relationshipManager.AddRelationship(new XmiHasStructuralNode(surfaceWithNodes, node));
                    }
                }

                // Segment → Geometry
                if (entity is XmiSegment segmentWithGeometry && segmentWithGeometry.Geometry != null)
                {
                    _relationshipManager.AddRelationship(new XmiHasGeometry(segmentWithGeometry, segmentWithGeometry.Geometry));
                }

                // Segment → BeginNode/EndNode
                if (entity is XmiSegment segmentWithNodes)
                {
                    if (segmentWithNodes.BeginNode != null)
                        _relationshipManager.AddRelationship(new XmiHasStructuralNode(segmentWithNodes, segmentWithNodes.BeginNode));

                    if (segmentWithNodes.EndNode != null)
                        _relationshipManager.AddRelationship(new XmiHasStructuralNode(segmentWithNodes, segmentWithNodes.EndNode));
                }

                // XmiArc3D → StartPoint/EndPoint
                if (entity is XmiArc3D geomArc)
                {
                    if (geomArc.StartPoint != null)
                        _relationshipManager.AddRelationship(new XmiHasGeometry(geomArc, geomArc.StartPoint));

                    if (geomArc.EndPoint != null)
                        _relationshipManager.AddRelationship(new XmiHasGeometry(geomArc, geomArc.EndPoint));
                    
                    if (geomArc.CentrePoint != null)
                        _relationshipManager.AddRelationship(new XmiHasGeometry(geomArc, geomArc.CentrePoint));
                }
                // XmiLine3D → StartPoint3D/EndPoint3D
                if (entity is XmiLine3D geomLine)
                {
                    if (geomLine.StartPoint3D != null)
                        _relationshipManager.AddRelationship(new XmiHasGeometry(geomLine, geomLine.StartPoint3D));

                    if (geomLine.EndPoint3D != null)
                        _relationshipManager.AddRelationship(new XmiHasGeometry(geomLine, geomLine.EndPoint3D));
                }
            }
        }
    }


