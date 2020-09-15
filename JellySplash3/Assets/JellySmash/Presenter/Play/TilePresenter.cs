using JellySmash.Properties.Screen.Play;
using System;
using UnityEngine;

namespace JellySmash.Presenter.Screen.Play
{
    public class TilePresenter : PresenterBehaviour
    {
        public static Action<TileProperties> OnTileSelected;
        public static Action OnSelectionCompleted;
        public static Action OnSelectionStarted;
        public static Action OnTileAnimationEnd;
        public Action<int, int, int> OnRemoveJelly;

        private void Awake()
        {
            GridPresenter.OnRemoveJelly += RemoveJelly;
        }

        private void OnDestroy()
        {
            GridPresenter.OnRemoveJelly -= RemoveJelly;
        }

        private void RemoveJelly(int row, int column, int score)
        {
            OnRemoveJelly(row, column, score);
        }

        public void MouseDown()
        {
            OnSelectionStarted();
        }

        public void MouseEnter(TileProperties properties)
        {
            OnTileSelected(properties);
        }

        public void MouseUp()
        {
            OnSelectionCompleted();
        }

        public void TileAnimationEnd()
        {
            OnTileAnimationEnd();
        }
    }
}