using JellySmash.Model.Interface;
using UnityEngine;

namespace JellySmash.Model
{
    public class ApplicationModel : MonoBehaviour, IApplicationModel
    {
        public static ApplicationModel instance;

        private void Awake()
        {
            instance = this;
        }

        public T Get<T>()
        {
            return this.gameObject.GetComponent<T>();
        }
    }
}
