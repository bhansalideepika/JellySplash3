using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Properties.Screen.Play;
using UnityEngine;

namespace JellySmash.Factory.Screen.Play
{
    public class LevelFactory : IFactory
    {
        public Transform Parent { get; set; }
        public GameObject Prefab { get; set; }

        public void Create<T>(T data)
        {
            Level level = data as Level;

            GameObject gridObj = MonoBehaviour.Instantiate(Prefab, Parent);
            gridObj.transform.localScale = Vector3.one;
            gridObj.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

            GridProperties gridProperties = gridObj.GetComponent<GridProperties>();
            gridProperties.Name = level.Name;
            gridProperties.Size = level.GridSize;
        }
    }
}
