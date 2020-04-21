using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questMarker : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform camera;
    public Transform questTarget;
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
        Logger.log("" + Math.Acos(cosAngle)*(180/Mathf.PI));    //Winkel über arccos bestimmen und in Grad umrechnen
        
        //TODO: Winkel zum Objekt nutzen um QuestMarker zu verschieben, ganz links am Kompass sollte 30 Grad nach links sein
        //TODO: Winkel ist immer positiv, es muss noch rausgefunden werden, ob das Objekt links oder rechts ist
    }
}
