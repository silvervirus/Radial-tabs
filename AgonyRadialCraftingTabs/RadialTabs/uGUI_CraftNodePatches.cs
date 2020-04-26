
using UnityEngine;
using Harmony;
using Agony.Common.Reflectors;

namespace Agony.RadialTabs
{
    internal static class uGUI_CraftNodePatches
    {
        [HarmonyPatch(typeof(uGUI_CraftNode), "CreateIcon")]
        private static class CreateIconPatch
        {
            private static void Postfix(uGUI_CraftNode __instance)
            {
                RadialCell radialCell = RadialCell.Create(__instance);
				var icon = __instance.icon;
                var vector = new Vector2(radialCell.size, radialCell.size);
				icon.SetBackgroundSize(vector);
				icon.SetActiveSize(vector);
				float num = radialCell.size * (float)Config.IconForegroundSizeMult;
				icon.SetForegroundSize(num, num, true);
				icon.SetBackgroundRadius(radialCell.size / 2f);
				icon.rectTransform.SetParent(uGUI_CraftNodeReflector.GetView(__instance).iconsCanvas);
				icon.SetPosition(radialCell.parent.Position);
			}
		}

		// Token: 0x02000017 RID: 23
		[HarmonyPatch(typeof(uGUI_CraftNode), "SetVisible")]
		private static class SetVisiblePatch
		{
			// Token: 0x06000056 RID: 86 RVA: 0x00002F40 File Offset: 0x00001140
			private static void Postfix(uGUI_CraftNode __instance)
			{
				if (__instance.icon == null)
				{
					return;
				}
				RadialCell radialCell = RadialCell.Create(__instance);
				Vector2 targetPosition = uGUI_CraftNodeReflector.GetVisible(__instance) ? radialCell.Position : radialCell.parent.Position;
				float speed = (radialCell.radius + radialCell.size) * (float)Config.AnimationSpeedMult;
				float fadeDistance = radialCell.size * (float)Config.AnimationFadeDistanceMult;
				GhostMoving newAnimation = new GhostMoving(speed, fadeDistance, targetPosition);
				ItemIconAnimation.Play(__instance.icon, newAnimation);
			}
		}

		// Token: 0x02000018 RID: 24
		[HarmonyPatch(typeof(uGUI_CraftNode), "Punch")]
		private static class PunchPatch
		{
			// Token: 0x06000057 RID: 87 RVA: 0x00002FB5 File Offset: 0x000011B5
			private static bool Prefix()
			{
				return false;
			}
		}
	}
}
