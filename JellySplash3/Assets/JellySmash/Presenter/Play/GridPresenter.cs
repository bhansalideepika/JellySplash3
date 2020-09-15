using UnityEngine;
using System;
using JellySmash.Model;
using JellySmash.Model.Interface;
using JellySmash.Properties.Screen.Play;

namespace JellySmash.Presenter.Screen.Play
{
    public class GridPresenter : PresenterBehaviour
    {
        public static Action<Vector3[]> OnDrawLine;
        public static Action OnResetLine;
        public static Action<int, int, int> OnRemoveJelly;
        public static Action<int> OnSetScore;

        public Action OnMoveJelliesDown;

        private bool _isSelectionOn;
        private int _turnScore;
        private int _jelliesRemoved;

        private IGridModel _gridModel;
        private GridModel GridModel
        {
            get
            {
                if (_gridModel == null)
                {
                    _gridModel = Get<IGridModel>();
                }

                return (GridModel)_gridModel;
            }
        }

        private IGameModel _gameModel;
        private GameModel GameModel
        {
            get
            {
                if (_gameModel == null)
                {
                    _gameModel = Get<IGameModel>();
                }

                return (GameModel)_gameModel;
            }
        }

        private void Awake()
        {
            TilePresenter.OnTileSelected += AddSelectedTile;
            TilePresenter.OnSelectionCompleted += RemoveAllSelectedTiles;
            TilePresenter.OnSelectionStarted += StartSelection;
            TilePresenter.OnTileAnimationEnd += UpdatePlayerScore;
        }

        private void OnDestroy()
        {
            TilePresenter.OnTileSelected -= AddSelectedTile;
            TilePresenter.OnSelectionCompleted -= RemoveAllSelectedTiles;
            TilePresenter.OnSelectionStarted -= StartSelection;
            TilePresenter.OnTileAnimationEnd -= UpdatePlayerScore;
        }

        private void StartSelection()
        {
            _isSelectionOn = true;
        }

        private void AddSelectedTile(TileProperties tileProperties)
        {
            if (!_isSelectionOn) return;

            GridModel.SaveData(tileProperties);
            bool isLineDrawable = GridModel.IsLineDrawable;

            if (isLineDrawable)
            {
                OnDrawLine(GridModel.SelectedTilesPos);
            }
        }

        private void RemoveAllSelectedTiles()
        {
            RemoveSelectedJellies();
            GridModel.ResetData();
            OnResetLine();
            _isSelectionOn = false;
        }

        private void RemoveSelectedJellies()
        {
            if (!GridModel.IsValidSelection)
            {
                return;
            }

            _turnScore = 0;
            _jelliesRemoved = GridModel.SelectedTiles.Count;

            for (int index = 0; index < GridModel.SelectedTiles.Count; index++)
            {
                var item = GridModel.SelectedTiles[index];
                var score = GetScore(index);

                _turnScore += score;

                OnRemoveJelly(item.Row, item.Column, score);
            }
        }

        private int GetScore(int index)
        {
            int jellyScoreGroup = index / 3;
            int score = GridModel.First3TilesScore + ((GridModel.AdditionalTilesScore) * jellyScoreGroup);
            return score;
        }

        private void UpdatePlayerScore()
        {
            _jelliesRemoved--;

            if (_jelliesRemoved == 0)
            {
                OnSetScore(_turnScore);
                OnMoveJelliesDown();
            }
        }
    }
}
