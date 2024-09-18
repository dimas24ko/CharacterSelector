using Services.CharacterRandomizer;

namespace Services.CharacterSelector {
    public class RandomCharacterSelector : ICharacterSelectStrategy {
        private readonly ICharacterRandomizeStrategy _characterRandomizeStrategy;

        public RandomCharacterSelector(ICharacterRandomizeStrategy characterRandomizeStrategy) {
            _characterRandomizeStrategy = characterRandomizeStrategy;
        }

        public string GetNextCharacter() {
            return _characterRandomizeStrategy.GetRandomCharacter();
        }
    }
}
