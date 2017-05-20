using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter {


    public class HandGun : Weapon
    {
        #region Public Attributes

        public float mFireRate;
        public int mMaxAmmo;
        public float mReloadTime;

        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            //Initiate stats for handgun
            var stats = new WeaponStats();
            stats.setWeaponStatFireRate(this.mFireRate);
            stats.setWeaponStatMaxAmmo(this.mMaxAmmo);
            stats.setWeaponStatReloadTime(this.mReloadTime);
            stats.setWeaponStatName(gameObject.name);
            this.SetWeaponStats(stats);

        }

        #endregion

    }

}
