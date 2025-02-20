using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunPickup : MonoBehaviour
{
    public GameObject PortalGunModel;
    public PortalGun PortalGunScript;
    public KeyCode KeyToPickup = KeyCode.F;

    private bool isKeyPressed = false;
    private void Update()
    {
        isKeyPressed = Input.GetKey(KeyToPickup);
        Debug.Log(isKeyPressed);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.CompareTag("Player"));
        if (other.gameObject.CompareTag("Player") && isKeyPressed)
        {
            gameObject.SetActive(false);
            PortalGunModel.SetActive(true);
            PortalGunScript.isActive = true;
        }
    }
}
