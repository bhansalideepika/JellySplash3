using JellySmash.Factory;
using JellySmash.Factory.Data;
using JellySmash.Presenter;
using JellySmash.Properties;

namespace JellySmash.View
{
    public class PopupView : ViewBehaviour<PopupProperties, PopupPresenter>
    {
        private void Start()
        {
            Presenter.OnCreatePopup += CreatePopup;
        }

        private void CreatePopup(string popup)
        {
            if (popup.Trim().Length == 0)
            {
                return;
            }

            IFactory popupFactory = new PopupFactory();
            popupFactory.Parent = Prefab.ParentContainer;

            Popup data = Prefab.PopupLibrary.Popup.Find(x => x.Name == popup);
            popupFactory.Create(data);
        }
    }
}
