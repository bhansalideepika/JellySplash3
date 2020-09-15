using JellySmash.Model;
using JellySmash.Model.Interface;
using JellySmash.Presenter;
using UnityEngine;

namespace JellySmash.Presenter.Popups
{
    public class GameOverPopupPresenter : PopupPresenterBehaviour
    {
        public int PlayerScore { get; private set; }

        private void OnEnable()
        {
            CurrentSelectedLevel = GameModel.CurrentLevel;
            PlayerScore = GameModel.PlayerScore;
        }

        public void LoadScreen(string screenName)
        {
            DestroyCurrentScreen();
            OnCreateScreen(screenName);
            ClosePopup();
        }

        public void ResetPlayerScore()
        {
            GameModel.SavePlayerScore(0);
        }
    }
}
