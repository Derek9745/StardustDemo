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

    
    enum LevelNum  {LEVEL_1, LEVEL_2, LEVEL_3, LEVEL_4, LEVEL_5 }


    IEnumerator Start()
    {
   
        for (int i = 0; i < bitMapList.Length; i++)
        {
            currentMap = bitMapList[i];
            GenerateLevel();
            Debug.Log("this is the current wave" + currentMap);
            yield return new WaitForSeconds(10f);
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