using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    

  
    private void Update()
    {
        transform.Translate(0, Mathf.Cos(Time.deltaTime)*0.1f , 0.01f);    
    }


}
