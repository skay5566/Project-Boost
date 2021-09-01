using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  AudioSource audioSource;
  int currentSceneIndex;
  bool isTransitioning = false;
  [SerializeField] AudioClip  crashSound;
  [SerializeField] AudioClip  finishSound;

   void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }
  private void OnCollisionEnter(Collision other) 
    {
      if (isTransitioning) { return; }

      switch (other.gameObject.tag)
        {
          case "Finish":
              StartSuccesSequence();
              break;
            default:
              StartCrashSequence();
              break;
        }
    }

    void StartSuccesSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(finishSound);
      GetComponent<Movement>().enabled = false;
      Invoke("NextLevel", 1f);
    }

    void StartCrashSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(crashSound);
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
