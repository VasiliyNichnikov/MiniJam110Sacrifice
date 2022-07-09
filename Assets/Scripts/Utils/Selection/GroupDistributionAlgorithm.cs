using System.Collections.Generic;
using UnityEngine;

namespace Utils.Selection
{
    public static class GroupDistributionAlgorithm
    {
        public static List<Vector3> GetPositionListAround(Vector3 newCenter, float[] ringDistanceArray,
            int[] ringPositionCountArray)
        {
            List<Vector3> positionList = new List<Vector3>();
            positionList.Add(newCenter);
            for (int i = 0; i < ringDistanceArray.Length; i++)
            {
                positionList.AddRange(GetPositionListAround(newCenter, ringDistanceArray[i],
                    ringPositionCountArray[i]));
            }

            return positionList;
        }

        private static List<Vector3> GetPositionListAround(Vector3 newCenter, float distance, int positionCount)
        {
            List<Vector3> positionList = new List<Vector3>();
            for (int i = 0; i < positionCount; i++)
            {
                float angle = i * (360f / positionCount);
                Vector3 direction = ApplyRotationToVector(new Vector3(1, 0, 0), angle);
                Vector3 position = newCenter + direction * distance;
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