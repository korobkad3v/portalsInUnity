using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTooltipHandler : MonoBehaviour
{
    public Tooltip tooltip;
    public ItemCollector itemCollector;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Item"))
        {
            Vector3 objectPosition = other.gameObject.transform.position;
            tooltip.ShowTooltip($"Press {itemCollector.KeyToPickup.ToString()} to interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            tooltip.HideTooltip();
        }
    }
}
