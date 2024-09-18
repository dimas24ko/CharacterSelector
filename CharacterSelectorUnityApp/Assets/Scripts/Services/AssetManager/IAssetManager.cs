using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.AssetManager {
    public interface IAssetManager {
        public Action OnAssetsLoadSuccess { get; set; }
        public Action OnAssetsLoadFail { get; set; }
        
        public void LoadAllAssets();
        public GameObject GetAsset(string key);
        public void ReleaseAssets();
        
        //ToDo: think about the best way to configuration characters ids (get from scriptable object, json, remotes, etc.)
        public List<string> GetAllCharacters();
    }
}
