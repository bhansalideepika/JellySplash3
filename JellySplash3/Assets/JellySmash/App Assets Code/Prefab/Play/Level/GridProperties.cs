using JellySmash;
using JellySmash.Extensions;
using JellySmash.Library.Screen.Play;
using UnityEngine;
using UnityEngine.UI;

namespace JellySmash.Properties.Screen.Play
{
    public class GridProperties : PrefabBehaviour
    {
        public string Name;
        public GameObject TilePrefab;
        public FlexibleGridLayout GridLayout;
        public GridSize Size;
        public JellyLibrary JellyLibrary;
        public Transform ParentContainer;
        public UIGrid UIGrid;
    }
}