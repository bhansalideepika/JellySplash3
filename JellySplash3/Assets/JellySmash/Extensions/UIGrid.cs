using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using JellySmash.View.Screen.Play;
using JellySmash.Library.Screen.Play;
using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Factory;
using JellySmash.Factory.Screen.Play;

namespace JellySmash.Extensions
{
    public class UIGrid : MonoBehaviour
    {
        public float YOffsetForNewTile;
        public LevelsLibrary LevelsLibrary;

        private const float _time = 0.2f;

        private JellyLibrary _jellyLibrary;
        private List<TileView> _tiles;
        private Transform _parentContainer;
        private GridSize _size;
        private GameObject _lastJellyMovedDown;
        private int _levelNumber;
        private List<Jelly> _jellyData;

        public void Init(GridSize size, JellyLibrary library, int levelNumber, Transform parent)
        {
            _levelNumber = levelNumber;
            _jellyLibrary = library;
            _parentContainer = parent;
            _size = size;

            SetJellyData();
            SetTileElements();
            StartCoroutine(WaitAndGenerateJellies());
        }

        private void SetJellyData()
        {
            Level currentLevelData = LevelsLibrary.Levels[_levelNumber - 1];

            if (currentLevelData.IsAllJelliesAllowed)
            {
                _jellyData = _jellyLibrary.Jellies;
            }
            else
            {
                _jellyData = new List<Jelly>();
                for (int i = 0; i < currentLevelData.JellyAllowed.Length; i++)
                {
                    Jelly allowedJelly = _jellyLibrary.Jellies.Find(x => x.Name == currentLevelData.JellyAllowed[i]);
                    _jellyData.Add(allowedJelly);
                }
            }
        }

        private void SetTileElements()
        {
            _tiles = new List<TileView>();

            foreach (Transform item in _parentContainer)
            {
                _tiles.Add(item.GetComponent<TileView>());
            }
        }

        private IEnumerator WaitAndGenerateJellies()
        {
            yield return new WaitForEndOfFrame();
            GenerateJellies();
        }

        private void GenerateJellies()
        {
            IFactory jellyFactory = new JellyFactory();
            jellyFactory.Prefab = _jellyLibrary.Prefab;

            int jellyMaxRange = _jellyData.Count;

            _lastJellyMovedDown = null;

            for (int i = 0; i < _tiles.Count; i++)
            {
                if (_tiles[i].Prefab.IsFilled)
                {
                    continue;
                }

                int index = Random.Range(0, jellyMaxRange);
                Jelly selectedJelly = _jellyData[index];

                jellyFactory.Parent = _tiles[i].transform;
                jellyFactory.Create(selectedJelly);

                GameObject jellyObj = _tiles[i].Prefab.JellyProperties.gameObject;
                jellyObj.transform.position = GetNewTilePosition(i);

                jellyObj.transform.DOMoveY(_tiles[i].transform.position.y, _time).OnComplete(() => SetJellyPosition(jellyObj));
            }
        }

        private Vector3 GetNewTilePosition(int tileIndex)
        {
            int currentTileColumn = _tiles[tileIndex].Prefab.Column;
            Vector3 topTilePosition = _tiles[currentTileColumn].transform.position;
            topTilePosition.y += YOffsetForNewTile;

            return topTilePosition;
        }

        public void MoveJelliesDown()
        {
            for (int col = 0; col < _size.Column; col++)
            {
                var tilesInColumn = _tiles.FindAll(x => x.Prefab.Column == col);
                tilesInColumn.Reverse();

                var lowestEmptyTile = tilesInColumn.Find(x => x.Prefab.JellyProperties == null);

                if (lowestEmptyTile == null)
                {
                    continue;
                }

                for (int index = 0; index < tilesInColumn.Count; index++)
                {
                    var emptyTile = tilesInColumn[index];

                    if (emptyTile.Prefab.IsFilled)
                    {
                        continue;
                    }

                    //if tile is not filled then find the next filled tile above current tile
                    var filledTile = tilesInColumn.Find(x => x.Prefab.Row < emptyTile.Prefab.Row && x.Prefab.JellyProperties != null);
                    if (filledTile == null)
                    {
                        break;
                    }

                    GameObject jellyObj = filledTile.Prefab.JellyProperties.gameObject;

                    emptyTile.AddJelly(filledTile.Prefab.JellyProperties);
                    filledTile.RemoveJelly();

                    jellyObj.transform.DOMoveY(emptyTile.transform.position.y, _time).OnComplete(() => SetJellyPosition(jellyObj));
                    _lastJellyMovedDown = jellyObj;
                }
            }

            if (_lastJellyMovedDown == null) //no down movement was there as emptied tiles were from top rows only
            {
                GenerateJellies();
            }
        }

        private void SetJellyPosition(GameObject jellyObj)
        {
            jellyObj.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

            if (jellyObj == _lastJellyMovedDown)
            {
                _lastJellyMovedDown = null;
                GenerateJellies();
            }
        }
    }
}