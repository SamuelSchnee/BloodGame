using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float armor;
    public float invulnerable;
    
    public GameObject parent;

    public UnityEvent OnDeath;
    public UnityEvent OnDamaged;

    public HealthBar healthBar;
    public GameObject storymaster;
    public StoryController story;

    public string enemyType;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if(healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        storymaster = GameObject.FindGameObjectWithTag("Story");
        story = storymaster.GetComponent<StoryController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= (damage - armor);
        if(healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        OnDamaged.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
            if(parent != null)
            {
                Destroy(parent.gameObject);
            }
            if(enemyType != null)
            {
                story.ProgressStory(enemyType);
            }
            Destroy(this.gameObject);
            
            
        }
    }
}
