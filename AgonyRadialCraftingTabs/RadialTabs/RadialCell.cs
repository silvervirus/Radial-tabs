
using Agony.Common.Reflectors;
using UnityEngine;

namespace Agony.RadialTabs
{
    internal sealed class RadialCell
    {
        private static readonly RadialCell InvalidCell = new RadialCell(0, 0, 0, 0, 0, null);

        public Vector2 Position => new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
        public readonly float radius;
        public readonly float size;
        public readonly float angle;
        public readonly float groupAngle;
        public readonly int siblings;
        public readonly RadialCell parent;

        private RadialCell(float radius, float angle, float size, float groupAngle, int siblings, RadialCell parent)
        {
            this.radius = radius;
            this.size = size;
            this.angle = angle;
            this.parent = parent;
            this.groupAngle = groupAngle;
            this.siblings = siblings;
        }

        public static RadialCell Create(uGUI_CraftNode node)
        {
            if (node.parent == null) { return InvalidCell; }

            var parentCell = Create(node.parent as uGUI_CraftNode);
            if (parentCell == InvalidCell) { return CreateRootCell(node); }

            return parentCell.radius == 0 ? CreateChildCellWithOneElementAtRoot(node, parentCell) : CreateChildCell(node, parentCell);
        }

        private static RadialCell CreateRootCell(uGUI_CraftNode node)
        {
            var siblings = node.parent.childCount;
            var size = (float)Config.RootIconSize;
            if (siblings <= 1) { return new RadialCell(0, 0, size, float.NaN, siblings, InvalidCell); }

            var index = uGUI_CraftNodeReflector.GetIndex(node);
            var radius = GetPolygonRadius(size, siblings);
            if (siblings > Config.MaxRootIconCount)
            {
                radius = GetPolygonRadius(size, Config.MaxRootIconCount);
                size = GetPolygonLineSize(radius, siblings);
            }

            var angleDelta = 2 * Mathf.PI / siblings;
            var angle = angleDelta * index + GetExtraAngleOffset(siblings);
            return new RadialCell(radius, angle, size, float.NaN, siblings, InvalidCell);
        }

        private static RadialCell CreateChildCellWithOneElementAtRoot(uGUI_CraftNode node, RadialCell parent)
        {
            var siblings = node.parent.childCount;
            var size = ComputeNewSize(parent);
            var radius = ComputeNewRadius(parent, size);
            var index = uGUI_CraftNodeReflector.GetIndex(node);
            var maxSiblings = GetPolygonLineCount(radius, size);
            if (siblings > maxSiblings)
            {
                size = GetPolygonLineSize(radius, siblings);
            }
            var angleDelta = 2 * Mathf.PI / siblings;
            var angle = angleDelta * index + GetExtraAngleOffset(siblings);
            return new RadialCell(radius, angle, size, float.NaN, siblings, parent);
        }

        private static RadialCell CreateChildCell(uGUI_CraftNode node, RadialCell parent)
        {
            var siblings = node.parent.childCount;
            var size = ComputeNewSize(parent);
            var radius = ComputeNewRadius(parent, size);
            var maxSiblings = GetPolygonLineCount(radius, size);
            var index = uGUI_CraftNodeReflector.GetIndex(node);
            if (siblings > maxSiblings)
            {
                size = GetPolygonLineSize(radius, siblings);
                var angleDelta1 = 2 * Mathf.PI / siblings;
                var angle1 = angleDelta1 * index + GetExtraAngleOffset(siblings);
                return new RadialCell(radius, angle1, size, float.NaN, siblings, parent);
            }
            var angleDelta = 2 * Mathf.PI / maxSiblings;
            var groupAngle = siblings > parent.siblings ? parent.groupAngle : parent.angle;
            if (float.IsNaN(groupAngle)) { groupAngle = parent.angle; }
            var angle = groupAngle + angleDelta * (index - (siblings - 1) / 2.0f);
            return new RadialCell(radius, angle, size, groupAngle, siblings, parent);
        }

        private static float ComputeNewSize(RadialCell parent)
        {
            var size = (parent.size - Config.IconSizeReductionDelta) * (float)Config.IconSizeReductionMult;
            return Mathf.Max(size, Config.MinIconSize);
        }

        private static float ComputeNewRadius(RadialCell parent, float size)
        {
            return parent.radius + parent.size / 2 + size / 2;
        }

        private static float GetExtraAngleOffset(int elementCount)
        {
            if (elementCount < 2) return 0;
            return -Mathf.PI * (elementCount - 2) / (2 * elementCount);
        }

        private static float GetPolygonRadius(float lineSize, float lineCount)
        {
            return lineSize / (2 * Mathf.Sin(Mathf.PI / lineCount));
        }

        public static float GetPolygonLineCount(float radius, float lineSize)
        {
            return (float)(Mathf.PI / System.Math.Asin(lineSize / (2 * radius)));
        }

        public static float GetPolygonLineSize(float radius, float lineCount)
        {
            return 2 * radius * Mathf.Sin(Mathf.PI / lineCount);
        }
    }
}