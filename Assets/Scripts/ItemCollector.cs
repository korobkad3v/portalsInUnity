using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    public GameObject itemModel;
    public GameObject itemPlayerModel;
    public KeyCode KeyToPickup;
    public string itemTag;
    public Tooltip tooltip;

    void OnTriggerStay(Collider other)
    {
       
        if (Input.GetKeyDown(KeyToPickup) && other.gameObject.CompareTag(itemTag)) 
        {

            itemModel.SetActive(false);
            itemPlayerModel.SetActive(true);

            if (gameObject.TryGetComponent<PortalGun>(out PortalGun portalGun))
            {
                portalGun.isActive = true;
            }
            tooltip.HideTooltip();
        }
    }
}
