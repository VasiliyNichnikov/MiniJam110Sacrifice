using Map.Grid.Errors;
using UnityEngine;

namespace Map.Grid
{
    public class CreatorDefaultGrid: ICreatorGrid
    {
        private readonly Vector2 _offsetGrid;
        
        public CreatorDefaultGrid(Vector2 offsetGrid)
        {
            _offsetGrid = offsetGrid;
        }
        
        public IGrid Create(Vector2Int sizeGrid, Vector2Int sizeCell)
        {
            return GetGrid(sizeGrid, sizeCell);
        }

        public IGrid Create(Vector2 sizeGrid, Vector2Int sizeCell)
        {
            var sizeGridInt = Vector2Int.RoundToInt(sizeGrid);
            return GetGrid(sizeGridInt, sizeCell);
        }

        private IGrid GetGrid(Vector2Int sizeGrid, Vector2Int sizeCell)
        {
            if(sizeGrid.x - sizeCell.x < 0 || sizeGrid.y - sizeCell.y < 0)
                throw new InvalidSizeValueGridError();
            
            var grid = new DefaultGrid(sizeGrid, sizeCell, _offsetGrid);
            return grid;
        }
    }
}