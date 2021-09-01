using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
              Debug.Log("This is friendly");
              break;
            case "Finish":
              Debug.Log("Congrats finish");
              break;
            case "Fuel":
              Debug.Log("Picked Fuel");
              break;
            default:
              Debug.Log("Sorry you blew up!");
              break;
        }
    }
}
