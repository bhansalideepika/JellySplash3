using JellySmash.Presenter.Screen.Map;
using UnityEngine;

namespace JellySmash.Presenter.Screen
{
    public class MapScreenPresenter : ScreenPresenterBehaviour
    {
        private void Start()
        {
            MapLevelPresenter.OnMapLevelClicked += LoadPlayLevelPopup;
            //MapLevelPresenter.OnMapLevelClicked += LoadPlayScreen;
            //PlayLevelPopupPresenter.OnPlayLevelClicked += LoadPlayScreen;
        }

        private void OnDestroy()
        {
            MapLevelPresenter.OnMapLevelClicked -= LoadPlayLevelPopup;
            //MapLevelPresenter.OnMapLevelClicked -= LoadPlayScreen;
            //PlayLevelPopupPresenter.OnPlayLevelClicked -= LoadPlayScreen;
        }

        private void LoadPlayLevelPopup()
        {
            OnCreatePopup("PlayLevelPopup");
        }

        private void LoadPlayScreen()
        {
            OnCreateScreen("Play");
            DestroyObject();
        }
    }
}
