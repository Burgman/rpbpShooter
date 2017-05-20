using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    public float mRegenAmount;


    // Use this for initialization
    #region MonoBehaviour Callbacks
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.SendMessage("UpdateHealth", GetRegenAmount());

            Destroy(this.gameObject);
        }
    }
    #endregion

    #region Public Methods

    public float GetRegenAmount() {
        return mRegenAmount;
    }

    #endregion
}
