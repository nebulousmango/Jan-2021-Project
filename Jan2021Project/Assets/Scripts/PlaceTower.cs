using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject tower;
    private GameManagerBehavior gameManager;

    private bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && gameManager.Stamina >= cost;
    }
    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            tower = (GameObject)
              Instantiate(towerPrefab, transform.position, Quaternion.identity);
            gameManager.Stamina -= tower.GetComponent<TowerData>().CurrentLevel.cost;

        }
        else if (CanUpgradeTower())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
            gameManager.Stamina -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
    }

    private bool CanUpgradeTower()
    {
        if (tower != null)
        {
            TowerData towerData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Stamina >= nextLevel.cost;
            }
        }
        return false;
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();

    }
}
