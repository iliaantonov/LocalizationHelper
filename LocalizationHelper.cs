using System;
using UnityEngine.Localization.Settings;

namespace Scripts.Utils.LocalizationHelper
{
    public static class LocalizationHelper
    {
        public static void GetLocalizedString(string tableName, string key, System.Action<string> callback)
        {
            var handle = LocalizationSettings.StringDatabase.GetTableAsync(tableName);
            handle.Completed += (op) =>
            {
                var table = op.Result;
                var entry = table?.GetEntry(key);
                callback?.Invoke(entry != null ? entry.GetLocalizedString() : key);
            };
        }

        public static void EasyLocalize(string table, string key, Action<string> setter)
        {
            var operation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(table, key);
            operation.Completed += handle =>
            {
                setter?.Invoke(handle.Result);
            };
        }

        public static void EasyLocalizeArray(string table, string[] phrases, Action<string[]> onCompleted = null)
        {
            int remaining = phrases.Length;
            string[] results = new string[phrases.Length];

            for (int i = 0; i < phrases.Length; i++)
            {
                int index = i;
                string key = phrases[index];

                EasyLocalize(table, key, localized =>
                {
                    results[index] = localized;
                    remaining--;

                    if (remaining == 0)
                        onCompleted?.Invoke(results);
                });
            }
        }

    }
}
