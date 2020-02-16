//using System;
//using System.IO;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using UnityEngine;
//using UnityEngine.UIElements;
//using UnityEditor;
//using UnityEditorInternal;

//namespace Shooter.Editor
//{
//    [InitializeOnLoad]
//    public static class DarkTheme 
//    {
//        static DarkTheme()
//        {
//            InitAsync();
//        }

//        private static async void InitAsync()
//        {
//            await Task.Delay(TimeSpan.FromSeconds(0.1f));
//            string darkMarker = Path.Combine(Application.persistentDataPath, "dark");
//            if (File.Exists(darkMarker))
//            {
//                File.Delete(darkMarker);
//                return;
//            }
//            using (StreamWriter sw = new StreamWriter(darkMarker))
//            {
//                sw.Write(true);
//            }
//            Init();
//        }

//        [MenuItem("Theme/Init Dark Theme")]
//        private static void Init()
//        {
//            foreach (var sheet in Resources.FindObjectsOfTypeAll<StyleSheet>())
//            {
//                if (ContainsInsensitive(sheet.name, "Dark"))
//                    continue;

//                if (!ContainsInsensitive(sheet.name, "Light"))
//                {
//                    InvertColors(sheet);
//                    continue;
//                }

//                StyleSheet dark;
//                var path = ReplaceInsensitive(AssetDatabase.GetAssetPath(sheet), "Light", "Dark");
//                var name = ReplaceInsensitive(sheet.name, "Light", "Dark");

//                if (path == "Library/unity editor resources")
//                    dark = EditorGUIUtility.Load(name) as StyleSheet;
//                else
//                    dark = AssetDatabase.LoadAssetAtPath<StyleSheet>(path);

//                if (!dark)
//                    InvertColors(sheet);
//                else
//                {
//                    string oldName = sheet.name;
//                    EditorUtility.CopySerialized(dark, sheet);
//                    sheet.name = oldName;
//                }
//            }

//            EditorUtility.RequestScriptReload();
//            InternalEditorUtility.RepaintAllViews();
//        }

//        static void InvertColors(StyleSheet sheet)
//        {
//            var serialized = new SerializedObject(sheet); serialized.Update();
//            var colors = serialized.FindProperty("colors");

//            for (int i = 0; i < colors.arraySize; i++)
//            {
//                var property = colors.GetArrayElementAtIndex(i);
//                Color.RGBToHSV(property.colorValue, out var h, out var s, out var v);
//                property.colorValue = Color.HSVToRGB(h, s, 1 - v);
//            }

//            serialized.ApplyModifiedProperties();
//        }

//        static string ReplaceInsensitive(string str, string oldValue, string newValue)
//        {
//            return Regex.Replace(str,
//                Regex.Escape(oldValue),
//                newValue.Replace("$", "$$"), RegexOptions.IgnoreCase);
//        }

//        static bool ContainsInsensitive(string str, string find)
//        {
//            return str.IndexOf(find, StringComparison.OrdinalIgnoreCase) != -1;
//        }
//    }
//}
