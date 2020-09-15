using System;

namespace JellySmash.Presenter
{
    public class ScreenPresenterBehaviour : PresenterBehaviour
    {
        public static Action<string> OnCreateScreen;
        public static Action<string> OnCreatePopup;
        public static Action OnDestroyCurrentScreen;

        public void DestroyObject()
        {
            Destroy(this.gameObject);
        }

        public void DestroyCurrentScreen()
        {
            OnDestroyCurrentScreen();
        }
    }
}
