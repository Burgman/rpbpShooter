using rpbp.IsoShooter.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.Projectile {

    public class ProjectileBullet : MonoBehaviour
    {

        #region Public Attributes

        public float mSpeed = 20.0f;
        public float mDamage = 1.0f;

        #endregion

        #region private Attributes

        private Vector3 direction;
        private Rigidbody projectileRB;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            projectileRB = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            //TODO: check tag
            //if (other.gameObject.tag == "StormTrooper")
            //{
            //    var script = other.gameObject.GetComponent<BaseClasses.BaseCharacter>();
            //    script.ReduceHealth(mDamage);
            //} else if(other.gameObject.tag == "EObstacle"){
            //    var script = other.gameObject.GetComponent<BaseObject>();
            //    script.UpdateHealth(mDamage);
            //}

            //Destroy bullet after it hit object
            Destroy(this.gameObject);
        }

        #endregion


        #region Public Mehods

        public float getSpeed() {
            return mSpeed;
        }

        public void setDirection(Vector3 dir)
        {
            this.direction = dir;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
