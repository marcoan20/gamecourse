using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameM;
    // Start is called before the first frame update
    void Start()
    {
        if(UIFade.instance == null)
        {
           UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }

        
        if(PlayerController.instance == null)
        {
           PlayerController.instance = Instantiate(player).GetComponent<PlayerController>();
        }

        if(GameManager.instance == null)
        {
           GameManager.instance = Instantiate(gameM).GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
