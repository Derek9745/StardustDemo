using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{ 
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        
    }

    public int currentSize;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public Transform spawnPoint;
    public static ObjectPooler Instance;
    //float callInvokeTime = 4f;

    private void Awake()
    {
        {
            Instance = this;
        }
  
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {

           Queue<GameObject> objectPool = new Queue<GameObject>();


            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                
           
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag) 
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }
        
        currentSize = poolDictionary[tag].Count;
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
        objectToSpawn.transform.position = spawnPoint.position;
        objectToSpawn.transform.rotation = spawnPoint.rotation;
        objectToSpawn.SetActive(true);
        //BulletLifeTime(objectToSpawn);
        


        return objectToSpawn;
    }

    public void ReturnToPool(GameObject objectToSpawn, string tag)
    {
  
        poolDictionary[tag].Enqueue(objectToSpawn);
        objectToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
        objectToSpawn.SetActive(false);
    }

    public GameObject SpawnMeteor(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }
        GameObject MeteorSpawnPoint = poolDictionary[tag].Dequeue();
        
        //Meteor.transform.position = new Vector3(Random.Range(5f,45f),.3f, Random.Range(5, 45f));
       // MeteorSpawnPoint.SetActive(true);
 

        return MeteorSpawnPoint;

    }

    public void ReturnMeteorToPool(GameObject Meteor, string tag)
    {
        poolDictionary[tag].Enqueue(Meteor);
        Meteor.SetActive(false);
     }

    void BulletLifeTime(GameObject objectToSpawn)
    {
      //wait 5 seconds then call returnToPool
    }

}
