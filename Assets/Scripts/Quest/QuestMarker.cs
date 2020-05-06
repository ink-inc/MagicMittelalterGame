using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    public RectTransform compass;
    public Transform questTarget;
    public QuestStage targettedStage;
    public float fieldOfView = 60;

    public QuestMarker(Transform player, Transform camera, RectTransform compass, Transform questTarget) 
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
        Vector3 distanceVetor3 = questTarget.position - player.position; // Distance Player-Questtarget
        Vector2 distance = new Vector2(distanceVetor3.x, distanceVetor3.z); // Transform distance into 2D-Vector (Vector2 consists of x and y and discards z, which is needed)
        Vector2 playerRotation = new Vector2(Mathf.Sin(camera.eulerAngles.y * Mathf.Deg2Rad), Mathf.Cos(camera.eulerAngles.y * Mathf.Deg2Rad)); // Calculates rotation vector of camera
        float cosAngle = (distance.x * playerRotation.x + distance.y * playerRotation.y) / (distance.magnitude * playerRotation.magnitude); // get cos(angle) through dot product
        float angle = Mathf.Acos(cosAngle)*(180/Mathf.PI);    // use arccos to define angle and transform into degrees

        Vector2 distanceNormed = distance/distance.magnitude;
        Vector2 rotationNormed = playerRotation / playerRotation.magnitude;

        int markerPos = 1;
        if((-distanceNormed.x * rotationNormed.y + distanceNormed.y * rotationNormed.x) > 0)
        {
            markerPos = -1;     // depends, if the marker position should be moved left (negative x) or right (positive x)
        }
        else
        {
            markerPos = 1;
        }

        float compassWidth = compass.rect.width;
        if(angle <= fieldOfView/2)      // sets questmarker relatively to angle on the compass bar...
        {
            this.transform.position = new Vector3(((compassWidth/fieldOfView)*angle*markerPos)+compass.position.x, this.transform.position.y, this.transform.position.z);
        }
        else // ...or at the very end of the bar, if target is outside of field of view
        {
            this.transform.position = new Vector3(((compassWidth/2) * markerPos) + compass.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
