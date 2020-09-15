using JellySmash.Model;
using JellySmash.Model.Interface;
using System;
using UnityEngine;

namespace JellySmash.Presenter.Screen.Map
{
    public class MapLevelPresenter : PresenterBehaviour
    {
        public static Action OnMapLevelClicked;

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

        public void LoadLevel(int levelNumber)
        {
            GameModel.CurrentLevel = levelNumber;
            OnMapLevelClicked();
        }
    }
}
