using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;

    //Constructor
    public RocketShootStrategy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Rockets");
        this.interactor = interactor;
        shootPoint = interactor.GetShootPoint();

        //Change gun color
        interactor.gunRenderer.material.color = interactor.rocketGunColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    
    {
        PooledObjects pooledObject = interactor.rocketPool.GetPooledObject();
        pooledObject.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody bullet = pooledObject.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.AddForce(shootPoint.forward * interactor.GetShootVelocity());

        interactor.rocketPool.DestroyObjectFromPool(pooledObject, 5.0f);
        //Destroy(bullet.gameObject, 5.0f);
    }
    
}
