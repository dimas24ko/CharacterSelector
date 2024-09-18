using System.Collections.Generic;

namespace Services.RandomCharacterSelector {
    public interface ICharacterRandomizer {
        public IEnumerable<string> Characters { get; }
        public string GetRandomCharacter();
    }
}
