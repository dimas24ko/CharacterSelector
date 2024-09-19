namespace Services.SaveLocalDataService {
    public class PlayerPrefsManager : ISaveService {

        public void SaveString(string key, string value) {
            UnityEngine.PlayerPrefs.SetString(key, value);
        }

        public string GetString(string key) {
            return UnityEngine.PlayerPrefs.GetString(key);
        }

        public void SaveInt(string key, int value) {
            UnityEngine.PlayerPrefs.SetInt(key, value);
        }
        public int GetInt(string key) {
            return UnityEngine.PlayerPrefs.GetInt(key);
        }
    }
}
