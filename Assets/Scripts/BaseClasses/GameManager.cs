using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpbp.IsoShooter.GameManager
{
    public class GameManager : MonoBehaviour
    {


        #region MonoBehaviour Callbacks

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }

}