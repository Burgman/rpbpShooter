using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.CameraController {

    public class CameraFollows : MonoBehaviour
    {

        #region Public Attributes

        public Transform mTarget;
        public float mSmoothing = 5f;

        #endregion


        #region Private Attributes

        private Vector3 offset;

        #endregion



        #region MonoBehaviour Callbacks


        private void Start()
        {
            offset = transform.position - mTarget.position;
        }

        private void FixedUpdate()
        {
            Vector3 targetCamPos = mTarget.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, mSmoothing * Time.deltaTime);
        }

        #endregion

    }

}

