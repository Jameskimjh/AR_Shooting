using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    
    public Transform[] pos;

    public Transform centerPos;
  

    Vector3 posVec;
    private void Start()
    {
        
        StartCoroutine(WaitAndSpawn());
    }

    
    IEnumerator WaitAndSpawn()
    {
        HashSet<Vector3> usedPositions = new HashSet<Vector3>();

        while(true)
        {
            
           
            float WaitTime = Random.Range(1.5f, 2.3f);

            yield return new WaitForSeconds(WaitTime);

            for (int i = 0; i < 3; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);

                int attempts = 0;
                Vector3 newPos = Vector3.zero;

                do
                {
                    int iPos = Random.Range(0, pos.Length);
                    newPos = pos[iPos].position;
                    attempts++;
                }
                while(usedPositions.Contains(newPos)&& attempts<pos.Length);
              
                if(usedPositions.Contains(newPos))
                {
                    break;
                }

                usedPositions.Add(newPos);

                GameObject obj = Instantiate(prefab[iPrefab], newPos,Quaternion.Euler(0,180f,0));
              
                Destroy(obj, 10f);
                
            }

            if(usedPositions.Count == pos.Length)
            {
                usedPositions.Clear();
            }
        }

    }

}
