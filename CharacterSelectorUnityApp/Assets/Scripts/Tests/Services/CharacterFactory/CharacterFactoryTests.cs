using System;
using System.Collections.Generic;
using NUnit.Framework;
using Services.AssetManager;
using Services.CharacterFactory;
using UnityEngine;

namespace Tests.Services.CharacterFactory {
    public class CharacterFactoryTests {
        [Test]
        public void TestSimpleCharacterFactory_CreateCharacter() {
            var assetManager = new MockAssetManager();
            assetManager.LoadAllAssets();
            var characterFactory = new SimpleCharacterFactory(assetManager);
            string characterId = "character1";
            Transform parent = new GameObject("parent").transform;

            CharacterEntity character = characterFactory.CreateCharacter(characterId, parent);

            Assert.AreEqual(characterId, character.Id);
            Assert.AreEqual(characterId + "(Clone)", character.View.name);
            Assert.AreEqual(parent, character.View.transform.parent);
        }
    }

    public class MockAssetManager : IAssetManager {
        private readonly Dictionary<string, GameObject> _assets = new Dictionary<string, GameObject>();

        public Action OnAssetsLoadSuccess { get; set; }
        public Action OnAssetsLoadFail { get; set; }

        public void LoadAllAssets() {
            _assets.Add("character1", new GameObject("character1"));
            _assets.Add("character2", new GameObject("character2"));
        }

        public GameObject GetAsset(string assetId) {
            _assets.TryGetValue(assetId, out GameObject asset);
            return asset;
        }

        public void ReleaseAssets() {
            _assets.Clear();
        }

        public List<string> GetAllCharacters() {
            return new List<string>(_assets.Keys);
        }
    }
}
