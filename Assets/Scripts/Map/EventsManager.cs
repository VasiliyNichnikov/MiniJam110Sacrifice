using System;
using UnityEngine;

namespace Map
{
    public static class EventsManager
    {
        public static Func<Vector2, Vector2, bool> CheckingBuildingsInCells;
    }
}