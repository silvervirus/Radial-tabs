// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.ItemIconAnimation
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Agony.RadialTabs
{
  public abstract class ItemIconAnimation
  {
    private static readonly Dictionary<uGUI_ItemIcon, ItemIconAnimation> animations = new Dictionary<uGUI_ItemIcon, ItemIconAnimation>();
    private static ItemIconAnimation.Updater updater;

    private static void UpdateAnimations()
    {
      List<uGUI_ItemIcon> uGuiItemIconList = new List<uGUI_ItemIcon>();
      using (Dictionary<uGUI_ItemIcon, ItemIconAnimation>.Enumerator enumerator = ItemIconAnimation.animations.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          KeyValuePair<uGUI_ItemIcon, ItemIconAnimation> current = enumerator.Current;
          if (!current.Value.OnUpdate(current.Key))
            uGuiItemIconList.Add(current.Key);
        }
      }
      uGuiItemIconList.ForEach((Action<uGUI_ItemIcon>) (x => ItemIconAnimation.animations.Remove(x)));
    }

    public static void Play(uGUI_ItemIcon actor, ItemIconAnimation newAnimation)
    {
      if (Object.op_Equality((Object) actor, (Object) null))
        throw new ArgumentNullException("actor is null");
      if (newAnimation == null)
        throw new ArgumentNullException("newAnimation is null");
      ItemIconAnimation.InitializeUpdater();
      if (ItemIconAnimation.animations.ContainsKey(actor))
        ItemIconAnimation.animations[actor].OnStop(actor);
      ItemIconAnimation.animations[actor] = newAnimation;
      newAnimation.OnStart(actor);
    }

    private static void InitializeUpdater()
    {
      if (!Object.op_Equality((Object) ItemIconAnimation.updater, (Object) null))
        return;
      ItemIconAnimation.updater = (ItemIconAnimation.Updater) new GameObject("ItemIconAnimationUpdater").AddComponent<ItemIconAnimation.Updater>();
    }

    protected abstract void OnStart(uGUI_ItemIcon actor);

    protected abstract bool OnUpdate(uGUI_ItemIcon actor);

    protected abstract void OnStop(uGUI_ItemIcon actor);

    private sealed class Updater : MonoBehaviour
    {
      private void Update()
      {
        ItemIconAnimation.UpdateAnimations();
      }

      public Updater()
      {
        base.\u002Ector();
      }
    }
  }
}
