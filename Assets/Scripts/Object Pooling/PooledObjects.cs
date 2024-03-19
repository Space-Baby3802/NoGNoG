using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PooledObjects : MonoBehaviour
{
    
    ObjectPool associatedPool;

    public UnityEvent OnReset;

    private float timer;
    private float delayTime = 0;
    private bool setToDestroy = false;

    public void SetObjectPool(ObjectPool pool)
    {
        associatedPool = pool;
        timer = 0;
        delayTime = 0;
        setToDestroy = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (setToDestroy)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                setToDestroy = false;
                timer = 0;

                Destroy();
            }
        } 
    }

    public void ResetObject()
    {
        OnReset?.Invoke();
    }

    public void Destroy()
    {
        if (associatedPool != null)
        {
            associatedPool.RestoreObject(this);
        }
    }

    public void Destroy(float time)
    {

    }
}
