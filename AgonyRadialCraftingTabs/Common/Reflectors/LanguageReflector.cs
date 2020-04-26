using System;
using System.Collections.Generic;
using System.Reflection;

namespace Agony.Common.Reflectors
{
	// Token: 0x02000009 RID: 9
	internal static class LanguageReflector
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002409 File Offset: 0x00000609
		public static Dictionary<string, string> GetStrings(Language language)
		{
			if (language == null)
			{
				throw new ArgumentNullException("language is null");
			}
			return (Dictionary<string, string>)LanguageReflector.stringsFieldInfo.GetValue(language);
		}

		// Token: 0x04000003 RID: 3
		private static readonly FieldInfo stringsFieldInfo = typeof(Language).GetField("strings", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
