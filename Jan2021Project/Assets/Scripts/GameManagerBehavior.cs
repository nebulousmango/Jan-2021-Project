using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    public Text staminaLabel;
    private int stamina;
    public bool gameOver = false;
    public GameObject[] healthIndicator;
    public string S_SceneName;

    public int Stamina
    {
        get
        {
            return stamina;
        }
        set
        {
            stamina = value;
            staminaLabel.GetComponent<Text>().text = "Stamina: " + stamina;
        }
    }

    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
        }
    }

    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                SceneManager.LoadScene(S_SceneName);
            }
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }

    private void Start()
    {
        Stamina = 200;
        Wave = 0;
        Health = 12;
    }
}
