using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Library
{
    [CreateAssetMenu(fileName = "ScreenLibrary", menuName = "Scriptable Objects/Screen Library")]
    public class ScreenLibrary : ScriptableObject
    {
        public string DefaultScreen;
        public List<JellySmash.Factory.Data.Screen> Screens;
    }
}
