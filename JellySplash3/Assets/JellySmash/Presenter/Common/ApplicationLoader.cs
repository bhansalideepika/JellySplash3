using System;
using UnityEngine;

namespace JellySmash.Presenter.Screen
{
    public class ApplicationLoader : ScreenPresenterBehaviour
    {
        private void Start()
        {
            OnCreateScreen("Home");
        }
    }
}
