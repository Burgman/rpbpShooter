using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.BaseClasses{

    public class Generator : MonoBehaviour
    {

        #region Pubic Attributes

        //TODO: change to private
        public int mMaxEmenies;
        public int mLevel;

        #endregion

        #region Private Attributes

        private int currentEnemies;

        #endregion



        #region MonoBehaviour Callbacks


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion


        #region Public Methods 

        public int GetMaxEnemies()
        {
            return this.mMaxEmenies;
        }

        public int GetLevel()
        {
            return mLevel;
        }

        public int GetCurrentEnemies()
        {
            return currentEnemies;
        }

        public int GetRemainingEnemies()
        {
            return mMaxEmenies - currentEnemies;
        }

        #endregion

        #region Private Methods 

        private void IncreaseLevel() { }

        #endregion
    }


}