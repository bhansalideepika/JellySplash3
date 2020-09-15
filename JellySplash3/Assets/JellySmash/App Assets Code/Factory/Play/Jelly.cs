using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Factory.Screen.Play.Data
{
    [System.Serializable]
    public class Jelly : IMarker
    {
        public JellyName Name;
        public Color Color;
        public Sprite Sprite;
        public JellyImageType ImageType;
        public JellyType JellyType;
    }

    [System.Serializable]
    public enum JellyImageType { COLOR, SPRITE };

    [System.Serializable]
    public enum JellyName { RED, GREEN, BLUE, YELLOW, PINK };

    [System.Serializable]
    public enum JellyType { NORMAL };
}