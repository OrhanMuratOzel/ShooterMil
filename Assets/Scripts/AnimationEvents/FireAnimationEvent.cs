using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimationEvent : MonoBehaviour
{
    Animation fireAnimation;
    [SerializeField] ParticleSystem muzzle;
    bool canFire = true;
    private void Start() => fireAnimation = GetComponent<Animation>();
    public void OnReloaded() => canFire = true;
    public void OnFired() => canFire = false;
    public void OnFireBullet() => GunController.instance.FireBullet();
    public void OnMuzzlePlay() => muzzle.Play();
    public void Fire()
    {
        if (canFire)
        {
            fireAnimation.Play();
        }
    }

}
