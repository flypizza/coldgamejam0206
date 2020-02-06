using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class IntroTitleText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 cur_pos = transform.position;
        RectTransform rt = GetComponent<RectTransform>();

        Sequence seq = DOTween.Sequence();
        seq.Append(rt.DOAnchorPosY(1.0f, 0.1f).SetDelay(0.3f));
        seq.Append(rt.DOShakeAnchorPos(0.3f));
        seq.AppendCallback(CallBack_test);


    }

    public void CallBack_test()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
