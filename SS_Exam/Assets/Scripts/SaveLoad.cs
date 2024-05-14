using UnityEngine;
using System.Collections.Generic;


    public class SaveLoad
    {
        private static SavedKeyNames keys = new SavedKeyNames();

        private class SavedKeyNames
        {
            public List<string> keyNames;

            public SavedKeyNames()
            {
                keyNames = new List<string>();
            }
        }

        static SaveLoad()
        {
            LoadKeys(); // Load the keys from PlayerPrefs
        }


        // Methods for 'Keys' 
        private static void SaveKeys()
        {
            string keysJson = JsonUtility.ToJson(keys);
            PlayerPrefs.SetString("Keys", keysJson);
        }

        private static void LoadKeys()
        {
            string keysJson = PlayerPrefs.GetString("Keys", null);
            if (string.IsNullOrEmpty(keysJson))
            {
                keys = new SavedKeyNames();
            }
            else
            {
                keys = JsonUtility.FromJson<SavedKeyNames>(keysJson);
                if (keys == null)
                {
                    keys = new SavedKeyNames();
                }
            }
        }

        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public static void DeleteKey(string key)
        {
            keys.keyNames.Remove(key);
            PlayerPrefs.DeleteKey(key);
            SaveKeys();
        }

        public static void DeleteAllKeys()
        {
            keys.keyNames.Clear();
            PlayerPrefs.DeleteAll();
            SaveKeys();
        }

        public static void PrintAllKeys()
        {
            string printOutput = "Keys: ";
            for(int i = 0; i < keys.keyNames.Count; i++)
            {
                if (i != 0)
                {
                    printOutput += ", ";
                }

                printOutput += keys.keyNames[i];
            }
            Debug.Log(printOutput);
        }


        // Methods for 'Save'
        public static bool SaveObject(string key, object value)
        {
            string json = JsonUtility.ToJson(value);

            if (json == null)
            {
                Debug.LogError("Couldn't save: " + key);
                return false;
            }
            PlayerPrefs.SetString(key, json);

            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }

            SaveKeys();

            return true;
        }

        public static void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }
            SaveKeys();
        }

        public static void SaveFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }
            SaveKeys();
        }

        public static void SaveString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }
            SaveKeys();
        }

        public static void SaveBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }
            SaveKeys();
        }

        public static void SaveVector2(string key, Vector2 value)
        {
            string json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, json);
            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }
            SaveKeys();
        }

        public static void SaveVector3(string key, Vector3 value)
        {
            string json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, json);
            if (!keys.keyNames.Contains(key))
            {
                keys.keyNames.Add(key);
            }
            SaveKeys();
        }


        // Methods for 'Load'
        public static T LoadObject<T>(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("Couldn't load: " + key);
                return default(T);
            }

            string json = PlayerPrefs.GetString(key, "{}");
            T value = JsonUtility.FromJson<T>(json);

            Debug.Log("Loaded: " + key);
            return value;
        }

        public static int LoadInt(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("LoadInt: key not found - *0 is returned as default value*");
                return 0;
            }

            int value = PlayerPrefs.GetInt(key);
            return value;
        }

        public static float LoadFloat(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("LoadFloat: key not found - *0f is returned as default value*");
                return 0f;
            }

            float value = PlayerPrefs.GetFloat(key);
            return value;
        }

        public static string LoadString(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("LoadString: key not found - *empty string is returned as default value*");
                return "";
            }

            string value = PlayerPrefs.GetString(key);
            return value;
        }

        public static bool LoadBool(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("LoadBool: key not found - *false is returned as default value*");
                return false;
            }

            int value = PlayerPrefs.GetInt(key);
            return value == 1;
        }

        public static Vector2 LoadVector2(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("LoadVector2: key not found - *Vector2.zero is returned as default value*");
                return Vector2.zero;
            }

            string json = PlayerPrefs.GetString(key);
            Vector2 value = JsonUtility.FromJson<Vector2>(json);
            return value;
        }

        public static Vector3 LoadVector3(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError("LoadVector3: key not found - *Vector3.zero is returned as default value*");
                return Vector3.zero;
            }

            string json = PlayerPrefs.GetString(key);
            Vector3 value = JsonUtility.FromJson<Vector3>(json);
            return value;
        }
    }
