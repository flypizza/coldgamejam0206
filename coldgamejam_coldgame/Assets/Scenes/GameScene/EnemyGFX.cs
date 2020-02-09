using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class EnemyGFX : MonoBehaviour
{
    SpriteRenderer sp;

    public List<Sprite> faces;
    List<Color> colors = new List<Color>();

    Bounds oriBounds;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        oriBounds = sp.bounds;

        colors.Add(Color.blue);
        colors.Add(Color.white);
        colors.Add(Color.white);
        colors.Add(Color.white);
        colors.Add(Color.white);
        colors.Add(Color.cyan);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
        colors.Add(Color.gray);
        colors.Add(Color.red);
    }

    private void Start()
    {
        SelectRandomFace();
    }

    public Vector2 curScale;
    public void SelectRandomFace()
    {
        int face_index = UnityEngine.Random.Range(0, faces.Count - 1);
        int color_index = UnityEngine.Random.Range(0, colors.Count - 1);


        sp.sprite = faces[face_index];
        sp.color = colors[color_index];


        Bounds curBounds = sp.bounds;

        float scaleX = oriBounds.size.x / curBounds.size.x;
        float scaleY = oriBounds.size.y / curBounds.size.y;

        curScale = new Vector2(scaleX, scaleY);
        sp.transform.localScale = curScale;
    }


}
