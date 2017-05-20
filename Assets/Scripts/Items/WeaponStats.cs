namespace rpbp.IsoShooter {

    public class WeaponStats
    {

        #region Private Attributes
        private float mFireRate;
        private int mMaxAmmo;
        private float mReloadTime;
        private string mWeaponName;
        private float mDamage;

        #endregion

        //Firerate getter, setter
        public void setWeaponStatFireRate(float fireRate) {
            this.mFireRate = fireRate;
        }

        public float getWeaponStatFireRate() {
            return mFireRate;
        }

        //MaxAmmo setter, getter
        public void setWeaponStatMaxAmmo(int maxAmmo) {
            this.mMaxAmmo = maxAmmo;
        }

        public int getWeaponStatMaxAmmo() {

            return this.mMaxAmmo;
        }

        //reloadtime getter, setter
        public void setWeaponStatReloadTime(float reloadTime) {
            this.mReloadTime = reloadTime;
        }

        public float getWeaponReloadTime() {
            return this.mReloadTime;
        }


        //weaponname getter, setter
        public void setWeaponStatName(string name){
            this.mWeaponName = name;
        }

        public string getWeaponStatName() {
            return this.mWeaponName;
        }

        //damage getter, setter
        public void setWeaponStatDamage(float damage) {
            this.mDamage = damage;
        }

        public float getWeaponStatDamage() {
            return this.mDamage;
        }
        

    }

}