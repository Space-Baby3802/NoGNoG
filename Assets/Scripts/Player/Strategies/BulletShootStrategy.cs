using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;
    public BulletShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Bullets");
        this.interactor = interactor;
        shootPoint = interactor.GetShootPoint();

        //Change gun color
        interactor.gunRenderer.material.color = interactor.bulletGunColor;
    }
    public void Shoot()

    {
        PooledObjects pooledObject = interactor.bulletPool.GetPooledObject();
        pooledObject.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody bullet = pooledObject.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.AddForce(shootPoint.forward * interactor.GetShootVelocity());

        interactor.bulletPool.DestroyObjectFromPool(pooledObject, 5.0f);
        //Destroy(bullet.gameObject, 5.0f);
    }
}
