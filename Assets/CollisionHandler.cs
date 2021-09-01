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
              NextLevel();
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
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }

    private void NextLevel()
    {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex+1);
    }
}
