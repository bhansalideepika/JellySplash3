using UnityEngine;
using System;
using JellySmash.Model.Interface;
using JellySmash.Model;

namespace JellySmash.Presenter
{
    public class ScreenPresenter : PresenterBehaviour
    {
        public Action<string> OnCreateScreen;

        private IScreenModel _screenModel;
        private ScreenModel ScreenModel
        {
            get
            {
                if(_screenModel == null)
                {
                    _screenModel = Get<IScreenModel>();
                }

                return (ScreenModel)_screenModel;
            }
        }

        private void OnEnable()
        {
            ScreenPresenterBehaviour.OnCreateScreen += CreateScreen;
            ScreenPresenterBehaviour.OnDestroyCurrentScreen += DestroyCurrentScreen;
        }

        private void OnDestroy()
        {
            ScreenPresenterBehaviour.OnCreateScreen -= CreateScreen;
            ScreenPresenterBehaviour.OnDestroyCurrentScreen -= DestroyCurrentScreen;
        }

        public void DestroyCurrentScreen()
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }

        public void CreateScreen(string screen)
        {
            ScreenModel.CurrentScreen = screen;
            OnCreateScreen(screen);
        }
    }
}