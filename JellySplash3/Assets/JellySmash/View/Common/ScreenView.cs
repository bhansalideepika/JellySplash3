using JellySmash.Factory;
using JellySmash.Presenter;
using JellySmash.Properties;

namespace JellySmash.View
{
    public class ScreenView : ViewBehaviour<ScreenProperties, ScreenPresenter>
    {
        private void Start()
        {
            Presenter.OnCreateScreen += CreateScreen;
        }

        private void CreateScreen(string screen)
        {
            if (screen.Trim().Length == 0)
            {
                screen = Prefab.ScreenLibrary.DefaultScreen;
            }

            IFactory screenFactory = new ScreenFactory();
            screenFactory.Parent = Prefab.ParentContainer;

            Factory.Data.Screen data = Prefab.ScreenLibrary.Screens.Find(x => x.Name == screen);
            screenFactory.Create(data);
        }
    }
}
