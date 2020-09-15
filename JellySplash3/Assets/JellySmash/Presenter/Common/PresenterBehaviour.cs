using JellySmash.Model;
using UnityEngine;

namespace JellySmash.Presenter
{
    public abstract class PresenterBehaviour : MonoBehaviour
    {
        public T Get<T>()
        {
            return ApplicationModel.instance.Get<T>();
        }
    }
}
