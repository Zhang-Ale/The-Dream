using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject RszObj;
    public Transform _place1;
    public Transform _place2;
    [Header("SpawnRszObj")]
    public SpawnRszObj _spawnRszObj0;
    public SpawnRszObj _spawnRszObj1;
    public SpawnRszObj _spawnRszObj2;
    public SpawnRszObj _spawnRszObj3;
    public SpawnRszObj _spawnRszObj4;
    public SpawnRszObj _spawnRszObj5;
    public SpawnRszObj _spawnRszObj6;
    public SpawnRszObj _spawnRszObj7;
    public SpawnRszObj _spawnRszObj8;
    [Header("Doors")]
    public GameObject door0;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    [Header("Levels")]
    public GameObject level0;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == level0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Gun1.SetActive(true);
                Gun2.SetActive(false);
                GameObject Block = GameObject.Find("RszObj 1(Clone)");
                Destroy(Block.gameObject);
                _spawnRszObj0.isCreated = false;
                door0.SetActive(true);
                Destroy(level0.gameObject);       
            }
        }
        if (other.gameObject == level1)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject Block = GameObject.Find("RszObj 1");
                Destroy(Block.gameObject);
                Instantiate(RszObj, new Vector3(148, 2, -22), Quaternion.identity);
                door1.SetActive(true);
                Destroy(level1.gameObject);
            }
        }
        if (other.gameObject == level2)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject Block = GameObject.Find("RszObj 1(Clone)");
                Destroy(Block.gameObject);
                _spawnRszObj1.isCreated = false;
                door2.SetActive(true);
                Destroy(level2.gameObject);
            }
        }
        if (other.gameObject == level3)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject Block = GameObject.Find("RszObj 1 (1)");
                Destroy(Block.gameObject);
                Instantiate(RszObj, _place1.transform.position, Quaternion.identity);
                Destroy(level3.gameObject);
            }
        }
        if (other.gameObject == level4)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _spawnRszObj2.isCreated = false;
                GameObject Block = GameObject.Find("RszObj 1(Clone)");
                Destroy(Block.gameObject);
                door3.SetActive(true);
                Destroy(level4.gameObject);
            }
        }
        if (other.gameObject == level5)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(level5.gameObject);
                _spawnRszObj3.isCreated = false;
                _spawnRszObj4.isCreated = false;
                _spawnRszObj5.isCreated = false;
                _spawnRszObj6.isCreated = false;
                _spawnRszObj7.isCreated = false;
                GameObject[] Block = GameObject.FindGameObjectsWithTag("Grabbable");
                Debug.Log("Found");
                for(int i = 8; i > 0; i++)
                {
                    Destroy(Block[i].gameObject);
                }
                door4.SetActive(true);
            }
        }
        if (other.gameObject == level6)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _spawnRszObj8.isCreated = false;
                GameObject Block = GameObject.Find("RszObj 1(Clone)");
                Destroy(Block.gameObject);
                Destroy(level6.gameObject);
            }
        }
        if (other.gameObject == level7)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject Block = GameObject.Find("right");
                Destroy(Block.gameObject);
                Instantiate(RszObj, _place2.transform.position, Quaternion.identity);
                door5.SetActive(true);
                Destroy(level7.gameObject);
            }
        }
    }
}
