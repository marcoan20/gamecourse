using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;
    public GameObject[] windows;
    private CharStats[] playerStats;

    public Text playerName;
    public Text hp;
    public Text mp;
    public Slider expSlider;
    public Text exp;
    public Text playerLvl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            }
            else
            {
                UpdateStats();
                theMenu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    public void UpdateStats()
    {
        playerStats = GameManager.instance.playerStats;
        playerName.text = PlayerController.instance.playerNickName;
        hp.text = "HP: " + playerStats[0].currentHP + "/" +  playerStats[0].maxHP;
    }

    public void ToggleWindow(int windowNumber)
    {
        
    }
}
