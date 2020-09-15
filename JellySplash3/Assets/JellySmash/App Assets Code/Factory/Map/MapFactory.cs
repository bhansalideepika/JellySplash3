using JellySmash.Properties.Screen.Map;
using UnityEngine;

namespace JellySmash.Factory.Screen.Map
{
    public class MapFactory : IFactory
    {
        public Transform Parent { get; set; }
        public GameObject Prefab { get; set; }
        public GameObject LevelPrefab { get; set; }

        public void Create<T>(T data)
        {
            Data.Map map = data as Data.Map;

            GameObject mapObj = MonoBehaviour.Instantiate(Prefab, Parent) as GameObject;
            mapObj.name = "Map" + map.Name;
            mapObj.transform.localScale = Vector3.one;
            mapObj.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
            mapObj.transform.SetAsFirstSibling();

            int levelNumber = map.MinLevel;
            foreach (Transform item in mapObj.transform)
            {
                CreateMapLevel(levelNumber, item);
                levelNumber++;
            }
        }

        private void CreateMapLevel(int levelNumber, Transform levelParent)
        {
            GameObject levelObj = MonoBehaviour.Instantiate(LevelPrefab, levelParent);
            levelObj.name = "MapLevel" + levelNumber.ToString();
            levelObj.transform.localScale = Vector3.one;
            levelObj.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

            MapLevelProperties levelProperties = levelObj.GetComponent<MapLevelProperties>();
            levelProperties.LevelNumber = levelNumber;
            levelProperties.LevelNameText.text = levelNumber.ToString();
        }
    }
}