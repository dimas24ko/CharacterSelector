using Services.AssetManager;
using UnityEngine;

namespace Services.CharacterPrefabFactory {
    public class SimpleCharacterFactory {
        private readonly IAssetManager _assetManager;
        
        public SimpleCharacterFactory(IAssetManager assetManager) {
            _assetManager = assetManager;
        }

        public GameObject CreateCharacter(string characterId, Transform parent) {
            GameObject character = _assetManager.GetAsset(characterId);
            return Object.Instantiate(character, parent);
        }
    }
}
