using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JellySmash.Properties.Screen.Map
{
    public class MapLevelProperties : PrefabBehaviour
    {
        public int LevelNumber;
        public Button LevelButton;
        public Text LevelNameText;
        public List<Image> Stars;
    }
}
