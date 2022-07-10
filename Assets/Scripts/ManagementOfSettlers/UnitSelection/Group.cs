using System;
using System.Collections.Generic;
using Units;
using UnityEngine;
using Utils.Selection;

namespace ManagementOfSettlers.UnitSelection
{
    public class Group
    {
        // public Vector3 Center => _center;
        // public ClickerOnGround Clicker => _clicker;
        //
        // private readonly IBuffer _buffer;
        // private readonly ClickerOnGround _clicker;
        // private Vector3 _center = Vector3.zero;
        //
        // public Group(IBuffer buffer, ClickerOnGround clicker)
        // {
        //     if (buffer.SelectedObjects.Length == 0)
        //         throw new Exception("The buffer cannot be empty");
        //     
        //     _clicker = clicker;
        //     _buffer = buffer;
        // }
        //
        // public Vector3 CalculateCenter()
        // {
        //     Vector3 center = Vector3.zero;
        //     foreach (var obj in _buffer.SelectedObjects)
        //     {
        //         var position = obj.ThisTransform.position;
        //         center.x += position.x;
        //         center.z += position.z;
        //     }
        //
        //     int lengthBuffer = _buffer.SelectedObjects.Length;
        //     center.x /= lengthBuffer;
        //     center.z /= lengthBuffer;
        //     _center = center;
        //     return center;
        // }
        //
        // public void ScreenTaps()
        // {
        //     if (Input.GetMouseButtonDown(1))
        //     {
        //         var clicking = _clicker.GetInformationAboutClicking();
        //         List<Vector3> targetPositionList = GroupDistributionAlgorithm.GetPositionListAround(clicking.position,
        //             new[] {1f, 2.5f, 4f},
        //             new[] {5, 20, 40});
        //         var targetPositionListIndex = 0;
        //         foreach (var obj in _buffer.SelectedObjects)
        //         {
        //             // todo исправить
        //             if (obj.TypeObject == TypesOfObjects.Unit) // нужно по другому выбирать units
        //             {
        //                 // var unit = obj as Unit;
        //                 // if (unit == null) throw new Exception("Unit must not be null");
        //                 // var newPosition = (clicking.hit, targetPositionList[targetPositionListIndex]);
        //                 // unit.SetClick(newPosition);
        //                 // targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
        //             }
        //         }
        //     }
        // }
    }
}