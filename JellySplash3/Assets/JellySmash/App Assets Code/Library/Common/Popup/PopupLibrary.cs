using JellySmash.Factory.Data;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Library
{
    [CreateAssetMenu(fileName = "PopupLibrary", menuName = "Scriptable Objects/Popup Library")]
    public class PopupLibrary : ScriptableObject
    {
        public List<Popup> Popup;
    }
}
