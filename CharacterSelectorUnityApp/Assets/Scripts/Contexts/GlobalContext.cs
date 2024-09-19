using Services.AssetManager;
using Services.CharacterFactory;
using Services.SaveLocalDataService;
using StateMachine;

namespace Contexts {
    public class GlobalContext {
        public AppStateMachine StateMachine;
        public IAssetManager AssetManager;
        public SimpleCharacterFactory CharacterFactory;
        public ISaveService SaveService;

        public string SelectedCharacter { get; private set; }

        public void InstallBindings() {
            StateMachine = new AppStateMachine(this);
            AssetManager = new ScriptableAssetManager();
            CharacterFactory = new SimpleCharacterFactory(AssetManager);
            SaveService = new PlayerPrefsManager();
            SelectedCharacter = SaveService.GetString(StaticDataConst.CharacterSaveKey);
        }

        public void SetSelectedCharacter(string character) {
            SelectedCharacter = character;
            SaveService.SaveString(StaticDataConst.CharacterSaveKey, character);
        }
    }
}
