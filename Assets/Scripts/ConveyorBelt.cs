using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float conveyorSlideX;
    [SerializeField] private float conveyorSlideY;
    [SerializeField] private float conveyorSlideZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
            other.transform.position = new Vector3
            (
            other.transform.position.x + conveyorSlideX * Time.deltaTime,
            other.transform.position.y + conveyorSlideY * Time.deltaTime,
            other.transform.position.z + conveyorSlideZ * Time.deltaTime
            );
        Debug.Log("ConveyorIsMovignSomething");
    }
}
