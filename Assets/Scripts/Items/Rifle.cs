using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter {


    public class Rifle : Weapon
    {

        #region Public Attributes

        public float mFireRate;
        public int mMaxAmmo;
        public float mReloadTime;

        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            //Initiate stats for rilfe
            this.mStat = new WeaponStats();

            mStat.setWeaponStatFireRate(this.mFireRate);
            mStat.setWeaponStatMaxAmmo(this.mMaxAmmo);
            mStat.setWeaponStatReloadTime(this.mReloadTime);
            mStat.setWeaponStatName(gameObject.name);

        }

        #endregion
    }


}