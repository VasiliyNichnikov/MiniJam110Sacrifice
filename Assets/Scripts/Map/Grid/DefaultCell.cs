﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map.Grid
{
    /// <summary>
    /// Ячейка по умолчанию, хранит параметры и имеет возможность определять
    /// находится в этой ячейки объект или нет
    /// </summary>
    public class DefaultCell : ICell
    {
        public Vector2Int Position { get; }
        public Vector2Int Size { get; }
        public Vector2 Center { get; }
        public Color TestColor { get; }

        private readonly Vector2Int _leftUpPoint;
        private readonly Vector2Int _rightUpPoint;

        private readonly Vector2Int _leftDownPoint;
        private readonly Vector2Int _rightDownPoint;

        public DefaultCell(Vector2Int position, Vector2Int size)
        {
            var r = Random.Range(0f, 1f);
            TestColor = new Color(r,r, r);
            
            Position = position;
            Size = size;

            Center = (Vector2)Size / 2 + position;
            
            _leftDownPoint = position;
            _rightDownPoint = new Vector2Int(position.x + size.x, position.y);
            
            _leftUpPoint =  new Vector2Int(position.x, position.y + size.y);
            _rightUpPoint = position + size;
        }

        public bool IsEnter(Vector2 position)
        {
            return GetInArea(position);
        }
        
        public bool IsEnter(Vector3 position)
        {
            var position2 = new Vector2(position.x, position.z);
            return GetInArea(position2);
        }

        private bool GetInArea(Vector2 position)
        {
            var inArea = Side(_leftUpPoint, _rightUpPoint, position) == -1 &&
                         Side(_rightUpPoint, _rightDownPoint, position) == -1 &&
                         Side(_rightDownPoint, _leftDownPoint, position) == -1 &&
                         Side(_leftDownPoint, _leftUpPoint, position) == -1;
            return inArea;
        }
        
        private int Side(Vector2Int a, Vector2Int b, Vector2 p)
        {
            return Math.Sign((b.x - a.x) * (p.y - a.y) - (b.y - a.y) * (p.x - a.x));
        }
    }
}