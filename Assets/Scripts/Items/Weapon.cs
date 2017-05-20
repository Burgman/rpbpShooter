using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rpbp.IsoShooter {
    public class Weapon : MonoBehaviour
    {
        private WeaponStats mStats;

        public void SetWeaponStats(WeaponStats stats) {
            mStats = stats;
            Debug.Log(mStats.getWeaponReloadTime());
        }

        public WeaponStats GetWeaponStats() {
            return this.mStats; 
        }
    }

}
