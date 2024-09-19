namespace Services.SaveLocalDataService {
    public interface ISaveService {
        public void SaveString(string key, string value);
        public string GetString(string key);

        public void SaveInt(string key, int value);
        public int GetInt(string key);
    }
}
