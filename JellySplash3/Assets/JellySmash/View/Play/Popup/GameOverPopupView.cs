using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Presenter.Popups;
using JellySmash.Properties.Popups;
using UnityEngine;

namespace JellySmash.View.Popups
{
    public class GameOverPopupView : ViewBehaviour<GameOverPopupProperties, GameOverPopupPresenter>
    {
        private void Start()
        {
            Prefab.BackButton.onClick.AddListener(OnBackButtonClicked);
            SetLevelProgressDetails();
        }

        private void OnBackButtonClicked()
        {
            Presenter.LoadScreen("Map");
        }

        private void SetLevelProgressDetails()
        {
            int currentSelectedLevel = Presenter.CurrentSelectedLevel;
            Level selectedLevelData = Prefab.LevelLibrary.Levels[currentSelectedLevel - 1];
            Prefab.LevelNameText.text = "Level " + selectedLevelData.Name;
            Prefab.ScoreAchievedText.text = Presenter.PlayerScore.ToString();

            bool playerWon = (Presenter.PlayerScore >= selectedLevelData.TargetScore);

            Prefab.WinPanel.SetActive(playerWon);
            Prefab.LossPanel.SetActive(!playerWon);

            Presenter.ResetPlayerScore();
        }
    }
}
