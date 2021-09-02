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
  [SerializeField] ParticleSystem finishParticles;
  [SerializeField] ParticleSystem crashParticles;

   void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
  private void OnCollisionEnter(Collision other) 
    {
      if (isTransitioning) { return; }

      switch (other.gameObject.tag)
        {
          case "Friendly":
              break;
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
      finishParticles.Play();
      GetComponent<Movement>().enabled = false;
      Invoke("NextLevel", 1f);
    }

    void StartCrashSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(crashSound);
      crashParticles.Play();
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
