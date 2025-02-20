using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public SeamlessPortal yellowPortal;
    public SeamlessPortal purplePortal;
    public bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && isActive) 
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer != 10) return;

                if (Input.GetMouseButton(0))
                {
                    yellowPortal.transform.rotation = Quaternion.LookRotation(hit.normal);
                    yellowPortal.transform.position = hit.point + yellowPortal.transform.forward * 0.6f;
                }
                else
                {
                    purplePortal.transform.rotation = Quaternion.LookRotation(hit.normal);
                    purplePortal.transform.position = hit.point + purplePortal.transform.forward * 0.6f;
                }
            }
        }
    }
}
