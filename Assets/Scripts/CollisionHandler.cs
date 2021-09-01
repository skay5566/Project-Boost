using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  int currentSceneIndex;
  private void OnCollisionEnter(Collision other) 
    {
      switch (other.gameObject.tag)
        {
          case "Friendly":
              Debug.Log("This is friendly");
              break;
          case "Finish":
              StartSuccesSequence();
              break;
            case "Fuel":
              Debug.Log("Picked Fuel");
              break;
            default:
              StartCrashSequence();
              break;
        }
    }

    void StartSuccesSequence()
    {
      GetComponent<Movement>().enabled = false;
      Invoke("NextLevel", 1f);
    }

    void StartCrashSequence()
    {
      GetComponent<Movement>().enabled = false;
      Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex+1);
    }
}
