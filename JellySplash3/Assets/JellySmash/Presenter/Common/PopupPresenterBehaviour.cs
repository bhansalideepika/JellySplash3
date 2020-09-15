using JellySmash.Model;
using JellySmash.Model.Interface;
using UnityEngine;

namespace JellySmash.Presenter
{
    public class PopupPresenterBehaviour : ScreenPresenterBehaviour
    {
        public int CurrentSelectedLevel { get; protected set; }
       
        private IGameModel _gameModel;
        protected GameModel GameModel
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

        public void ClosePopup()
        {
            DestroyObject();
        }
    }
}
