using JellySmash.Factory.Screen.Play.Data;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Library.Screen.Play
{
    [CreateAssetMenu(fileName = "LevelsLibrary", menuName = "Scriptable Objects/Levels Library")]
    public class LevelsLibrary : ScriptableObject
    {
        public GameObject GridPrefab;
        public GameObject LineRenderer;
        public List<Level> Levels;
    }
}
