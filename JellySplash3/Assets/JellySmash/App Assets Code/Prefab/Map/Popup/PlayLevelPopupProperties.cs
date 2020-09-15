using JellySmash.Library.Screen.Play;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JellySmash.Properties.Popups
{
    public class PlayLevelPopupProperties : PrefabBehaviour
    {
        public Button CloseButton;
        public Button PlayButton;
        public Text TargetScoreText;
        public Text LevelNameText;
        public LevelsLibrary LevelLibrary;
    }
}
