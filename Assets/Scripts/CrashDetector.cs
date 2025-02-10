using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDeley = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindFirstObjectByType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDeley);
            
        }


    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
