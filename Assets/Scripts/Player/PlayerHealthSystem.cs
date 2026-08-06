using System;
using UnityEngine;

public class PlayerHealthSystem : Health
{
    [SerializeField] private int maxLifes;
    [SerializeField] private GameObject[] allHearts;

    private void OnEnable()
    {
        OnKilled += ReduceLife;
    }

    private void OnDisable()
    {
        OnKilled -= ReduceLife;
    }

    private void Start()
    {
        maxHealth = PlayerPrefs.GetInt("MaxHealth", maxHealth);
        PlayerPrefs.SetInt("MaxHealth", maxHealth);

        _currentHealth = maxHealth;

        maxLifes = PlayerPrefs.GetInt("MaxLifes", maxLifes);
        PlayerPrefs.SetInt("MaxLifes", maxLifes);

        foreach (GameObject heart in allHearts)
            heart.SetActive(false);

        for (int i = 0; i < maxLifes; i++)
            allHearts[i].SetActive(true);
    }

    private void ReduceLife()
    {
        maxLifes--;
        allHearts[maxLifes].SetActive(false);
        PlayerPrefs.SetInt("MaxLifes", maxLifes);
    }
    
    public void IncreaseLife()
    {
        maxLifes++;
        allHearts[maxLifes - 1].SetActive(true);
        PlayerPrefs.SetInt("MaxLifes", maxLifes);
    }
}