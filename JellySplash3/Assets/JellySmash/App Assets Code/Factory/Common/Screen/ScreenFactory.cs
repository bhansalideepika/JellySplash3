using UnityEngine;

namespace JellySmash.Factory
{
    public class ScreenFactory : IFactory
    {
        public Transform Parent { get; set; }
        public GameObject Prefab { get; set; }

        public void Create<T>(T data)
        {
            Data.Screen screen = data as Data.Screen;
            Prefab = screen.Prefab;

            GameObject screenObj = MonoBehaviour.Instantiate(Prefab, Parent);
            screenObj.name = screen.Name;
            screenObj.transform.localScale = Vector3.one;
            screenObj.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
        }
    }
}
