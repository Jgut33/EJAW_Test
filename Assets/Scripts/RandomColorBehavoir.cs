using UnityEngine;

public class RandomColorBehavoir : MonoBehaviour
{
    public int ObservableTime = 3;
    float TimeCount = 0;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    void Update()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > ObservableTime)
        {
            TimeCount = 0;
            gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
        }
    }
}
