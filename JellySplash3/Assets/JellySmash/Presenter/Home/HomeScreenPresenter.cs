using System;
using UnityEngine;

namespace JellySmash.Presenter.Screen
{
    public class HomeScreenPresenter : ScreenPresenterBehaviour
    {
        public void CreateScreen(string screenName)
        {
            OnCreateScreen(screenName);
            DestroyObject();
        }
    }
}
