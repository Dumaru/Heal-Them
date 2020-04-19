using TMPro;
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

    public int ammoLeft = 10;
    public int antidotesLeft = 10;
    public int score;

    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    public void UpdateAmmo(int amount)
    {
        Debug.Log("Update ammo");
        ammoLeft += amount;
        ammoLeft = ammoLeft <= 0 ? 0 : ammoLeft;
        textAmmo.text = ammoLeft.ToString();
    }
    public void UpdateAntidotes(int amount)
    {
        Debug.Log("Update antidotes");
        antidotesLeft += amount;
        antidotesLeft = antidotesLeft <= 0 ? 0 : antidotesLeft;
        textAntidotes.text = antidotesLeft.ToString();
    }
}
