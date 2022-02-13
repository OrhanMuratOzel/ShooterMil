using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public static GunController instance;
    [SerializeField] Text countText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    [SerializeField] Transform gunTransform;

    [SerializeField] GameObject[] bullets;
    [SerializeField] GameObject[] bulletShells;
    [SerializeField] Bullet[] bulletScripts;
    int bulletCount = 0;

    public void FireBullet()
    {
        RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(gunTransform.forward);
        fireRotation = Quaternion.RotateTowards(fireRotation,Random.rotation,0);

        Debug.DrawRay(gunTransform.position, fireRotation * Vector3.forward*40,Color.red,5);
        if(Physics.Raycast(gunTransform.position, fireRotation*Vector3.forward,out hit, Mathf.Infinity))
        {
            bulletShells[bulletCount % bullets.Length].SetActive(true);
            bullets[bulletCount%bullets.Length].gameObject.SetActive(true);
            bulletScripts[bulletCount % bullets.Length].InitiliazeFire(hit.point,gunTransform.position);
            bulletCount++;
            countText.text = bulletCount +"";
        }

    }

}
