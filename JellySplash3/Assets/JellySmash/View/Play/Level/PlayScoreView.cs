using DG.Tweening;
using JellySmash.Presenter.Screen.Play;
using JellySmash.Properties.Screen.Play;

namespace JellySmash.View.Screen.Play
{
    public class PlayScoreView : ViewBehaviour<PlayScoreProperties, PlayScorePresenter>
    {
        private void Start()
        {
            Presenter.OnSetScore += SetScore;
            SetTargetText();
            ResetText();
        }

        private void SetTargetText()
        {
            Prefab.TargetText.text = Presenter.TargetScore.ToString();
        }

        private void ResetText()
        {
            Prefab.ScoreText.text = "0";
        }

        private void SetScore(int turnScore)
        {
            int playerScore = Presenter.PlayerScore;
            int endValue = playerScore + turnScore;

            DOTween.To(() => playerScore, i => Prefab.ScoreText.text = (playerScore = i).ToString(), endValue, 0.5f).OnComplete(Presenter.CheckTargetReached);

            SetStars(endValue);
        }

        private void SetStars(int currentScore)
        {
            int targetScore = Presenter.TargetScore;
            int perStarScore = targetScore / 3;

            for (int i = 0; i < Prefab.Stars.Count; i++)
            {
                float fillAmount = (float)currentScore / perStarScore;

                if (Prefab.Stars[i].fillAmount < 1)
                {
                    Prefab.Stars[i].DOFillAmount(fillAmount, 0.2f);
                }

                currentScore -= perStarScore;
                if(currentScore < 0)
                {
                    break;
                }
            }
        }
    }
}
