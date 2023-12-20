using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera; 
    public GameObject ShootPoint; //총구
    public Transform fireTransform;
    public float fireDistance = 40f;
    //public GameObject sound; // 피격소리

    //private AudioSource audio;
    public GameObject guneffect;
    public GameObject effect;

    //public GameObject gunsound;
    //public GameObject EnemySound;

    private RaycastHit enemyhit;
    private LineRenderer bulletLineRenderer;

    //private AudioSource audio;
    public AudioClip shoot;
    public AudioClip enemy;

    private void Awake()
    {
        bulletLineRenderer = ShootPoint.GetComponent<LineRenderer>();
        //AudioSource audio = GetComponent<AudioSource>(); 
    }

    private void Start()
    {
        //audio = GetComponent<AudioSource>();
        enemyhit = GameManager.instance.hit;
        
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = true;

    }

    public void Fire()
    {
        Vector3 hitposition = Vector3.zero;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward,out enemyhit,fireDistance))
        {
            if(enemyhit.transform.tag =="Enemy" ) 
            {
                Destroy(enemyhit.transform.gameObject);
             // Instantiate(sound, hit.point, Quaternion.LookRotation(hit.normal));
             
                GameManager.instance.Addscore(10);

                hitposition = enemyhit.transform.position;

                Instantiate(effect, hitposition, Quaternion.identity);
                AudioSource.PlayClipAtPoint(enemy, hitposition);
               // Instantiate(EnemySound, hitposition, Quaternion.identity);
                //audio.PlayOneShot(enemy);
                //audio.PlayOneShot(shoot);

                Instantiate(guneffect, fireTransform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(shoot,fireTransform.position);
              //Instantiate(gunsound, fireTransform.position, Quaternion.identity);

                StartCoroutine(ShotEffect(hitposition));
               
            }
        }
       
   
      
       
    }

    private IEnumerator ShotEffect(Vector3 hitposition)
    {
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitposition);

        bulletLineRenderer.enabled = true;
        
        yield return new WaitForSeconds(0.1f);

        bulletLineRenderer.enabled = false;
    }
  
}
