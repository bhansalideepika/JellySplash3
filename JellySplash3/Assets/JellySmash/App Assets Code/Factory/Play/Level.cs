using System;

namespace JellySmash.Factory.Screen.Play.Data
{
    [Serializable]
    public class Level : IMarker
    {
        public string Name;
        public GridSize GridSize;
        public bool IsAllJelliesAllowed;
        public JellyName[] JellyAllowed;
        public int TargetScore;
    }
}
