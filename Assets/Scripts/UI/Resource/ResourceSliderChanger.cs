using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Resource
{
    [RequireComponent(typeof(Slider))]
    public abstract class ResourceSliderChanger : MonoBehaviour
    {
        private Slider _slider;
        
        public void ChangeValue(int newValue)
        {
            if (newValue < 0 || newValue > 100)
                throw new Exception("Передано не верное значение"); // todo добавить фильтр
            
            _slider.value = newValue;
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