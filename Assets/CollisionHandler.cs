using UnityEngine;
using UnityEngine.SceneManagement;

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
              ReloadLevel();
              break;
        }
    }

    private void ReloadLevel()
    {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }
}
