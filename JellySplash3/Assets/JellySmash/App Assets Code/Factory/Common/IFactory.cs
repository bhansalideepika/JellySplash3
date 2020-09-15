using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JellySmash.Factory
{
    public interface IFactory
    {
        Transform Parent { get; set; }
        GameObject Prefab { get; set; }

        void Create<T>(T data);
    }
}
