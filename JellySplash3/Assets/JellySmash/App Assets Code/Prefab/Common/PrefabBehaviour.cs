using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JellySmash;

namespace JellySmash.Properties
{
    public class PrefabBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            string propertiesName = this.GetType().ToString();
            string viewName = propertiesName.Replace("Properties", "View");
            string presenterName = propertiesName.Replace("Properties", "Presenter");

            this.gameObject.AddComponent(Type.GetType(viewName));
            this.gameObject.AddComponent(Type.GetType(presenterName));
        }

        private string GetInitialName(string scriptName)
        {
            int index = scriptName.IndexOf("Properties");
            string scriptInitials = scriptName.Substring(0, index - 1);
            return scriptInitials;
        }
    }
}