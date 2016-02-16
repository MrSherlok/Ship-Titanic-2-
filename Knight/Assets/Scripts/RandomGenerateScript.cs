using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGenerateScript : MonoBehaviour
{

    public BoxCollider2D pointColl;
    public BoxCollider2D wallColl;
    private Vector3 _currentPosition;
    public bool isTriggerComplete = false;
    private int _randomNumber = 0;
    List<GameObject> SceneList = new List<GameObject>();
    public int lastRandomNumber = 0;
    //private Vector3 positionOfWall; 
    //public int maxRandomNumber = 4; 

        public List<GameObject> enemyArray = new List<GameObject>();
    private int i = 0;

    public GameObject enemyObj;
    private int length = 40;
    private int genLenghth = 0;
    private int quantity;


    void Awake()
    {

        pointColl = GameObject.Find("GeneratePoint").GetComponent<BoxCollider2D>();
        SceneList.Add(GameObject.Find("EarthMap1"));
        SceneList.Add(GameObject.Find("EarthMap2"));
        SceneList.Add(GameObject.Find("EarthMap3"));
        SceneList.Add(GameObject.Find("EarthMap4"));
        SceneList.Add(GameObject.Find("EarthMap5"));

    }

    void OnTriggerExit2D(Collider2D pointCollIn)
    {
        if (pointCollIn == pointColl)
        {
            isTriggerComplete = true;
        }

        if (isTriggerComplete)
        {
            while (_randomNumber == lastRandomNumber)
            {
                _randomNumber = Random.Range(0, SceneList.Count);
            }
            _currentPosition = pointColl.transform.position;
            lastRandomNumber = _randomNumber;

            quantity = Random.Range(1, 3);


            if (SceneList[_randomNumber] != null)
            {
                // positionOfWall = new Vector3(_currentPosition.x + 38.2f, _currentPosition.y, _currentPosition.z); 
                SceneList[_randomNumber].transform.position = new Vector3(_currentPosition.x + 38.2f, _currentPosition.y, _currentPosition.z);
                transform.position = new Vector3(_currentPosition.x + 40f, _currentPosition.y, _currentPosition.z);
                while (length >= genLenghth)
                {
                    genLenghth += Random.Range(20, 30);
                    enemyArray[i].transform.position = new Vector3(_currentPosition.x + genLenghth, _currentPosition.y - 5, _currentPosition.z-6);
                    enemyArray[i].GetComponent<Animator>().SetBool("Die", false);
                    enemyArray[i].GetComponent<Animator>().SetBool("Run",true);
                    enemyArray[i].GetComponent<HealthScript>().hp = 1;
                    enemyArray[i].GetComponent<Collider2D>().enabled = true;
                    enemyArray[i].GetComponent<MoveScript>().speed.x = 3;
                    i++;
                    Debug.Log("tp was");
                    if (i >= 4) {
                        i = 0;
                    }
                }
                length = 40;
                genLenghth = 0;


                Debug.Log(_randomNumber);

            }
            isTriggerComplete = false;
        }
    }
}