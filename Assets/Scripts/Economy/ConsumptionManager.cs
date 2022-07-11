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

        [SerializeField, Header("Кол-во еды при старте"), Range(0, 100)]
        private int _mealDefault;

        [SerializeField, Header("Кол-во дерева при старте"), Range(0, 100)]
        private int _treeDefault;
        
        [SerializeField, Header("Полоса еды")] private MealSlider _meal;

        [SerializeField, Header("Полоса строительных материалов")]
        private ConstructionSlider _constructionSlider;
        
        private IncomeCalculation _incomeCalculation;
        
        
        private void Start()
        {
            _incomeCalculation = new IncomeCalculation(_buffer);
            // todo для спешки, исправить
            PlayerPrefs.SetInt("field", _mealDefault);
            PlayerPrefs.SetInt("tree", _treeDefault);
            
            _meal.ChangeValue(PlayerPrefs.GetInt("field"));
            _constructionSlider.ChangeValue(PlayerPrefs.GetInt("tree"));
        }

        private void OnEnable()
        {
            ResourceCreditingEvents.UpdateResource += UpdateCountSelectedResource;
            ResourceCreditingEvents.UpdateResourceFromVictim += UpdateResourcesFromVictim;
        }

        private void OnDisable()
        {
            ResourceCreditingEvents.UpdateResource -= UpdateCountSelectedResource;
            ResourceCreditingEvents.UpdateResourceFromVictim -= UpdateResourcesFromVictim;
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

        private void UpdateResourcesFromVictim(int income, IResource resource)
        {
            var currentValue = GetCountResource(resource);
            var slider = GetSlider(resource);
            var result = currentValue + income;
            if (result > 100)
                result = 100;
            ChangeCountToResource(resource, result);
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
            return PlayerPrefs.GetInt(resource.Name.ToLower());
        }

        private void ChangeCountToResource(IResource resource, int newValue)
        {
            PlayerPrefs.SetInt(resource.Name.ToLower(), newValue);
        }
    }
}