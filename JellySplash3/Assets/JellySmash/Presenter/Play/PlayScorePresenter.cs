using JellySmash.Model;
using System;

namespace JellySmash.Presenter.Screen.Play
{
    public class PlayScorePresenter : PopupPresenterBehaviour
    {
        public Action<int> OnSetScore;
        public int PlayerScore { get; private set; }
        public int TargetScore { get; private set; }

        private void OnEnable()
        {
            GridPresenter.OnSetScore += SetScore;
            TargetScore = GameModel.TargetScore;
        }

        private void OnDestroy()
        {
            GridPresenter.OnSetScore -= SetScore;
        }

        private void SetScore(int turnScore)
        {
            OnSetScore(turnScore);
            PlayerScore += turnScore;
            GameModel.SavePlayerScore(PlayerScore);
        }

        public void CheckTargetReached()
        {
            if (GameModel.IsTargetAchieved)
            {
                LoadPopup("GameOverPopup");
            }
        }

        private void LoadPopup(string popupName)
        {
            OnCreatePopup(popupName);
        }
    }
}
