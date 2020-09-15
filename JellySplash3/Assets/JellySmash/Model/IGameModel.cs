using UnityEngine;

namespace JellySmash.Model.Interface
{
    public interface IGameModel : IApplicationModel
    {
        int CurrentLevel { get; set; }
    }
}
