using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winplayer : MonoBehaviour
{
 [SerializeField] private AudioSource audioLoserSource;
    // Start is called before the first frame update
    void Start()
    {
        audioLoserSource.Play();
    }
}
