using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject hole;
    [SerializeField] GameObject blood;
    Coroutine myCor;
    BoxCollider bulletCollider;
    [SerializeField] int speed = 10000;


    public void InitiliazeFire(Vector3 hitPoint, Vector3 startPosition)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        if (bulletCollider == null)
            bulletCollider = GetComponent<BoxCollider>();
        bulletCollider.enabled = true;
        transform.position = startPosition;
        rb.AddForce((hitPoint - transform.position).normalized * speed);

        if (myCor != null)
            StopCoroutine(myCor);
        myCor = StartCoroutine(SleepBullet());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.transform.root.GetComponent<EnemyController>().TakeDamage();
            bulletCollider.enabled = false;
            Instantiate(blood,transform.position,transform.rotation);
           GameObject dirt = Instantiate(hole,transform.position,transform.rotation);
            dirt.transform.parent = collision.collider.transform;
            dirt.transform.LookAt(Camera.main.transform);
            Destroy(dirt,5);
        }
        else
        {
            GameObject dirt = Instantiate(hole,transform.position,transform.rotation);
            dirt.transform.parent = collision.collider.transform;
            dirt.transform.LookAt(Camera.main.transform);
            Destroy(dirt,5);
        }
    }
    IEnumerator SleepBullet()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
