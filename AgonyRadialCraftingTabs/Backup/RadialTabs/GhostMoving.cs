// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.GhostMoving
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using UnityEngine;
using UnityEngine.UI;

namespace Agony.RadialTabs
{
  internal sealed class GhostMoving : ItemIconAnimation
  {
    private float _speed;
    private float _fadeDistance;
    private Vector2 _targetPosition;

    public GhostMoving(float speed, float fadeDistance, Vector2 targetPosition)
    {
      this._speed = speed;
      this._targetPosition = targetPosition;
      this._fadeDistance = fadeDistance;
    }

    protected override void OnStart(uGUI_ItemIcon actor)
    {
      if (Object.op_Equality((Object) actor, (Object) null))
        return;
      actor.SetAlpha(0.0f, 0.0f, 0.0f);
      ((Behaviour) actor).set_enabled(false);
    }

    protected override bool OnUpdate(uGUI_ItemIcon actor)
    {
      if (Object.op_Equality((Object) actor, (Object) null))
        return false;
      Vector2 vector2_1 = Vector2.MoveTowards(((Graphic) actor).get_rectTransform().get_anchoredPosition(), this._targetPosition, this._speed * Time.get_deltaTime());
      ((Graphic) actor).get_rectTransform().set_anchoredPosition(vector2_1);
      Vector2 vector2_2 = Vector2.op_Subtraction(vector2_1, this._targetPosition);
      float magnitude = ((Vector2) ref vector2_2).get_magnitude();
      float num = Mathf.Pow(Mathf.Max((float) (1.0 - (double) magnitude / (double) this._fadeDistance), 0.0f), (float) Config.AnimationFadePower);
      actor.SetAlpha(num, num, num);
      if ((double) magnitude >= 1.0 / 1000.0)
        return true;
      ((Behaviour) actor).set_enabled(true);
      return false;
    }

    protected override void OnStop(uGUI_ItemIcon actor)
    {
      if (Object.op_Equality((Object) actor, (Object) null))
        return;
      ((Graphic) actor).get_rectTransform().set_anchoredPosition(this._targetPosition);
      actor.SetAlpha(1f, 1f, 1f);
      ((Behaviour) actor).set_enabled(true);
    }
  }
}
