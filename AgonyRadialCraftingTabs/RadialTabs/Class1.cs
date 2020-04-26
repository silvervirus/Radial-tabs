using System;
using System.Collections.Generic;
using UnityEngine;

namespace Agony.RadialTabs
{
	// Token: 0x0200000E RID: 14
	public abstract class ItemIconAnimation
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002934 File Offset: 0x00000B34
		private static void UpdateAnimations()
		{
			List<uGUI_ItemIcon> list = new List<uGUI_ItemIcon>();
			foreach (KeyValuePair<uGUI_ItemIcon, ItemIconAnimation> keyValuePair in ItemIconAnimation.animations)
			{
				if (!keyValuePair.Value.OnUpdate(keyValuePair.Key))
				{
					list.Add(keyValuePair.Key);
				}
			}
			list.ForEach(delegate (uGUI_ItemIcon x)
			{
				ItemIconAnimation.animations.Remove(x);
			});
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000029CC File Offset: 0x00000BCC
		public static void Play(uGUI_ItemIcon actor, ItemIconAnimation newAnimation)
		{
			if (actor == null)
			{
				throw new ArgumentNullException("actor is null");
			}
			if (newAnimation == null)
			{
				throw new ArgumentNullException("newAnimation is null");
			}
			ItemIconAnimation.InitializeUpdater();
			if (ItemIconAnimation.animations.ContainsKey(actor))
			{
				ItemIconAnimation.animations[actor].OnStop(actor);
			}
			ItemIconAnimation.animations[actor] = newAnimation;
			newAnimation.OnStart(actor);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002A31 File Offset: 0x00000C31
		private static void InitializeUpdater()
		{
			if (ItemIconAnimation.updater == null)
			{
				ItemIconAnimation.updater = new GameObject("ItemIconAnimationUpdater").AddComponent<ItemIconAnimation.Updater>();
			}
		}

		// Token: 0x0600003A RID: 58
		protected abstract void OnStart(uGUI_ItemIcon actor);

		// Token: 0x0600003B RID: 59
		protected abstract bool OnUpdate(uGUI_ItemIcon actor);

		// Token: 0x0600003C RID: 60
		protected abstract void OnStop(uGUI_ItemIcon actor);

		// Token: 0x04000017 RID: 23
		private static ItemIconAnimation.Updater updater;

		// Token: 0x04000018 RID: 24
		private static readonly Dictionary<uGUI_ItemIcon, ItemIconAnimation> animations = new Dictionary<uGUI_ItemIcon, ItemIconAnimation>();

		// Token: 0x02000014 RID: 20
		private sealed class Updater : MonoBehaviour
		{
			// Token: 0x06000050 RID: 80 RVA: 0x00002E81 File Offset: 0x00001081
			private void Update()
			{
				ItemIconAnimation.UpdateAnimations();
			}
		}
	}
}
