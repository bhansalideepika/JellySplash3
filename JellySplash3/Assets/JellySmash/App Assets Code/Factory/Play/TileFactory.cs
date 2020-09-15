using JellySmash.Properties.Screen.Play;
using UnityEngine;

namespace JellySmash.Factory.Screen.Play
{
    public class TileFactory : IFactory
    {
        public Transform Parent { get; set; }
        public GameObject Prefab { get; set; }

        public void Create<T>(T data)
        {
            ITile tile = data as ITile;

            GameObject tileObj = MonoBehaviour.Instantiate(Prefab, Parent);
            tileObj.name = "Tile" + tile.Row + tile.Column;
            tileObj.transform.localScale = Vector3.one;
            tileObj.transform.position = Vector3.zero;
            tileObj.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

            TileProperties properties = tileObj.GetComponent<TileProperties>();
            properties.Row = tile.Row;
            properties.Column = tile.Column;
        }
    }
}
