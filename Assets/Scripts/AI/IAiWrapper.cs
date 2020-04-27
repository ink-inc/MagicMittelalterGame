using UnityEngine;

namespace AI
{
    internal interface IAiWrapper
    {
        MapEntry MapEntry { get; }
        Vector3 Position { get; }
    }
}