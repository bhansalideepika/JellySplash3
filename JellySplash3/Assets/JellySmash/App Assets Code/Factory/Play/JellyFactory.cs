using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Properties.Screen.Play;
using UnityEngine;

namespace JellySmash.Factory.Screen.Play
{
    public class JellyFactory : IFactory
    {
        public Transform Parent { get; set; }
        public GameObject Prefab { get; set; }

        public void Create<T>(T data)
        {
            Jelly jelly = data as Jelly;

            GameObject jellyObj = MonoBehaviour.Instantiate(Prefab, Parent);
            jellyObj.name = "Jelly";
            jellyObj.transform.localScale = Vector3.one;

            JellyProperties jellyProperties = jellyObj.GetComponent<JellyProperties>();
            if (jelly.ImageType == JellyImageType.COLOR)
            {
                jellyProperties.JellyImage.color = jelly.Color;
            }
            else
            {
                jellyProperties.JellyImage.sprite = jelly.Sprite;
            }

            jellyProperties.JellyName = jelly.Name.ToString();

            TileProperties tileProperties = Parent.GetComponent<TileProperties>();
            tileProperties.JellyProperties = jellyProperties;
            tileProperties.IsFilled = true;
        }
    }
}
