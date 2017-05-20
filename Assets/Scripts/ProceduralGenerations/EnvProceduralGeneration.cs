using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rpbp.IsoShooter.Utils;

namespace rpbp.IsoShooter.ProceduraGeneration
{
    public class EnvProceduralGeneration : MonoBehaviour
    {
        #region Public Attributes

        public GameObject[] mObstacles;
        public int mLevel;

        #endregion

        #region Private Attributes
        private int obstaclesCounter;
        private int proceduralFactor;

        #endregion


        #region MonoBehaviour Callbacks

        private void Start()
        {
            obstaclesCounter = 0;
            proceduralFactor = 100;
        }

        #endregion


        #region Public Methods


        public int GetLevel()
        {
            return mLevel;
        }

        public void SetLevel(int level)
        {
            mLevel = level;
        }


        public void DoGeneration()
        {
            RemoveAllOldObstacles();

            Vector3 bounderSize = GetGroundSize();

            float xMax = bounderSize.x / 2;
            float zMax = bounderSize.z / 2;

            Vector3 randomPosition = new Vector3();

            proceduralFactor = 100;

            do
            {
                float x = Random.Range(-xMax, xMax);
                float z = Random.Range(-zMax, zMax);

                randomPosition.Set(x, 0, z);

                Instantiate(mObstacles[Random.Range(0, 2)], randomPosition, Quaternion.identity);

                obstaclesCounter++;
            }
            while (obstaclesCounter <= proceduralFactor);

        }

        #endregion



        #region Private Methods

        private Vector3 GetGroundSize()
        {
            GameObject ground = GameObject.FindGameObjectWithTag("Ground");
            var groundRenderer = ground.GetComponent<Renderer>();
            var bounderSize = groundRenderer.bounds.size;
            return bounderSize;
        }

        private void RemoveAllOldObstacles()
        {
            GameObject[] oldObstacles = GameObject.FindGameObjectsWithTag("EObstacle");
            if (oldObstacles.Length > 0)
            {
                foreach (GameObject oldObstacle in oldObstacles)
                {
                    Destroy(oldObstacle);
                }

                obstaclesCounter = 0;


            }
        }

        #endregion
    }
}
