using JellySmash.Factory.Screen.Map.Data;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Library.Screen
{
    [CreateAssetMenu(fileName = "MapLibrary", menuName = "Scriptable Objects/Map Library")]
    public class MapLibrary : ScriptableObject
    {
        public string DefaultMap;
        public GameObject MapLevelPrefab;
        public List<Map> Maps;
    }
}
