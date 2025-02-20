using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessPortal : MonoBehaviour
{
    public SeamlessPortal Other;
    public Camera PortalView;

    private void Start()
    {
        Other.PortalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = Other.PortalView.targetTexture;
    }

    private void Update()
    {
        // pos
        Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
        PortalView.transform.localPosition = lookerPosition;

        // rotation 
        Quaternion diff = transform.rotation * Quaternion.Inverse(Other.transform.rotation * Quaternion.Euler(0, 180, 0));
        PortalView.transform.rotation = diff * Camera.main.transform.rotation;

        //Clipping
        PortalView.nearClipPlane = lookerPosition.magnitude;
    }
}
