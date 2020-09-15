using UnityEngine;
using System;

namespace JellySmash.Presenter
{
    public class PopupPresenter : PresenterBehaviour
    {
        public Action<string> OnCreatePopup;

        private void OnEnable()
        {
            ScreenPresenterBehaviour.OnCreatePopup += CreatePopup;
        }

        private void OnDestroy()
        {
            ScreenPresenterBehaviour.OnCreatePopup -= CreatePopup;
        }

        public void CreatePopup(string popup)
        {
            OnCreatePopup(popup);
        }
    }
}