using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Presenter.Popups;
using JellySmash.Properties.Popups;
using UnityEngine;

namespace JellySmash.View.Popups
{
    public class PlayLevelPopupView : ViewBehaviour<PlayLevelPopupProperties, PlayLevelPopupPresenter>
    {
        private void Start()
        {
            Prefab.CloseButton.onClick.AddListener(OnCloseButtonClicked);
            Prefab.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            SetSelectedLevelDetails();
        }

        private void OnPlayButtonClicked()
        {
            Presenter.LoadSelectedLevel();
        }

        private void OnCloseButtonClicked()
        {
            Presenter.ClosePopup();
        }

        private void SetSelectedLevelDetails()
        {
            int currentSelectedLevel = Presenter.CurrentSelectedLevel;
            Level selectedLevelData = Prefab.LevelLibrary.Levels[currentSelectedLevel - 1];
            Prefab.LevelNameText.text = "Level " + selectedLevelData.Name;
            Prefab.TargetScoreText.text = selectedLevelData.TargetScore.ToString();

            Presenter.SaveLevelTargetScore(selectedLevelData.TargetScore);
        }
    }
}
