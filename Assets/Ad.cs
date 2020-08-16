using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallAD());
    }
    IEnumerator CallAD()
    {
        yield return new WaitForSeconds(2f);
        Ads.instance.ShowBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
