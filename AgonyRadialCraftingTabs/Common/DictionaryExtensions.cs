using System;
using System.Collections.Generic;

namespace Agony.Common
{
	// Token: 0x02000003 RID: 3
	internal static class DictionaryExtensions
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020C0 File Offset: 0x000002C0
		public static Dictionary<TKey, TValue> FindAll<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Predicate<KeyValuePair<TKey, TValue>> match)
		{
			Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
			dictionary.ForEach(delegate (KeyValuePair<TKey, TValue> x)
			{
				if (match(x))
				{
					result.Add(x.Key, x.Value);
				}
			});
			return result;
		}
	}
}
