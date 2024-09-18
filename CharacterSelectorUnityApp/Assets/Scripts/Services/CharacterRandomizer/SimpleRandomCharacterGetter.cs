using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.CharacterRandomizer {
    public class SimpleRandomCharacterGetter : ICharacterRandomizer {
        public IEnumerable<string> Characters { get; }

        public SimpleRandomCharacterGetter(IEnumerable<string> characters) {
            Characters = characters;
        }

        public string GetRandomCharacter() {
            int randomIndex = new Random().Next(0, Characters.Count());
            return Characters.ElementAt(randomIndex);
        }
    }
}
