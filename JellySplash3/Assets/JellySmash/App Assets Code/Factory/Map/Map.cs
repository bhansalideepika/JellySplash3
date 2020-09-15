using System;
using UnityEngine;

namespace JellySmash.Factory.Screen.Map.Data
{
    [Serializable]
    public class Map : IMarker
    {
        public string Name;
        public GameObject Prefab;
        public int MinLevel;
    }
}