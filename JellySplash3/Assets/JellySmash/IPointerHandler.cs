using UnityEngine.EventSystems;

namespace JellySmash
{
    public interface IPointerHandler : IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
    {
    }
}
