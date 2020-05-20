using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoShow : MonoBehaviour
{
    public GameObject enemyShipPrefab;
    public int enemyShipIncremement = 10;
    int leftBound = -50;
    int rightBound = 50;
    int topBound = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("space"))
            AddShips(enemyShipIncremement);
    }

    void AddShips(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float xVal = Random.Range(leftBound, rightBound);
            float zVal = Random.Range(0f, 10f);

            Vector3 pos = new Vector3(xVal, 0f, zVal + topBound);
            Quaternion rot = Quaternion.Euler(0f, 180f, 0f);

            var obj = Instantiate(enemyShipPrefab, pos, rot) as GameObject;
        }
    }
}
