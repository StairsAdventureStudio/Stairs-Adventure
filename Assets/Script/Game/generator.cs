using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour {

    public GameObject wall;
    public GameObject up;
    public Vector2 lastWall;

    public List<GameObject> walls;
    public List<GameObject> ups;

    public int Len=10;
    public int dLen=15;

    public float xMove=2;
    int i=0;

    public Transform player;
	
	void Start () {
        lastWall = new Vector2(0, -25);
    }
	
	// Update is called once per frame
	void Update () {
		if(player.position.x>i*2-Len)
        {
            Generuj();
            Destroy(walls[i - dLen]);
            Destroy(ups[i - dLen]);
        }
	}

    void Generuj()
    {
        float y=Random.Range(0.5f, 4)+lastWall.y;
        float yRand=Random.Range(0, 4);
        float x= lastWall.x+ xMove;
        lastWall = new Vector2(x, y);
        Vector2 upPos = new Vector3(x,y+57+ yRand);
        walls.Add(Instantiate(wall, lastWall, Quaternion.identity));
        ups.Add(Instantiate(up, upPos, Quaternion.identity));
        i++;
    }
}
