using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class questMarker : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform camera;
    public RectTransform compass;
    public Transform questTarget;
    public QuestStage targettedStage;
    public float fieldOfView = 60;

    public questMarker(Transform player, Transform camera, RectTransform compass, Transform questTarget) 
    {
        this.player = player;
        this.camera = camera;
        this.compass = compass;
        this.questTarget = questTarget;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceVetor3 = questTarget.position - player.position; //Distanz Spieler-Questziel
        Vector2 distance = new Vector2(distanceVetor3.x, distanceVetor3.z); //Distanz Spieler-Questziel in 2D-Vector umwandeln (Vector2 würde sonst x und y nehmen, statt z)
        Vector2 playerRotation = new Vector2(Mathf.Sin(camera.eulerAngles.y * Mathf.Deg2Rad), Mathf.Cos(camera.eulerAngles.y * Mathf.Deg2Rad)); //Berechnet Rotation der Kamera in Vektor
        float cosAngle = (distance.x * playerRotation.x + distance.y * playerRotation.y) / (distance.magnitude * playerRotation.magnitude); //cos(angle) über Skalarprodukt bestimmen
        float angle = Mathf.Acos(cosAngle)*(180/Mathf.PI);    //Winkel über arccos bestimmen und in Grad umrechnen

        Vector2 distanceNormed = distance/distance.magnitude;
        Vector2 rotationNormed = playerRotation / playerRotation.magnitude;

        int markerPos = 1;
        if((-distanceNormed.x * rotationNormed.y + distanceNormed.y * rotationNormed.x) > 0)
        {
            markerPos = -1;     //depends, if the marker position should be moved left (negative x) or right (positive x)
        }
        else
        {
            markerPos = 1;
        }

        float compassWidth = compass.rect.width;
        if(angle <= fieldOfView/2)
        {
            this.transform.position = new Vector3(((compassWidth/fieldOfView)*angle*markerPos)+compass.position.x, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(((compassWidth/2) * markerPos) + compass.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
