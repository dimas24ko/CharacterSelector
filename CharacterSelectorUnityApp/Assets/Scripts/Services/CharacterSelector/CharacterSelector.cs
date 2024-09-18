using Services.CharacterRandomizer;

namespace Services.CharacterSelector {
    public class CharacterSelector {
        private readonly ICharacterRandomizer _characterRandomizer;
        
        public CharacterSelector(ICharacterRandomizer characterRandomizer) {
            _characterRandomizer = characterRandomizer;
        }

        public string SelectRandom() {
            return _characterRandomizer.GetRandomCharacter();
        }
    }
}
