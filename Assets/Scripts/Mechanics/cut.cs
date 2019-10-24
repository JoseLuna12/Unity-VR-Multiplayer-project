using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut : MonoBehaviour
{
    public Rigidbody bala;

    public float fireRate = 3f;

    private float nextFire;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 20;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = this.gameObject;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            if(hit.collider.gameObject.tag == "pajaro" && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                hit.collider.gameObject.GetComponent<BirdVelocity>().birdDeath();
               
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }


        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody clone;
            clone = Instantiate(bala, transform.position, this.transform.rotation);
            renderLineSlingshot();
            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * 100);
           
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Space))
        {
            renderLineSlingshot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CubeCut.Cut(collision.transform, transform.position);
    }

    public void renderLineSlingshot()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var t = Time.time;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
        }
    }

}
