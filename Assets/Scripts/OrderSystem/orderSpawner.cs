using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderSpawner : MonoBehaviour
{
    inventory inventory;
    public GameObject order;
    GameObject order1;
    GameObject order2;
    GameObject order3;
    Vector3 vector1 = new Vector3(600,430,0);
    Vector3 vector2 = new Vector3(800,430,0);
    Vector3 vector3 = new Vector3(1000,430,0); 
    Transform pannelTransform;
    void Start(){
        inventory = FindObjectOfType<inventory>();
        GameObject pannel = GameObject.Find("orderPannel");
        pannelTransform = pannel.GetComponent<Transform>();
        new1();
        new2();
        new3();
    }
    public void new1(){
        order1 = Instantiate(order,pannelTransform);
        order1.transform.position = vector1;
        order1.transform.localScale = new Vector3(1f,1f,0);
    }
    public void new2(){
        order2 = Instantiate(order,pannelTransform);
        order2.transform.position = vector2;
        order2.transform.localScale = new Vector3(1f,1f,0);
    }
    public void new3(){
        order3 = Instantiate(order,pannelTransform);
        order3.transform.position = vector3;
        order3.transform.localScale = new Vector3(1f,1f,0);
    }

    public void bin(){
        inventory.empty();
    }
    public void check1(){
        order temp = order1.GetComponent<order>();
        if (inventory.check(temp.gems,temp.cherrys)){
            Destroy(order1);
            new1() ;
            bin();
        }
   }
   public void check2(){
       order temp = order2.GetComponent<order>();
       if (inventory.check(temp.gems,temp.cherrys)){
            Destroy(order2);
            new2() ;
            bin();
        }   
    }
   public void check3(){
       order temp = order3.GetComponent<order>();
       if (inventory.check(temp.gems,temp.cherrys)){
            Destroy(order3);
            new3() ;
            bin();
        }   
    }


    
    // Update is called once per frame
    void Update()
    {
    
    }
}
