using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace MouseHandler
{
    /// <summary>
    /// Класс получает события от мыши пользователя и на основе их, рисует панель выделения и отправляет
    /// данные об этом, кто подписался на событие.
    /// </summary>
    public class ProcessingMouseActions : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField, Header("Действие вызывается во время удержания и движения панели выделения")]
        private UnityEvent<Vector3, Vector3> _onDragPanel;
        
        [SerializeField, Header("Действие вызывается при нажатие ПКМ")]
        private UnityEvent _onInputRightClickMouse;


        private Vector2 _downPosition;
        private Vector2 _dragPosition;
        private bool _highlighting;

        public void OnPointerDown(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Right:
                    _onInputRightClickMouse.Invoke();
                    return;
                case PointerEventData.InputButton.Left:
                    _downPosition = eventData.position;
                    break;
                case PointerEventData.InputButton.Middle:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            
            _highlighting = true;
            _dragPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            
            _highlighting = false;
            ResetPositions();
        }

        private void OnGUI()
        {
            if (_highlighting == false) return;
            _onDragPanel.Invoke(_downPosition, _dragPosition);
        }

        private void ResetPositions()
        {
            _downPosition = Vector2.zero;
            _dragPosition = Vector2.zero;
        }
    }
}