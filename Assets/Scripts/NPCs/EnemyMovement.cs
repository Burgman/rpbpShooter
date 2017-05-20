using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace rpbp.IsoShooter.Enemy {

    public class EnemyMovement : rpbp.IsoShooter.BaseClasses.BaseCharacter
    {
        #region Public Attributes

        public float mSpeed;

        #endregion



        #region Private Attributes

        private Transform target;
        private Vector3 direction;
        private float maxDistance = 8;
        private NavMeshAgent nav;


        #endregion


        #region MonoBehaviour Callbacks

        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            nav = GetComponent<NavMeshAgent>();

        }
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            nav.SetDestination(target.position);
        }

        #endregion
    }

}