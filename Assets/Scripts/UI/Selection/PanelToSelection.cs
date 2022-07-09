using UnityEngine;

namespace UI.Selection
{
    public class PanelToSelection : MonoBehaviour
    {
        [SerializeField, Header("Цвет тексутры выделения")] private Color _colorTexture;
        private Texture2D _texture;

        private void Start()
        {
            ToCreateTexture(_colorTexture);
        }

        public void DrawRectangle(Vector3 start, Vector3 end)
        {
            var rect = GetScreenRect(start, end);
            GUI.DrawTexture(rect, _texture);
        }

        private void ToCreateTexture(Color color)
        {
            _texture = new Texture2D(1, 1);
            _texture.SetPixel(0, 0, color);
            _texture.Apply();
        }

        private Rect GetScreenRect(Vector2 start, Vector2 end)
        {
            start.y = Screen.height - start.y;
            end.y = Screen.height - end.y;
            var topLeft = Vector3.Min(start, end);
            var bottomRight = Vector3.Max(start, end);
            return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
        }
        
    }
}