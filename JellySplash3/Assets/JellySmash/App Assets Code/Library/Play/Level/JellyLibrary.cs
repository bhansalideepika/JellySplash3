using JellySmash.Factory.Screen.Play.Data;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Library.Screen.Play
{
    [CreateAssetMenu(fileName = "JellyLibrary", menuName = "Scriptable Objects/Jelly Library")]
    public class JellyLibrary : ScriptableObject
    {
        public GameObject Prefab;
        public List<Jelly> Jellies;
    }
}
