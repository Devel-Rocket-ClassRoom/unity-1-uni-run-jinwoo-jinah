using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coinCount = 0;
    public float energy = 100f;

    public bool isGameOver;

    public TextMeshProUGUI coinCountText;
    public Slider energySlider;

    public GameObject GameOverUI;

    void Start()
    {
        GameOverUI.SetActive(false);            
        isGameOver = false;
    }

    void Update()
    {
        if (energy <= 0 || isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("CookieRun");

            GameOverUI.SetActive(true);

            energy = 0;
            isGameOver = true;
            energySlider.value = energy;
            return;
        }

        energy -= Time.deltaTime;
        energySlider.value = energy;
    }

    public void GetCoin()
    {
        coinCount++;
        energy++;
        if (energy >= 100) energy = 100;

        coinCountText.text = $"Coin: {coinCount}";
        energySlider.value = energy;
    }

    public void HitObstacle()
    {
        energy -= 10;

        energySlider.value = energy;
    }
}
