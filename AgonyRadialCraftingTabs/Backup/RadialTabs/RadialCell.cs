// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.RadialCell
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using Agony.Common.Reflectors;
using System;
using UnityEngine;

namespace Agony.RadialTabs
{
  internal sealed class RadialCell
  {
    private static readonly RadialCell InvalidCell = new RadialCell(0.0f, 0.0f, 0.0f, 0.0f, 0, (RadialCell) null);
    public readonly float radius;
    public readonly float size;
    public readonly float angle;
    public readonly float groupAngle;
    public readonly int siblings;
    public readonly RadialCell parent;

    public Vector2 Position
    {
      get
      {
        return new Vector2(this.radius * Mathf.Cos(this.angle), this.radius * Mathf.Sin(this.angle));
      }
    }

    private RadialCell(
      float radius,
      float angle,
      float size,
      float groupAngle,
      int siblings,
      RadialCell parent)
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
      if (((TreeNode) node).get_parent() == null)
        return RadialCell.InvalidCell;
      RadialCell parent = RadialCell.Create(((TreeNode) node).get_parent() as uGUI_CraftNode);
      if (parent == RadialCell.InvalidCell)
        return RadialCell.CreateRootCell(node);
      return (double) parent.radius != 0.0 ? RadialCell.CreateChildCell(node, parent) : RadialCell.CreateChildCellWithOneElementAtRoot(node, parent);
    }

    private static RadialCell CreateRootCell(uGUI_CraftNode node)
    {
      int childCount = ((TreeNode) node).get_parent().get_childCount();
      float num = (float) Config.RootIconSize;
      if (childCount <= 1)
        return new RadialCell(0.0f, 0.0f, num, float.NaN, childCount, RadialCell.InvalidCell);
      int index = uGUI_CraftNodeReflector.GetIndex(node);
      float polygonRadius = RadialCell.GetPolygonRadius(num, (float) childCount);
      if (childCount > Config.MaxRootIconCount)
      {
        polygonRadius = RadialCell.GetPolygonRadius(num, (float) Config.MaxRootIconCount);
        num = RadialCell.GetPolygonLineSize(polygonRadius, (float) childCount);
      }
      float angle = 6.283185f / (float) childCount * (float) index + RadialCell.GetExtraAngleOffset(childCount);
      return new RadialCell(polygonRadius, angle, num, float.NaN, childCount, RadialCell.InvalidCell);
    }

    private static RadialCell CreateChildCellWithOneElementAtRoot(
      uGUI_CraftNode node,
      RadialCell parent)
    {
      int childCount = ((TreeNode) node).get_parent().get_childCount();
      float num = RadialCell.ComputeNewSize(parent);
      float newRadius = RadialCell.ComputeNewRadius(parent, num);
      int index = uGUI_CraftNodeReflector.GetIndex(node);
      float polygonLineCount = RadialCell.GetPolygonLineCount(newRadius, num);
      if ((double) childCount > (double) polygonLineCount)
        num = RadialCell.GetPolygonLineSize(newRadius, (float) childCount);
      float angle = 6.283185f / (float) childCount * (float) index + RadialCell.GetExtraAngleOffset(childCount);
      return new RadialCell(newRadius, angle, num, float.NaN, childCount, parent);
    }

    private static RadialCell CreateChildCell(uGUI_CraftNode node, RadialCell parent)
    {
      int childCount = ((TreeNode) node).get_parent().get_childCount();
      float newSize = RadialCell.ComputeNewSize(parent);
      float newRadius = RadialCell.ComputeNewRadius(parent, newSize);
      float polygonLineCount = RadialCell.GetPolygonLineCount(newRadius, newSize);
      int index = uGUI_CraftNodeReflector.GetIndex(node);
      if ((double) childCount > (double) polygonLineCount)
      {
        float polygonLineSize = RadialCell.GetPolygonLineSize(newRadius, (float) childCount);
        float angle = 6.283185f / (float) childCount * (float) index + RadialCell.GetExtraAngleOffset(childCount);
        return new RadialCell(newRadius, angle, polygonLineSize, float.NaN, childCount, parent);
      }
      float num1 = 6.283185f / polygonLineCount;
      float num2 = childCount > parent.siblings ? parent.groupAngle : parent.angle;
      if (float.IsNaN(num2))
        num2 = parent.angle;
      float angle1 = num2 + num1 * ((float) index - (float) (childCount - 1) / 2f);
      return new RadialCell(newRadius, angle1, newSize, num2, childCount, parent);
    }

    private static float ComputeNewSize(RadialCell parent)
    {
      return Mathf.Max((parent.size - (float) Config.IconSizeReductionDelta) * (float) Config.IconSizeReductionMult, (float) Config.MinIconSize);
    }

    private static float ComputeNewRadius(RadialCell parent, float size)
    {
      return (float) ((double) parent.radius + (double) parent.size / 2.0 + (double) size / 2.0);
    }

    private static float GetExtraAngleOffset(int elementCount)
    {
      return elementCount < 2 ? 0.0f : -3.141593f * (float) (elementCount - 2) / (float) (2 * elementCount);
    }

    private static float GetPolygonRadius(float lineSize, float lineCount)
    {
      return lineSize / (2f * Mathf.Sin(3.141593f / lineCount));
    }

    public static float GetPolygonLineCount(float radius, float lineSize)
    {
      return (float) (3.14159274101257 / Math.Asin((double) lineSize / (2.0 * (double) radius)));
    }

    public static float GetPolygonLineSize(float radius, float lineCount)
    {
      return 2f * radius * Mathf.Sin(3.141593f / lineCount);
    }
  }
}
