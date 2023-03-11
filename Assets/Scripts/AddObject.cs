using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Goomba") == true) {
        obj.SetActive(true);
    }
}
}