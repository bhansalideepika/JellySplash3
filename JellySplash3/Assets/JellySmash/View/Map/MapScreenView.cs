using JellySmash.Factory.Screen.Map;
using JellySmash.Presenter.Screen;
using JellySmash.Properties.Screen;

namespace JellySmash.View.Screen
{
    public class MapScreenView : ViewBehaviour<MapScreenProperties, MapScreenPresenter>
    {

        private void Start()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            MapFactory mapFactory = new MapFactory();
            mapFactory.LevelPrefab = Prefab.MapLibrary.MapLevelPrefab;

            for (int i = 0; i < Prefab.MapLibrary.Maps.Count; i++)
            {
                mapFactory.Prefab = Prefab.MapLibrary.Maps[i].Prefab;
                mapFactory.Parent = Prefab.MapContainer;

                mapFactory.Create(Prefab.MapLibrary.Maps[i]);
            }
        }
    }
}
