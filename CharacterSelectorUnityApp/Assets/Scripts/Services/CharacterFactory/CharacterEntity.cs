using UnityEngine;

namespace Services.CharacterFactory {
    public class CharacterEntity {
        public string Id { get; }
        public GameObject View { get; }

        public CharacterEntity(string id, GameObject view) {
            Id = id;
            View = view;
        }

        public void DestroyView() {
            Object.Destroy(View);
        }
    }
}
