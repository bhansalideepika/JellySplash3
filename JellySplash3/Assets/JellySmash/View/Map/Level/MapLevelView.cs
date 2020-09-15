using JellySmash.Presenter.Screen.Map;
using JellySmash.Properties.Screen.Map;
using UnityEngine;

namespace JellySmash.View.Screen.Map
{
    public class MapLevelView : ViewBehaviour<MapLevelProperties, MapLevelPresenter>
    {
        private void Start()
        {
            Prefab.LevelButton.onClick.AddListener(OnLevelButtonClicked);
        }

        private void OnLevelButtonClicked()
        {
            Presenter.LoadLevel(Prefab.LevelNumber);
        }

    }
}
