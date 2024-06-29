using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable, IExplodable
{
    const float HEALTH_DAMAGE_RATIO_WHEN_HAS_SHIELD = 0.1f;
    const float SHIELD_DAMAGE_MULTIPLIER = 0.5f;

    PlayerVFX playerVFX;
    GameObject spaceStation;

    float refillDistance = 10f;
    float initialHealth;
    float initialShield;
    bool hasShield;
    bool canRefillable;

    [SerializeField] private float health;
    public float Health { get => health; set => health = value; }

    [SerializeField] private float shield;
    public float Shield { get => shield; set => shield = value; }

    void Start()
    {
        playerVFX = GetComponent<PlayerVFX>();
        spaceStation = GameObject.FindGameObjectWithTag("SpaceStation");
        hasShield = true;
        initialHealth = health;
        initialShield = shield;
    }

    void Update()
    {
        if (Mathf.Abs(spaceStation.transform.position.sqrMagnitude - transform.position.sqrMagnitude) < refillDistance * refillDistance)
        {
            canRefillable = true;
            StartCoroutine(RefillHealth());
            StartCoroutine(RefillShield());
        }
        else
        {
            canRefillable = false;
            StopCoroutine(RefillHealth());
            StopCoroutine(RefillShield());
        }
    }

    public void Die()
    {
        Explode();
        GetComponent<PlayerMovement>().StopMovement();
        Debug.Log("You Died!");
        GameObject.Destroy(this);
        SceneManager.LoadScene("DeathScene");
    }

    public void TakeDamage(float damageTaken)
    {
        if (hasShield)
            shield -= damageTaken * SHIELD_DAMAGE_MULTIPLIER;

        if (shield <= 0f)
        {
            hasShield = false;
            shield = 0;
        }

        health = hasShield ? health - (damageTaken * HEALTH_DAMAGE_RATIO_WHEN_HAS_SHIELD) : health - damageTaken;

        if (health <= 0f)
        {
            Die();
            health = 0;
        }

        UpdateHealthAndShieldBar();
    }

    IEnumerator RefillHealth()
    {
        for (float actualHealth = health; canRefillable && actualHealth <= initialHealth; actualHealth += 0.1f)
        {
            health = actualHealth;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        health = initialHealth;

        UpdateHealthAndShieldBar();

        //StartCoroutine(RefillHealth());
    }
    IEnumerator RefillShield()
    {
        for (float actualShield = shield; canRefillable && actualShield <= initialShield; actualShield += 0.01f)
        {
            shield = actualShield;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        shield = initialShield;

        UpdateHealthAndShieldBar();

        //StartCoroutine(RefillShield());
    }

    public void Explode()
    {
        if (playerVFX != null)
            playerVFX.PlayExplodeEffect();

        AudioManager.Instance.PlaySFX("Explode");
    }

    void UpdateHealthAndShieldBar()
    {
        GetComponent<PlayerUI>().healthBar.GetComponent<HealthBar>().UpdateHealth(health, initialHealth);
        GetComponent<PlayerUI>().shieldBar.GetComponent<ShieldBar>().UpdateShield(shield, initialShield);
    }
}
