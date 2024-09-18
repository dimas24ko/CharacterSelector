using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.CharacterRandomizer {
    public class SimpleRandomCharacterGetter : ICharacterRandomizeStrategy {
        private readonly IEnumerable<string> _charactersIds;

        //ToDo: add seed if needed
        private readonly Random _random = new Random();

        public SimpleRandomCharacterGetter(IEnumerable<string> charactersIds) {
            _charactersIds = charactersIds;
        }

        public string GetRandomCharacter() {
            int randomIndex = _random.Next(0, _charactersIds.Count());
            return _charactersIds.ElementAt(randomIndex);
        }
    }
}
