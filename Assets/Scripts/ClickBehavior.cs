using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickColorData
{
    public string ObjectType;
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color Color;

    public ClickColorData(string newObjectType, int newMinClicksCount, int newMaxClicksCount, Color newColor)
    {
        ObjectType = newObjectType;
        MinClicksCount = newMinClicksCount;
        MaxClicksCount = newMaxClicksCount;
        Color = newColor;
    }
}

public class ClickBehavior : MonoBehaviour
{
    int ClickCount = 0;
    int ClickToDetroy = 7;
    string ObjectType;
    List<ClickColorData> ClicksData = new List<ClickColorData>();
    public string RaycastReturn;
    GameObject Figure;
    GameObject StartHit;
    public Text myText;

    void Start()
    {
        StartHit = GameObject.Find("Start");
        ClicksData.Add(new ClickColorData("Cube", 2, 4, Color.grey));
        ClicksData.Add(new ClickColorData("Capsule", 3, 5, Color.blue));
        ClicksData.Add(new ClickColorData("Sphere", 4, 6, Color.red));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ClickCount++;
                RaycastReturn = hit.collider.gameObject.name;
                Figure = hit.transform.gameObject;
                if (RaycastReturn == "Cube(Clone)")
                {
                    ObjectType = "Cube";
                }
                if (RaycastReturn == "Capsule(Clone)")
                {
                    ObjectType = "Capsule";
                }
                if (RaycastReturn == "Sphere(Clone)")
                {
                    ObjectType = "Sphere";
                }

                for (int i = 0; i < ClicksData.Count; i++)
                {
                    if (ObjectType == ClicksData[i].ObjectType)
                    {
                        if (ClickCount >= ClicksData[i].MinClicksCount && ClickCount <= ClicksData[i].MaxClicksCount)
                        {
                            gameObject.GetComponent<Renderer>().material.color = ClicksData[i].Color;
                        }
                    }
                }

                myText.text = "" + ClickCount.ToString();

                if (ClickCount == ClickToDetroy)
                {
                    ClickCount = 0;
                    StartBehavior.game_start = false;
                    StartHit.GetComponent<Renderer>().enabled = true;
                    Destroy(Figure);
                }
            }     
        }
    }
}
