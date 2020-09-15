using JellySmash.Model;
using JellySmash.Model.Interface;
using JellySmash.Presenter;
using UnityEngine;

namespace JellySmash.Presenter.Popups
{
    public class PlayLevelPopupPresenter : PopupPresenterBehaviour
    {
        private void OnEnable()
        {
            CurrentSelectedLevel = GameModel.CurrentLevel;
        }

        public void LoadSelectedLevel()
        {
            DestroyCurrentScreen();
            OnCreateScreen("Play");
            ClosePopup();
        }

        public void SaveLevelTargetScore(int targetScore)
        {
            GameModel.SaveLevelTargetScore(targetScore);
        }
    }
}
