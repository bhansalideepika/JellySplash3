using UnityEngine;
using System;

namespace JellySmash.Factory.Data {
    [Serializable]
    public class Screen : IMarker
    {
        public string Name;
        public GameObject Prefab;
    }
}