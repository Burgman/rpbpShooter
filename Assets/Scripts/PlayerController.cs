using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter
{
    public class PlayerController : rpbp.IsoShooter.BaseClasses.BaseCharacter
    {

        #region Public Attributes

        public float mSpeed = 6.0f;
        public float mFireRate;
        public float mReloadTime;
        public int mMaxAmmo;

        #endregion


        #region Private Attributes

        private Vector3 movement;
        private int floorMask;
        private float camRayLenght = 100.0f;
        private CharacterController mainCharController;
        private float nextFire;
        private int currentAmmo;
        private bool isLoading;
        private GameObject[] weapons;
        private int currentWeaponID;

        #endregion


        #region MonoBehaviour Callbacks

        private void Awake()
        {
            floorMask = LayerMask.GetMask("Floor");
            mainCharController = gameObject.GetComponent<CharacterController>();

        }

        // Use this for initialization
        void Start()
        {
            currentAmmo = mMaxAmmo;
            currentWeaponID = 0;
        }

        // Update is called once per frame
        void Update()
        {
            Turning();
        }

        private void FixedUpdate()
        {
            //Handle move
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Move(h, v);

            //Handle change weapon
            float d = Input.GetAxis("Mouse ScrollWheel");
            if (d > Constant.OFFSET_MOUSE_SCROLL_WHELL_POSITIVE)
            {
                ChangeWeapon(false);
            }

            if (d < Constant.OFFSET_MOUSE_SCROLL_WHELL_NEGATIVE)
            {
                ChangeWeapon(true);
            }

            //Handle shoot
            ProcessShooting();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Tag.TAG_WEAPON) {
                this.WeaponPickup(other.gameObject);

            }

        }


        #endregion



        #region Public Methods

        public int GetNumberOfWeaponsInBackBag() {

            return weapons.Length;
        }

        public void SetFireRate(float firerate) {
            this.mFireRate = firerate;

        }

        public void SetMaxAmmo(int maxAmmo) {
            this.mMaxAmmo = maxAmmo;
        }

        public void SetReloadTime(float reloadTime) {
            this.mReloadTime = reloadTime;
        }

        #endregion


        #region Private Methods

        private void WeaponPickup(GameObject weapon) {

            Debug.Log("Weapon picked up");
            Transform playerTransform = this.gameObject.transform;
            Transform playerHandTransform = playerTransform.GetChild(0).transform;
            Vector3 playerDirection = playerHandTransform.position - playerTransform.position;
            playerDirection.y = 0;
            weapon.transform.parent = playerHandTransform;
            weapon.transform.position = playerHandTransform.position;
            weapon.transform.rotation = Quaternion.LookRotation(playerDirection);

            this.SetWeapon(weapon.GetComponent<WeaponStats>());
        }

        public void SetWeapon(WeaponStats m)
        {

            this.SetFireRate(m.getWeaponStatFireRate());
            this.SetMaxAmmo(m.getWeaponStatMaxAmmo());
            this.SetReloadTime(m.getWeaponReloadTime());
            this.ReloadAmmo();

            //Initialize weapon
            SetCurrentAmmoToMax();

        }

        private void ProcessShooting()
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > nextFire && currentAmmo > 0)
                {
                    Shoot();
                    nextFire = Time.time + mFireRate;
                    currentAmmo--;

                    Debug.Log(currentAmmo);
                }
                else if (currentAmmo <= 0)
                {
                    StartCoroutine(ReloadAmmo());

                }


            }
        }

        IEnumerator ReloadAmmo() {

            yield return new WaitForSeconds(mReloadTime);
            SetCurrentAmmoToMax();

        }

        /// <summary>
        /// Scroll to change weapon
        /// </summary>
        /// <param name="isNegative"></param>
        private void ChangeWeapon(bool isNegative) {

            Debug.Log("Change weapon");

        }

        private void SetCurrentAmmoToMax() {
            currentAmmo = mMaxAmmo;
        }

        private void Move(float h, float v)
        {
            movement.Set(h, 0f, v);
            movement = movement.normalized * mSpeed * Time.deltaTime;
            movement.y = 0;
            mainCharController.Move(movement);

        }

        private void Turning()
        {
            Vector3 playerToMouse;
            playerToMouse = GetPlayerToMouseDirection();
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = newRotation;
        }

        private Vector3 GetPlayerToMouseDirection()
        {
            Vector3 playerToMouse = Vector3.zero;
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(transform.position, camRay.direction, Color.red);

            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
            {
                playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0;
            }


            return playerToMouse;
        }

        #endregion
    }
}