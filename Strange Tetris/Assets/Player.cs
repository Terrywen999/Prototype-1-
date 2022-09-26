using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using TMPro;
public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    public float innerVision ;
    public float outsideVision ;
    public Light2D playerLight;
    public AudioSource backGroundMusic;


    public GameObject gameEnd;

    public Collectable collectable;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        innerVision = playerLight.pointLightInnerRadius;
        outsideVision = playerLight.pointLightOuterRadius;

        gameEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth >= 0)
        {
            TakeDamage(5);
          
            if(playerLight.pointLightInnerRadius >= 1)
            {
                losingInnerVision(1);
            }
            if (playerLight.pointLightOuterRadius >= 1)
            {
                losingOutsideVision(0.5f);
            }
            Debug.Log(collectable.gameObject.name);
            if (collectable.isCollected == true)
            {
                if (innerVision <= 10)
                {
                    innerVision += 2f;
                }
                if (outsideVision <= 10)
                {
                    outsideVision += 3f;
                }
               
                if(currentHealth < maxHealth)
                {
                    currentHealth += 15f;
                }
                    
                collectable.isCollected = false;
                return;
            }
        }
        else
        {
            GameObject.Find("Timer").SendMessage("Finish");
            gameEnd.SetActive(true) ;
       
           
        }

    }

    

    void TakeDamage(int damage)
    {
        currentHealth -= Time.deltaTime * damage;
        healthBar.SetHealth(currentHealth);
    }

    void losingInnerVision(float vision)
    {
        innerVision -= Time.deltaTime * vision;
        playerLight.pointLightInnerRadius = innerVision;
       
    }

    void losingOutsideVision(float vision)
    {
        outsideVision -= Time.deltaTime * vision;
        playerLight.pointLightOuterRadius = outsideVision;
    }
}
