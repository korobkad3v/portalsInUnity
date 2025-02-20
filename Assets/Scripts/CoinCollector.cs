using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private int _coins = 0;

    [SerializeField]
    private TextMeshProUGUI coinTMP;
    
    public int Coin { get { return _coins; } }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _coins += other.GetComponent<Coin>().coinDenomination;
            Destroy(other.gameObject);

            coinTMP.text = _coins.ToString();
        }
    }

    
}
