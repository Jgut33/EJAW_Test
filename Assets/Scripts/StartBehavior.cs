using UnityEngine;
using System;

public class StartBehavior : MonoBehaviour
{

    public GameObject cube;
    public GameObject sphere;
    public GameObject capsule;
    public static System.Random rnd = new System.Random(DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);
    private int figureRand;
    public static bool game_start = false;
    public GameObject StartHit;

    void Start()
    {

    }

    void Update()
    {
        if (game_start)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && !game_start)
        {
            game_start = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.transform.tag == "Finish")
                {
                    figureRand = rnd.Next(1, 4);
                    if (figureRand == 1)
                    {
                        Instantiate(cube, _hit.point, Quaternion.identity);
                    }
                    if (figureRand == 2)
                    {
                        Instantiate(sphere, _hit.point, Quaternion.identity);
                    }
                    if (figureRand == 3)
                    {
                        Instantiate(capsule, _hit.point, Quaternion.identity);
                    }
                    StartHit.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
}
