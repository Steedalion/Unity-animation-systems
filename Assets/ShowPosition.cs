using UnityEngine;

public class ShowPosition : MonoBehaviour
{
    public CSVLogger logger;
   

    void Update()
    {
        Vector3[] vectors = new Vector3[1];
        vectors[0] = transform.position;
        logger.writeArrayPositions("name", "walk", vectors);
        
    }
}
