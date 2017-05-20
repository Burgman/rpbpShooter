using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.BaseClasses {
    public class BaseObject : MonoBehaviour
    {

        #region Public Attributes


        public float mMaxHealth = 7.0f;

        //For develope only
        //TODO: Change to protected
        public float mExplosionDamage;
        public bool isExplosivable;
        public float mRadius;

        #endregion


        #region Protected Attributes 



        #endregion

        #region Private Attributes

        private float currentHealth;

        #endregion


        #region MonoBehaviour Callbacks

        private void Start()
        {
            currentHealth = mMaxHealth;

        }


        #endregion



        #region Public Methods 

        public void SetCurrentHealth(float health)
        {
            this.currentHealth = health;
        }

        public float GetCurrentHealth()
        {
            return this.currentHealth;
        }

        public void UpdateHealth(float damage)
        {

            this.currentHealth -= damage;

            if (this.currentHealth <= 0)
            {

                if (this.isExplosivable)
                {
                    DoExplosion();
                }
                else
                {
                    Destroy(this.gameObject);
                }


            }


        }

        #endregion


        #region Private Methods

        private void DoExplosion()
        {

            Vector3 explosionPos = this.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, mRadius, LayerMask.GetMask("Envi"));
            if(colliders.Length > 0) StartCoroutine("Explosion", colliders);

        }

        IEnumerator  Explosion(Collider[] colliders)
        {
            foreach(Collider collider in colliders)
            {
                Debug.Log(collider.tag);
            }

            Destroy(this.gameObject);

            yield return 0;
        }

        #endregion
    }


}