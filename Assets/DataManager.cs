using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using TMPro;
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int score = 0;
    public int xp = 0;
    public int xpMax = 50;
    public int level = 1;

    [SerializeField]
    private UnityEngine.UI.Image experienceBar;
    private Player player;

    [SerializeField]
    private List<WeaponStats> weaponsTemplate = new List<WeaponStats>();
    
    private List<WeaponStats> weapons = new List<WeaponStats>();

    [SerializeField] GameObject cardPrefab;
    private List<GameObject> cards = new List<GameObject>();
    public event Action<int> OnLevelUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (WeaponStats weapon in weaponsTemplate)
        {
            WeaponStats newWeapon = Instantiate(weapon);
            weapons.Add(newWeapon);
        }

        if (instance != null)
        {
            Debug.LogError("More than one DataManager in the scene");
            return;
        }
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        initializePlayer();
    }

    void initializePlayer()
    {
        foreach (WeaponStats weapon in weapons)
        {
            GameObject instance = Instantiate(weapon.weaponPrefab, player.transform.position, Quaternion.identity);
            
            WeaponBehaviour weaponBehaviour = instance.GetComponent<WeaponBehaviour>();
            weaponBehaviour.weaponStats = weapon;
            weaponBehaviour.enemyDetector = player.GetComponentInChildren<EnemyDetector>();
            instance.transform.SetParent(player.transform);

        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            updateXp(100);
        }
    }

    // Update is called once per frame
    public void updateXp(int amount)
    {
        xp += amount;
        if (xp >= xpMax)
        {
            level++;
            xp -= xpMax;
            xpMax = 50 + level * 10;
            OnLevelUp?.Invoke(level);
            List<WeaponStats> randomWeapons = getRandomWeapons(3);
            Debug.Log("Level up! New level: " + level);
            Debug.Log("Random weapons: " + randomWeapons.Count);
            handle_weapon_upgrades(randomWeapons);
            
        }
        float xp_ratio = (float)xp / xpMax;
        experienceBar.fillAmount = xp_ratio;
    }

    public List<WeaponStats> getUpgradableWeapons()
    {
        List<WeaponStats> upgradableWeapons = new List<WeaponStats>();
        foreach (WeaponStats weapon in weapons) {
            if (weapon.getUpgrade() != null)
            {
                upgradableWeapons.Add(weapon);
            }
        }
        return upgradableWeapons;
    }

    public List<WeaponStats> getRandomWeapons(int amount)
    {
        List<WeaponStats> upgradableWeapons = getUpgradableWeapons();
        Debug.Log("Upgradable weapons: " + upgradableWeapons.Count);
        List<WeaponStats> randomWeapons = new List<WeaponStats>();

        for (int i = 0; i < amount; i++)
        {
            if (upgradableWeapons.Count == 0) {
                break;
            }
            int randomIndex = UnityEngine.Random.Range(0, upgradableWeapons.Count);
            randomWeapons.Add(upgradableWeapons[randomIndex]);
            upgradableWeapons.RemoveAt(randomIndex);
        }
        return randomWeapons;
    }

    public void handle_weapon_upgrades(List<WeaponStats> weapons)
    {
        Transform lvlUpSystem = transform.Find("LvlUpSystem");
        foreach (GameObject card in cards)
        {
            Destroy(card.gameObject);
        }
        cards.Clear();
        foreach (WeaponStats weapon in weapons)
        {
            GameObject card = Instantiate(cardPrefab, lvlUpSystem);
            CardBehaviour cardBehaviour = card.GetComponent<CardBehaviour>();
            Button button = card.transform.Find("ChooseButton").GetComponent<Button>();
            TMP_Text description = card.transform.Find("Description").GetComponent<TMP_Text>();

            description.text = weapon.weaponName + " Level " + weapon.level + "\n" + weapon.getUpgrade().upgradeName + ": " + weapon.getUpgrade().upgradeValue;
            if (button == null) {
                Debug.LogError("Button not found");
            }
            card.transform.SetParent(lvlUpSystem);
            
            cardBehaviour.setWeaponStats(weapon);
            cards.Add(card);
            button.onClick.AddListener(() => {
                weapon.levelUp();
                closeWeaponUpgrade();
            });
                
        }
        if (cards.Count == 0)
        {
            return;
        }
        Time.timeScale = 0;
        lvlUpSystem.gameObject.SetActive(true);
    }

    public void closeWeaponUpgrade()
    {
        Transform lvlUpSystem = transform.Find("LvlUpSystem");
        Time.timeScale = 1;
        lvlUpSystem.gameObject.SetActive(false);
        foreach (GameObject card in cards)
        {
            Destroy(card.gameObject);
        }
        cards.Clear();
    }
}
