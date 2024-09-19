using Services.AssetManager;
using UnityEngine;

namespace Services.CharacterFactory {
    public class SimpleCharacterFactory {
        private readonly IAssetManager _assetManager;

        public SimpleCharacterFactory(IAssetManager assetManager) {
            _assetManager = assetManager;
        }

        public CharacterEntity CreateCharacter(string characterId, Transform parent) {
            GameObject prefab = _assetManager.GetAsset(characterId);
            GameObject view = Object.Instantiate(prefab, parent);
            var entity = new CharacterEntity(characterId, view);
            return entity;
        }
    }
}
