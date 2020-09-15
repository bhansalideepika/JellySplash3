using JellySmash.Factory.Data;
using UnityEngine;

namespace JellySmash.Factory
{
    public class PopupFactory : IFactory
    {
        public Transform Parent { get; set; }
        public GameObject Prefab { get; set; }

        public void Create<T>(T data)
        {
            Popup popup = data as Popup;
            Prefab = popup.Prefab;

            GameObject screenObj = MonoBehaviour.Instantiate(Prefab, Parent);
            screenObj.name = popup.Name;
            screenObj.transform.localScale = Vector3.one;
            screenObj.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
        }
    }
}
