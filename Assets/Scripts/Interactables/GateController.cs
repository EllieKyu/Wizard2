using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class GateController : MonoBehaviour
{
    [SerializeField]
    bool Locked = true;

    [SerializeField]
    float GateEndPositionY;

    [SerializeField]
    AudioClip GateOpening1;

    [SerializeField]
    AudioClip GateOpening2;

    AudioSource myAudioSource;

    GameObject myChildMovable;

    BoxCollider2D myBoxCollider;

    bool HasPlayerCompletedLevel = false;

    [SerializeField]
    string TakePlayerToSpecialLevel = "";

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();

        myAudioSource = GetComponent<AudioSource>();

        myChildMovable = transform.GetChild(0).gameObject;

        if (!Locked)
        {
            Unlock();
        }
    }

    public void Unlock()
    {
        Locked = false;

        // Start animating sprite upwards

        // Remove collision on box collider
        myBoxCollider.enabled = false;

        myChildMovable.transform.DOLocalMoveY(GateEndPositionY, 2.0f);

        myAudioSource.clip = GateOpening1;
        myAudioSource.Play();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Locked || HasPlayerCompletedLevel)
            return;

        if (PlayerIsDead())
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCompletedLevel();
        }
    }

    private bool PlayerIsDead()
    {
        return PlayerCollision.Instance.isDead;
    }

    void PlayerCompletedLevel()
    {
        HasPlayerCompletedLevel = true;

        if (TakePlayerToSpecialLevel.Length > 0)
        {
            Application.LoadLevel(TakePlayerToSpecialLevel);
        }
        else
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
