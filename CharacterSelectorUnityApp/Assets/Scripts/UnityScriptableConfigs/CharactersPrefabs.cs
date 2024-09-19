using System.Collections.Generic;
using UnityEngine;

namespace UnityScriptableConfigs {
    [CreateAssetMenu(fileName = "CharactersPrefabs", menuName = "MyAssets/CharactersPrefabs", order = 0)]
    public class CharactersPrefabs : ScriptableObject {
        public List<GameObject> characters;
    }
}
