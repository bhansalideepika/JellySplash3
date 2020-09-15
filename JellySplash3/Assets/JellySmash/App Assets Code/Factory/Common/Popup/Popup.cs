using UnityEngine;
using System;

namespace JellySmash.Factory.Data {
    [Serializable]
    public class Popup : IMarker
    {
        public string Name;
        public GameObject Prefab;
    }
}