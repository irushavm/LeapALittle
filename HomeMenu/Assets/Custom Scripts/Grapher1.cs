using UnityEngine;
using System.Collections;
using Leap;

public class Grapher1 : MonoBehaviour
{
    public Grapher1():base(){
        
    }
    [Range(15, 45)] public int resolution = 30;

    private ParticleSystem.Particle[] points;

    float grab;
    float pinch;

    int frameCounter = 4;
    int pointCounter = 0;
    
    // Use this for initialization
    void Start()
    {
        Debug.Log("Init: started");

        points = new ParticleSystem.Particle[resolution];

        
        float increment = 1f / (resolution - 1);
        for (int i = 0; i < resolution; i++)
        {
            float x = i * increment;
            points[i].position = new Vector2(x, x);
            points[i].color = new Color(0f, 1f, 1f);
            points[i].size = 0.1f;
            Debug.Log("Point "+i + " made");
        }
        Debug.Log("Init: Done");

        //Change Foreground to the layer you want it to display on 
        //You could prob. make a public variable for this
        ParticleSystem temp = GetComponent<ParticleSystem>();
        temp.GetComponent <Renderer>().sortingLayerName = "Foreground";


    }





    // Update is called once per frame
    void Update()
    {

        if (HandAttributes.Current_Hand != null)
        {
            grab = 0;//HandAttributes.Current_Hand.getgrabStrength();
            pinch = 0;// HandAttributes.Current_Hand.getPinchStrength();
            //float normDir = recentHand.PalmNormal;

            GetComponent<ParticleSystem>().SetParticles(points, points.Length);
            if ((frameCounter == 0) && (pointCounter < resolution))
            {
                points[pointCounter].size = 0.2f;
                Vector3 p = points[pointCounter].position;
                p.y = p.x;
                points[pointCounter].position = p;
                Color c = points[pointCounter].color;
                c.g = p.y;
                points[pointCounter].color = c;
                frameCounter = 2;
                pointCounter += 1;
            }
            else
            {
                frameCounter -= 1;
            }
        }
    }
}

