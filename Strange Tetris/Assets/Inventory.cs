using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            Collect(other.GetComponent<Collectable>());
        }
    }

    

    private void Collect(Collectable collectable)
    {
        if (collectable.Collect())
        {
            if(collectable is HeartCollectable)
            {
                gameObject.GetComponent<Player>().collectable = collectable;
                Debug.Log("Coffee collected"); 
            }
        }
    }
}
