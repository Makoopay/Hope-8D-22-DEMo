using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MilkShake;

public class GunScript : MonoBehaviour
{
    //Properties
    public float range = 100f;
    public GameObject impacteffect;
    public ParticleSystem muzzleflash;
    public bool IsShooting = false;
    public GameObject Hand;
    public Shaker camShaker;
    public ShakePreset ShakerPreset;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public LineRenderer lr;
    public float linedrawSpeed = 2f;

    //Camera
    public Camera fpsCam;

    //Animators
    public Animator animator;
    public Animator handAnimator;

    //Raycast
    RaycastHit hit;

    void Start()
    {
        //AnimatorComponents
        lr = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        handAnimator = Hand.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot Function
            Shoot();

        }
    }


    void Shoot()
    {
        //Raycast from camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {

            //Get what bullet hits
            Debug.Log(hit.transform.name);
            Debug.Log(hit.transform.name);



            //if player is range/melee attack
            if (IsShooting == true)
                {
                //Does nothing and returns to code
                    return;
                }
                if (IsShooting == false) 
                {
                //Play SoundEffect
                audioSource.PlayOneShot(clip, volume);
                //Particles
                GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
                muzzleflash.Play();
                //Destroy Particles 
                Destroy(impactGO, 2f);
                //CameraShake
                camShaker.Shake(ShakerPreset);
                //Check if what raycast hit has rigidbody
                if (hit.rigidbody != null)
                    {
                    //Check if what raycast hit has Enemy tag
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        //Sets enemy tag to dead enemy
                        hit.transform.gameObject.tag = "Dead Enemy";
                    }

                    //Pushes Enemy
                        hit.rigidbody.AddForce(ray.direction * 500f);
                    }

                //Starts the GunCycle so the gun dosent keep shooting nonstop
                StartCoroutine(GunCycle());
            }

        }

    }



    
    IEnumerator GunCycle ()
    {
        //Tells the code that the player is shooting
        IsShooting = true;
        Debug.Log("Player Is Attacking");
        animator.SetBool("Shooting", true);
        handAnimator.SetBool("Shooting", true);
        //Line Renderer

        lr.enabled = true;
        lr.SetPosition(0, hit.point);
        lr.SetPosition(1, muzzleflash.transform.position);
        float t = 0;
        float time = 1;
        Vector3 orig = lr.GetPosition(1);
        Vector3 orig2 = lr.GetPosition(0);
        lr.SetPosition(1, orig2);
        Vector3 newpos;
        for (; t < time; t += Time.deltaTime * 15)
        {
            newpos = Vector3.Lerp(orig, orig2, t / time);
            lr.SetPosition(1, newpos);
            yield return null;
        }
        lr.SetPosition(1, orig2);


        //Cooldown so animation could play
        yield return new WaitForSeconds(0.3f);

        //Tells the code that the player is not shooting
        lr.enabled = false;
        IsShooting = false;
        animator.SetBool("Shooting", false);
        handAnimator.SetBool("Shooting", false);
        Debug.Log("Player Is Not Attacking");
        
    }
    IEnumerator LineDraw()
    {
        float t = 1;
        float time = 0;
        Vector3 orig = lr.GetPosition(1);
        Vector3 orig2 = lr.GetPosition(0);
        lr.SetPosition(0, orig);
        Vector3 newpos;
        for (; t > time; t += Time.deltaTime)
        {
            newpos = Vector3.Lerp(orig2, orig, t / time);
            lr.SetPosition(0, newpos);
            yield return null;
        }
        lr.SetPosition(0, orig2);
    }

}
