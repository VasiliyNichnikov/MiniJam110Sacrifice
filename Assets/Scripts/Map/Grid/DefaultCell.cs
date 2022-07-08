using System;
using UnityEngine;

namespace Map.Grid
{
    /// <summary>
    /// Ячейка по умолчанию, хранит параметры и имеет возможность определять
    /// находится в этой ячейки объект или нет
    /// </summary>
    public class DefaultCell : ICell
    {
        public Vector2 Position { get; }
        public Vector2 Size { get; }
        public Vector2 Center { get; }

        private readonly Vector2 _leftUpPoint;
        private readonly Vector2 _rightUpPoint;

        private readonly Vector2 _leftDownPoint;
        private readonly Vector2 _rightDownPoint;

        public DefaultCell(Vector2 position, Vector2Int size)
        {
            Position = position;
            Size = size;

            Center = (Vector2)Size / 2 + position;
            
            _leftDownPoint = position;
            _rightDownPoint = new Vector2(position.x + size.x, position.y);
            
            _leftUpPoint =  new Vector2(position.x, position.y + size.y);
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
        
        private int Side(Vector2 a, Vector2 b, Vector2 p)
        {
            return Math.Sign((b.x - a.x) * (p.y - a.y) - (b.y - a.y) * (p.x - a.x));
        }
    }
}