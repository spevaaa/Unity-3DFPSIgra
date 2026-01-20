using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                            
    public int currentHealth;                                   
    public Slider healthSlider;
    public GameObject gameOverPanel;                      


    bool isDead;

    void Start()
    {
        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
    }


    void Awake()
    {
        gameOverPanel.SetActive(false);

        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
        
    }


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
