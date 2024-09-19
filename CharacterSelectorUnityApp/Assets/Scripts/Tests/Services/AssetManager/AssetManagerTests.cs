using NUnit.Framework;
using Services.AssetManager;
using UnityEngine;

namespace Tests.Services.AssetManager {
    public class AssetManagerTests {
        [Test]
        public void TestAssetManager_ScriptableAssetManager_GetAsset() {
            var assetManager = new ScriptableAssetManager();
            assetManager.LoadAllAssets();
            string characterId = "Character1";

            GameObject character = assetManager.GetAsset(characterId);

            Assert.IsNull(character);

            characterId = "Chara_00";
            character = assetManager.GetAsset(characterId);

            Assert.IsNotNull(character);
        }
    }
}
