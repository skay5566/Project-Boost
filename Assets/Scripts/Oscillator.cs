using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 moveVector;
    [SerializeField] [Range(1,20)]float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles*tau);
        float moveFactor = (rawSinWave +1f) / 2f;

        Vector3 offset = moveFactor * moveVector;
        transform.position = startPosition + offset;
    }
}
