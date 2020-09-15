using JellySmash.Model.Interface;
using UnityEngine;

namespace JellySmash.Model
{
    public class ScreenModel : MonoBehaviour, IScreenModel
    {
        public string CurrentScreen { get; set; }
    }
}
