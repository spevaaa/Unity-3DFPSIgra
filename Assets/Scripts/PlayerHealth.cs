using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                            
    public int currentHealth;                                   
    public Slider healthSlider;
    public TMP_Text gameOverText;                           


    bool isDead;

    void Start()
    {
        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
    }


    void Awake()
    {
        gameOverText.enabled = false;

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

        gameOverText.enabled = true;

        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
