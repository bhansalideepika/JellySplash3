using UnityEngine;

namespace JellySmash.Model.Interface
{
    public interface IScreenModel : IApplicationModel
    {
        string CurrentScreen { get; set; }
    }
}
