using System;
using Economy.Resource;
using ManagementOfSettlers.UnitSelection.Buffer;
using SettlementObjects.Builders;
using SettlementObjects.Resource;
using UI.Resource;
using UnityEngine;

namespace Economy
{
    public class ConsumptionManager: MonoBehaviour
    {
        [SerializeField, Header("Буфер всех объектов на сцене")]
        private BufferOfSelectedObjects _buffer;

        [SerializeField, Header("Полоса еды")] private MealSlider _meal;

        [SerializeField, Header("Полоса строительных материалов")]
        private ConstructionSlider _constructionSlider;
        
        private IncomeCalculation _incomeCalculation;
        
        
        private void Start()
        {
            _incomeCalculation = new IncomeCalculation(_buffer);
        }

        private void OnEnable()
        {
            ResourceCreditingEvents.UpdateResource += UpdateCountSelectedResource;
        }

        private void OnDisable()
        {
            ResourceCreditingEvents.UpdateResource -= UpdateCountSelectedResource;
        }

        private void UpdateCountSelectedResource(int extracted, IResource resource)
        {
            var income = _incomeCalculation.GetIncome(extracted, resource);
            var currentValue = GetCountResource(resource);
            var slider = GetSlider(resource);
            var result = 0;

            if (income < 0)
            {
                var absIncome = Mathf.Abs(income);
                if (currentValue - absIncome <= 0)
                {
                    ChangeCountToResource(resource, result);
                    Debug.Log("Начинается голод/Нехватка ресурса");
                }
                else
                {
                    result = currentValue - absIncome;
                    ChangeCountToResource(resource, result);
                }
            }
            else
            {
                result = currentValue + income;
                if (result > 100) // todo вынести в настройки 
                    result = 100;
                ChangeCountToResource(resource, result);
            }
            slider.ChangeValue(result);
        }

        private ResourceSliderChanger GetSlider(IResource resource)
        {
            switch (resource)
            {
                case IConstruction _:
                    return _constructionSlider;
                case IMeal _:
                    return _meal;
                default:
                    throw new Exception("Слайдер не найден");
            }
        }
        
        private int GetCountResource(IResource resource)
        {
            return PlayerPrefs.GetInt(resource.Name);
        }

        private void ChangeCountToResource(IResource resource, int newValue)
        {
            PlayerPrefs.SetInt(resource.Name, newValue);
        }
    }
}