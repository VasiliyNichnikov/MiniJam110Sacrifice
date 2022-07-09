using System;
using UnityEngine;

namespace ClickObjects
{
    /// <summary>
    /// Класс проверяет попадения луча из камеры в выбранные маски и
    /// возвращает объект, в который было совершено попадение и точку столконения.
    /// </summary>
    public class ClickerOnObjects
    {
        private readonly Camera _camera;
        private readonly LayerMask _masksGround;


        public ClickerOnObjects(Camera camera, LayerMask masksGround)
        {
            _camera = camera;
            _masksGround = masksGround;
        }

        public (IClickObject hit, Vector3 position) GetInformationAboutClicking()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _masksGround))
            {
                var obj = hit.collider.GetComponent<IClickObject>();
                if (obj != null)
                    return (obj, hit.point);
            }
            throw new Exception("No hit detected"); // TODO отфильтровать ошибку
        }
    }
}