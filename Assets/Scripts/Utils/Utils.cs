using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.Utils
{
    public static class Utils
    {
        public static void SetCorrectPosition(GameObject o, Vector3 position)
        {
            var objectRenderer = o.GetComponent<Renderer>();
            Vector3 objectSize = objectRenderer.bounds.size;

            float objectX = objectSize.x;
            float objectZ = objectSize.z;

            position.x += objectX / 2;
            position.z += objectZ / 2;




        }

    }

}