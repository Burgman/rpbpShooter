using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.BaseClasses {
    public class BaseCharacter : MonoBehaviour
    {

        #region Public Attributes 

        public GameObject mProjectile;
        public float mMaxHealth = 6;

        #endregion

        #region Private Attributes

        private float health;


        #endregion


        #region MonoBehaviour Callbacks


        private void Awake()
        {
            if (!mProjectile) {
                Debug.Log("<color=red>Missing prefabs in</color> Basechar.cs");

            }
        }

        // Use this for initialization
        void Start()
        {
            SetHealth(mMaxHealth);

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion


        #region Public Methods 

        public void SetHealth(float health)
        {
            this.health = health;
        }

        public float GetHealth()
        {
            return health;
        }

        //public void ReduceHealth(float damage)
        //{
        //    UpdateHealth(true, damage);
        //}

        #endregion

        #region Private Methods

        protected void Shoot()
        {

            Vector3 dir = transform.position - transform.GetChild(0).transform.position;
            dir.y = 0;

            Transform playerHand = transform.GetChild(0).transform;
            if (playerHand.childCount > 0) {


                Transform gun = playerHand.GetChild(0).transform;
                Transform projectileEmitter = gun.GetChild(0).transform;

                Debug.Log(projectileEmitter.gameObject.name);

                GameObject projectile = Instantiate(mProjectile,  projectileEmitter.position, Quaternion.LookRotation(dir));

                Debug.Log(projectile.name);

                var projectileRB = projectile.GetComponent<Rigidbody>();
                var projectileScript = projectile.GetComponent<Projectile.ProjectileBullet>();

                dir = dir.normalized;

                float projectileSpeed = projectileScript.getSpeed();

                projectileRB.AddForce(-projectileSpeed * dir, ForceMode.Impulse);

                Destroy(projectile, 2.0f);
            }
        }


        protected void UpdateHealth(float health)
        {
            this.health += health;
            if (this.health > mMaxHealth) {
                this.health = mMaxHealth;
                Debug.Log("health: " + health);
            }
        }


        #endregion


    }

}