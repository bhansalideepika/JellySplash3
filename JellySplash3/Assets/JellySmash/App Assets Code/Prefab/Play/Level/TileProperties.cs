using UnityEngine.UI;

namespace JellySmash.Properties.Screen.Play
{
    public class TileProperties : PrefabBehaviour
    {
        public int Row;
        public int Column;
        public bool IsFilled;
        public Text ScoreText;
        public JellyProperties JellyProperties;
    }
}
