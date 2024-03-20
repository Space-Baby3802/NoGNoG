using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorScript : MonoBehaviour
{
    [SerializeField] AudioSource Aud1;
    [SerializeField] AudioSource Aud2;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenDoor()
    {
        anim.SetTrigger("LifeWagered");
        Aud1.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
