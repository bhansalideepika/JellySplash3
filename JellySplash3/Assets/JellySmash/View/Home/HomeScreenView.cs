using JellySmash.Presenter.Screen;
using JellySmash.Properties.Screen;
using UnityEngine;

namespace JellySmash.View.Screen
{
    public class HomeScreenView : ViewBehaviour<HomeScreenProperties, HomeScreenPresenter>
    {

        private void Start()
        {
            Prefab.PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            Presenter.CreateScreen("Map");
        }
    }
}
