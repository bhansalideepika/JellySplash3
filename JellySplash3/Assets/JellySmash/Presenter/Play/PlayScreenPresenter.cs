using JellySmash.Model;
using JellySmash.Model.Interface;
using JellySmash.Presenter.Screen.Play;
using UnityEngine;

namespace JellySmash.Presenter.Screen
{
    public class PlayScreenPresenter : ScreenPresenterBehaviour
    {
        public int CurrentLevel { get; private set; }

        private IGameModel _gameModel;
        private GameModel GameModel
        {
            get
            {
                if (_gameModel == null)
                {
                    _gameModel = Get<IGameModel>();
                }

                return (GameModel)_gameModel;
            }
        }

        private void OnEnable()
        {
            CurrentLevel = GameModel.CurrentLevel;
        }

        public void LoadPopup(string popupName)
        {
            OnCreatePopup(popupName);
        }
    }
}