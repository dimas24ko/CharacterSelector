using System;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Services.AssetManager {
    public class ScriptableAssetManager : IAssetManager {
        private const string CharacterScriptableObjectPath = "ScriptableObjects/CharactersPrefabs";

        private readonly Dictionary<string, GameObject> _loadedAssetsMap = new();

        public Action OnAssetsLoadSuccess { get; set; }
        public Action OnAssetsLoadFail { get; set; }

        public void LoadAllAssets() {
            CharactersPrefabs characters = Resources.Load<CharactersPrefabs>(CharacterScriptableObjectPath);

            if (characters == null) {
                OnAssetsLoadFail?.Invoke();
                return;
            }

            foreach (GameObject character in characters.characters) {
                if (character == null) {
                    OnAssetsLoadFail?.Invoke();
                    return;
                }

                _loadedAssetsMap.Add(character.name, character);
            }

            OnAssetsLoadSuccess?.Invoke();
        }

        public GameObject GetAsset(string key) {
            return _loadedAssetsMap[key];
        }

        public List<string> GetAllCharacters() {
            return new List<string>(_loadedAssetsMap.Keys);
        }

        //ToDo: connect when needed
        public void ReleaseAssets() {
            foreach (GameObject asset in _loadedAssetsMap.Values) {
                Resources.UnloadAsset(asset);
            }

            _loadedAssetsMap.Clear();
        }
    }
}
