﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private TextMeshProUGUI textAmmo;
    [SerializeField]
    private TextMeshProUGUI textAntidotes;
    [SerializeField]
    private TextMeshProUGUI textScore;

    public int ammoLeft = 100;
    public int antidotesLeft = 20;
    [SerializeField]
    private int score = 0;

    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for game over
    }

    public void UpdateHealth(int health)
    {
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Game Over");
        }
        healthSlider.value = health;
    }
    // public void UpdateAmmo(int amount)
    // {
    //     Debug.Log("Update ammo");
    //     ammoLeft += amount;
    //     ammoLeft = ammoLeft <= 0 ? 0 : ammoLeft;
    //     textAmmo.text = ammoLeft.ToString();
    // }

    public void UpdateScore(int amount)
    {
        score += amount;
        Debug.Log("Update score " + score);
        textScore.text = "Score: " + score.ToString();
    }

    // public void UpdateAntidotes(int amount)
    // {
    //     Debug.Log("Update antidotes");
    //     antidotesLeft += amount;
    //     antidotesLeft = antidotesLeft <= 0 ? 0 : antidotesLeft;
    //     textAntidotes.text = antidotesLeft.ToString();
    // }
}
