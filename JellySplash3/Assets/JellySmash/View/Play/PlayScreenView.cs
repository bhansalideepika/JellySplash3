using JellySmash.Factory;
using JellySmash.Factory.Screen.Play;
using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Presenter.Screen;
using JellySmash.Properties.Screen;
using UnityEngine;

namespace JellySmash.View.Screen
{
    public class PlayScreenView : ViewBehaviour<PlayScreenProperties, PlayScreenPresenter>
    {
        private void Start()
        {
            Prefab.BackButton.onClick.AddListener(OnBackButtonClicked);

            CreateSelectedLevel();
        }

        private void CreateSelectedLevel()
        {
            int currentLevel = Presenter.CurrentLevel;
            
            IFactory LevelFactory = new LevelFactory();
            LevelFactory.Parent = Prefab.GridContainer;
            LevelFactory.Prefab = Prefab.LevelsLibrary.GridPrefab;

            Level currentLevelData = Prefab.LevelsLibrary.Levels[currentLevel - 1];
            LevelFactory.Create(currentLevelData);
        }

        private void OnBackButtonClicked()
        {
            Presenter.LoadPopup("GameOverPopup");
        }
    }
}