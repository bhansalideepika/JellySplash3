using DG.Tweening;
using JellySmash.Presenter.Screen.Play;
using JellySmash.Properties.Screen.Play;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JellySmash.View.Screen.Play
{
    public class TileView : ViewBehaviour<TileProperties, TilePresenter>, IPointerHandler
    {
        private void Start()
        {
            Presenter.OnRemoveJelly += RemoveJelly;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Presenter.MouseDown();
            Presenter.MouseEnter(Prefab);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Presenter.MouseUp();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Presenter.MouseEnter(Prefab);
        }

        private void RemoveJelly(int row, int column, int score)
        {
            if (Prefab.Row == row && Prefab.Column == column)
            {
                Destroy(Prefab.JellyProperties.gameObject);
                Prefab.JellyProperties = null;
                Prefab.IsFilled = false;
                ShowScore(score);
            }
        }

        public void RemoveJelly()
        {
            Prefab.JellyProperties = null;
            Prefab.IsFilled = false;
        }

        public void AddJelly(JellyProperties jellyProperties)
        {
            Prefab.JellyProperties = jellyProperties;

            jellyProperties.transform.SetParent(Prefab.transform);

            Prefab.IsFilled = true;
        }

        private void ShowScore(int score)
        {
            Prefab.ScoreText.text = score.ToString();
            Prefab.ScoreText.gameObject.SetActive(true);

            PlayScoreAnimation();
        }

        private void PlayScoreAnimation()
        {
            Sequence tweenSequence = DOTween.Sequence();
            tweenSequence.Pause();

            Tween localMove = Prefab.ScoreText.transform.DOLocalMoveY(10, 0.8f);
            Tween fade = Prefab.ScoreText.DOFade(0, 0.2f);

            tweenSequence.Append(localMove);
            tweenSequence.Append(fade);
            tweenSequence.AppendCallback(ResetScoreText);
            tweenSequence.Play();
        }

        private void ResetScoreText()
        {
            var color = Prefab.ScoreText.color;
            color.a = 1;

            Prefab.ScoreText.color = color;
            Prefab.ScoreText.transform.localPosition = Vector3.zero;
            Prefab.ScoreText.gameObject.SetActive(false);

            Presenter.TileAnimationEnd();
        }
    }
}
