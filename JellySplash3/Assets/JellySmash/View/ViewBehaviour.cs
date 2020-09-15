using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.View
{
    public class ViewBehaviour<TProperties, TPresenter> : MonoBehaviour
    {
        private TProperties prefab;
        private TPresenter presenter;

        public TProperties Prefab
        {
            get
            {
                if (prefab == null)
                {
                    prefab = this.GetComponent<TProperties>();
                }

                return prefab;
            }
        }

        public TPresenter Presenter
        {
            get
            {
                if (presenter == null)
                {
                    presenter = this.GetComponent<TPresenter>();
                }

                return presenter;
            }
        }
    }
}