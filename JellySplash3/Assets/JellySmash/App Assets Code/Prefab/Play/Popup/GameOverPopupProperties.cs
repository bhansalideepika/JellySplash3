using JellySmash.Library.Screen.Play;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JellySmash.Properties.Popups
{
    public class GameOverPopupProperties : PrefabBehaviour
    {
        public Button BackButton;
        public Text ScoreAchievedText;
        public Text LevelNameText;
        public GameObject WinPanel;
        public GameObject LossPanel;
        public LevelsLibrary LevelLibrary;
    }
}
