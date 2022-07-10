using System;
using Economy.Resource;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Resource
{
    [RequireComponent(typeof(Slider))]
    public abstract class ResourceSliderChanger : MonoBehaviour
    {
        private Slider _slider;

        private void OnEnable()
        {
            EventsManager.AdditionResource += AddResource;
            EventsManager.SubtractionResource += SubtractResource;
        }

        private void OnDisable()
        {
            EventsManager.AdditionResource -= AddResource;
            EventsManager.SubtractionResource -= SubtractResource;
        }

        protected virtual void AddResource(int value, IResource resource)
        {
            var currentValue = _slider.value;
            if (currentValue + value > _slider.maxValue)
            {
                currentValue = _slider.maxValue;
            }
            else
            {
                currentValue = _slider.value + value;
            }

            _slider.value = currentValue;
        }

        protected virtual void SubtractResource(int value, IResource resource)
        {
            var currentValue = _slider.value;
            if (currentValue - value < 0)
            {
                throw new Exception("Передано не верное значение. Кол-во продуктов не может быть < 0"); // todo Добавить фильтр 
            }
            currentValue = _slider.value - value;  
            _slider.value = currentValue;
        }
        
        private void Start()
        {
            _slider = GetComponent<Slider>();
            SettingsSlider();
        }

        private void SettingsSlider()
        {
            _slider.minValue = 0;
            _slider.maxValue = 100;
            _slider.value = 0;
        }
    }
}