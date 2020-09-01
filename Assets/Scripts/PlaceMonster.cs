using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{

    public GameObject monsterPrefab;
    private GameObject monster;
    private GameManagerBehavior gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
    private bool CanUpgradeMonster()
    {
        if(monster != null)
        { 
            MonsterData monData = monster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monData.GetNextLevel();
            if(nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }
         

        }
        return false;
    }
    private bool CanPlaceMonster()
    {
        int cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
        return monster == null && gameManager.Gold >= cost;
    }


    private void OnMouseUp()
    {
        if(CanPlaceMonster())
        {

            
            monster = (GameObject)Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            AudioSource aSource = gameObject.GetComponent<AudioSource>();
            aSource.PlayOneShot(aSource.clip);
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;


        }
        else if(CanUpgradeMonster())
        {
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
            monster.GetComponent<MonsterData>().IncreaseLevel();
            AudioSource aSource = gameObject.GetComponent<AudioSource>();
            aSource.PlayOneShot(aSource.clip);
        }
        
    }
   
}
