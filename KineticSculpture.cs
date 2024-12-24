using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticSculpture : MonoBehaviour
{
    public GameObject spherePrefab;  
    public int numberOfSpheres = 10; 
    public float radius = 5f;       
    public float speed = 1f;         
    public float heightSpeed = 0.1f; 
    public float colorChangeSpeed = 0.5f; 

    private GameObject[] spheres;  
    private Material[] sphereMaterials;  

    void Start()
    {
        spheres = new GameObject[numberOfSpheres];
        sphereMaterials = new Material[numberOfSpheres];

        for (int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphere = Instantiate(spherePrefab);
            sphere.transform.parent = transform; 
            float angle = i * Mathf.PI * 2 / numberOfSpheres;  
            sphere.transform.position = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            spheres[i] = sphere;

            sphereMaterials[i] = sphere.GetComponent<Renderer>().material;
        }
    }

    void Update()
    {
        AnimateSculpture(); 
    }

    void AnimateSculpture()
    {
        
        for (int i = 0; i < numberOfSpheres; i++)
        {
            float time = Time.time * speed + i * Mathf.PI * 0.1f;  
            float angle = time;  
            float height = Mathf.Sin(time * heightSpeed) * 2f;  
            float x = Mathf.Cos(angle) * radius;  
            float z = Mathf.Sin(angle) * radius;  

         
            spheres[i].transform.position = new Vector3(x, height, z);

          
            Color newColor = new Color(Mathf.Sin(time * colorChangeSpeed) * 0.5f + 0.5f,
                                       Mathf.Cos(time * colorChangeSpeed) * 0.5f + 0.5f,
                                       Mathf.Sin(time * colorChangeSpeed * 0.5f) * 0.5f + 0.5f);
            sphereMaterials[i].color = newColor; 
        }
    }
}


