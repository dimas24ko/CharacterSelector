using Services.AssetManager;
using Services.CharacterFactory;
using StateMachine;

namespace Contexts {
    public class GlobalContext {
        public AppStateMachine StateMachine;
        public IAssetManager AssetManager;
        public SimpleCharacterFactory CharacterFactory;

        public string SelectedCharacter;
        
        public void InstallBindings() {
            StateMachine = new AppStateMachine(this);
            AssetManager = new ScriptableAssetManager();
            CharacterFactory = new SimpleCharacterFactory(AssetManager);
            SelectedCharacter = null;
        }
    }
}
