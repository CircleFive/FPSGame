using UnityEngine;
using System.Collections;

public class stageSound : MonoBehaviour
{



    private AudioSource audioSource;    // AudioSorceコンポーネント格納用
    [SerializeField]
    private AudioClip sound;        // 効果音の格納用。インスペクタで。


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
    }
    // Update is called once per frame
    void Update()
    {
        audioSource.PlayOneShot(sound);
    }
}
