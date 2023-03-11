using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba") == true)
        {
            enemies.SetActive(false);
        }
    }
}
