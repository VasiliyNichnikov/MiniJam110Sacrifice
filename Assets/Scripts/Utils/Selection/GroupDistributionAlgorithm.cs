using System.Collections.Generic;
using UnityEngine;

namespace Utils.Selection
{
    public static class GroupDistributionAlgorithm
    {
        public static List<Vector3> GetPositionListAround(Vector3 newCenter, float[] ringDistanceArray,
            int[] ringPositionCountArray)
        {
            var positionList = new List<Vector3> { newCenter };
            for (var i = 0; i < ringDistanceArray.Length; i++)
            {
                positionList.AddRange(GetPositionListAround(newCenter, ringDistanceArray[i],
                    ringPositionCountArray[i]));
            }

            return positionList;
        }

        private static IEnumerable<Vector3> GetPositionListAround(Vector3 newCenter, float distance, int positionCount)
        {
            var positionList = new List<Vector3>();
            for (int i = 0; i < positionCount; i++)
            {
                float angle = i * (360f / positionCount);
                var direction = ApplyRotationToVector(new Vector3(1, 0, 0), angle);
                var position = newCenter + direction * distance;
                positionList.Add(position);
            }

            return positionList;
        }

        private static Vector3 ApplyRotationToVector(Vector3 vector, float angle)
        {
            return Quaternion.Euler(0, angle, 0) * vector;
        }
    }
}