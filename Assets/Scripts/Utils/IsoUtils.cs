using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class IsoUtils
    {
        private static readonly Vector3 _isoRight = new Vector3(1, 0, 1).normalized; 
        private static readonly Vector3 _isoUp = new Vector3(-1, 0, 1).normalized;   

        public static Vector3 ToIsoDirection(Vector2 input)
        {
            return _isoRight * input.x + _isoUp * input.y;
        }
    }
}