using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
 
    public ColorToPrefab[] colorMapping;
    public Texture2D[] bitMapList;
    Texture2D currentMap;
    GameObject MeteorSpawnPoint;
    public GameObject Meteor;
    Vector3 abovePos = new Vector3(0, 10, 0);
    private int[] levelArray = { 1, 2, 3, 4, 5 };
    public int currentLevel;

    IEnumerator Start()
    {
        // loop through what the current game level is
        for (int r = 0; r < levelArray.Length; r++)
        {
            currentLevel = levelArray[r];
            GameManagerScript.instance.levelText.SetText("Level: " + currentLevel);
            //loop through each bitmap/texture in the bitmaplist
            for (int i = 0; i < bitMapList.Length; i++)
            {
                currentMap = bitMapList[i];
                GenerateLevel();
                Debug.Log("this is the current wave" + currentMap);
                yield return new WaitForSeconds(10f);

                

               
            }
        }
    }
    void SpawnMeteors()
    {
        
        Instantiate(Meteor, MeteorSpawnPoint.transform.position + abovePos, MeteorSpawnPoint.transform.rotation);
        Rigidbody wb = Meteor.GetComponent<Rigidbody>();
      
        wb.AddForce(Vector3.down, ForceMode.Impulse);




    }

    void GenerateLevel()
    {
            for (int x = 0; x < currentMap.width; x++)
            {
                for (int y = 0; y < currentMap.height; y++)
                {
                    GenerateTile(x, y);
                }
            }
    }

    void GenerateTile(int x, int y)
        {
            Color pixelColor = currentMap.GetPixel(x, y);

            if (pixelColor.a == 0)
            {

                return;
            }

        foreach(ColorToPrefab colorMapping in colorMapping)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, .3f, y);
                MeteorSpawnPoint = ObjectPooler.Instance.SpawnMeteor("Spawner");
                MeteorSpawnPoint.transform.position = position;
                MeteorSpawnPoint.SetActive(true);
                SpawnMeteors();

            }
        }
        }


}