
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public float xAngle, yAngle, zAngle;
    [SerializeField]
    public int coinDenomination = 1;
    [SerializeField]
    private void Start()
    {
        gameObject.tag = "Coin";
    }

    private void Update()
    {
        this.gameObject.transform.Rotate(xAngle, yAngle, zAngle);
    }
}
