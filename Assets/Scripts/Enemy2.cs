using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
   public Vector2 pos1;
     public Vector2 pos2;
     public float speed;
     private float oldPosition = 0.0f;
     private SpriteRenderer sprite;
 
     
     void Start()
     {
         oldPosition = transform.position.x;
         sprite = GetComponent<SpriteRenderer>();
     }
 
     void Update()
     {
         transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
 
         if (transform.position.x > oldPosition) // he's looking right
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
             sprite.flipX = false;
         }
 
         if (transform.position.x < oldPosition) // he's looking left
         {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
             sprite.flipX = true;
         }
         oldPosition = transform.position.x; // update the variable with the new position so we can chack against it next frame
     }
}
