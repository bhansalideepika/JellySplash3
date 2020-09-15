using JellySmash.Factory;
using JellySmash.Factory.Screen.Play;
using JellySmash.Factory.Screen.Play.Data;
using JellySmash.Presenter.Screen.Play;
using JellySmash.Properties.Screen.Play;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.View.Screen.Play
{
    public class GridView : ViewBehaviour<GridProperties, GridPresenter>
    {
        private List<ITile> _tiles;

        private void Start()
        {
            Presenter.OnMoveJelliesDown += MoveJelliesDown;

            SetGridLayout();
            SetTileDetails();
            CreateTiles();
            InitGridUI();
        }

        private void OnDestroy()
        {
            Presenter.OnMoveJelliesDown -= MoveJelliesDown;
        }

        private void CreateTiles()
        {
            IFactory tileFactory = new TileFactory();
            tileFactory.Parent = Prefab.ParentContainer;
            tileFactory.Prefab = Prefab.TilePrefab;

            foreach (ITile tile in _tiles)
            {
                tileFactory.Create(tile);
            }
        }

        private void SetGridLayout()
        {
            Prefab.GridLayout.Init(Prefab.Size.Row, Prefab.Size.Column);
        }

        private void SetTileDetails()
        {
            _tiles = new List<ITile>();
            for (int i = 0; i < Prefab.Size.Row; i++)
            {
                for (int j = 0; j < Prefab.Size.Column; j++)
                {
                    ITile tile = new Tile(i, j);
                    _tiles.Add(tile);
                }
            }
        }

        private void InitGridUI()
        {
            int levelNumber = int.Parse(Prefab.Name);
            Prefab.UIGrid.Init(Prefab.Size, Prefab.JellyLibrary, levelNumber, Prefab.ParentContainer);
        }

        private void MoveJelliesDown()
        {
            Prefab.UIGrid.MoveJelliesDown();
        }
    }
}
