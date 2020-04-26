using System;
using UnityEngine;

namespace Agony.RadialTabs
{
	// Token: 0x0200000C RID: 12
	internal sealed class GhostMoving : ItemIconAnimation
	{
		// Token: 0x0600001E RID: 30 RVA: 0x0000261A File Offset: 0x0000081A
		public GhostMoving(float speed, float fadeDistance, Vector2 targetPosition)
		{
			this._speed = speed;
			this._targetPosition = targetPosition;
			this._fadeDistance = fadeDistance;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002637 File Offset: 0x00000837
		protected override void OnStart(uGUI_ItemIcon actor)
		{
			if (actor == null)
			{
				return;
			}
			actor.SetAlpha(0f, 0f, 0f);
			actor.enabled = false;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002660 File Offset: 0x00000860
		protected override bool OnUpdate(uGUI_ItemIcon actor)
		{
			if (actor == null)
			{
				return false;
			}
			Vector2 vector = actor.rectTransform.anchoredPosition;
			vector = Vector2.MoveTowards(vector, this._targetPosition, this._speed * Time.deltaTime);
			actor.rectTransform.anchoredPosition = vector;
			float magnitude = (vector - this._targetPosition).magnitude;
			float num = Mathf.Max(1f - magnitude / this._fadeDistance, 0f);
			num = Mathf.Pow(num, (float)Config.AnimationFadePower);
			actor.SetAlpha(num, num, num);
			if (magnitude < 0.001f)
			{
				actor.enabled = true;
				return false;
			}
			return true;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026FF File Offset: 0x000008FF
		protected override void OnStop(uGUI_ItemIcon actor)
		{
			if (actor == null)
			{
				return;
			}
			actor.rectTransform.anchoredPosition = this._targetPosition;
			actor.SetAlpha(1f, 1f, 1f);
			actor.enabled = true;
		}

		// Token: 0x0400000B RID: 11
		private float _speed;

		// Token: 0x0400000C RID: 12
		private float _fadeDistance;

		// Token: 0x0400000D RID: 13
		private Vector2 _targetPosition;
	}
}
