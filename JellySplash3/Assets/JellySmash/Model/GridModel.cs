using JellySmash.Model.Interface;
using JellySmash.Properties.Screen.Play;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Model
{
    public class GridModel : MonoBehaviour, IGridModel
    {
        [SerializeField]
        private int _first3TilesScore;

        [SerializeField]
        private int _additionalTilesScore;

        public int First3TilesScore
        {
            get
            {
                return _first3TilesScore;
            }
        }

        public int AdditionalTilesScore
        {
            get
            {
                return _additionalTilesScore;
            }
        }

        public Vector3[] SelectedTilesPos
        {
            get
            {
                Vector3[] positions = new Vector3[_selectedTiles.Count];
                for (int i = 0; i < _selectedTiles.Count; i++)
                {
                    positions[i] = _selectedTiles[i].transform.position;
                }

                return positions;
            }
        }

        public List<TileProperties> SelectedTiles
        {
            get
            {
                return _selectedTiles;
            }
        }

        public bool IsValidSelection
        {
            get
            {
                return _selectedTiles.Count >= 3;
            }
        }

        public bool IsLineDrawable { get; private set; }

        [SerializeField]
        private List<TileProperties> _selectedTiles;

        private SwipeDirection[] _directions;

        private void Awake()
        {
            _directions = (SwipeDirection[])Enum.GetValues(typeof(SwipeDirection));
        }

        public void SaveData(TileProperties tileProperty)
        {
            if (IsValidData(tileProperty))
            {
                if (_selectedTiles == null)
                {
                    _selectedTiles = new List<TileProperties>();
                }

                _selectedTiles.Add(tileProperty);

                IsLineDrawable = (_selectedTiles.Count > 1);   
            }
        }

        private bool IsValidData(TileProperties tileProperty)
        {
            bool noJelliesSelected = (_selectedTiles == null || _selectedTiles.Count == 0);
            IsLineDrawable = false;

            if (noJelliesSelected)
            {
                return true;
            }

            bool jellyAlreadyAdded = _selectedTiles.Contains(tileProperty);
            bool jellySameAsOthersInList = (_selectedTiles[0].JellyProperties.JellyName == tileProperty.JellyProperties.JellyName);
            bool isAdjacentJelly = CheckIsAdjacentJelly(tileProperty);

            if (jellyAlreadyAdded && isAdjacentJelly)
            {
                RemoveLastTile();
                IsLineDrawable = true;
                return false;
            }

            return (jellySameAsOthersInList && isAdjacentJelly);
        }

        private bool CheckIsAdjacentJelly(TileProperties tileProperty)
        {
            foreach (SwipeDirection direction in _directions)
            {
                if (IsCorrectDirection(direction, tileProperty))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCorrectDirection(SwipeDirection direction, TileProperties tileProperty)
        {
            bool isValid = false;

            TileProperties lastTile = _selectedTiles[_selectedTiles.Count - 1];

            int row = lastTile.Row;
            int column = lastTile.Column;

            switch (direction)
            {
                case SwipeDirection.NORTH:
                    row--;
                    break;
                case SwipeDirection.SOUTH:
                    row++;
                    break;
                case SwipeDirection.EAST:
                    column++;
                    break;
                case SwipeDirection.WEST:
                    column--;
                    break;
                case SwipeDirection.NORTH_EAST:
                    row--;
                    column++;
                    break;
                case SwipeDirection.NORTH_WEST:
                    row--;
                    column--;
                    break;
                case SwipeDirection.SOUTH_EAST:
                    row++;
                    column++;
                    break;
                case SwipeDirection.SOUTH_WEST:
                    row++;
                    column--;
                    break;
            }

            isValid = (tileProperty.Row == row && tileProperty.Column == column);

            return isValid;
        }

        private void RemoveLastTile()
        {
            int lastTileIndex = _selectedTiles.Count - 1;
            _selectedTiles.Remove(_selectedTiles[lastTileIndex]);
        }

        public void ResetData()
        {
            _selectedTiles = null;
        }
    }
}