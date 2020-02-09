using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Goal : MonoBehaviour
{
    GameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")  {
            if(gm.STATE == GAME_STATE.START)
            {
                Debug.Log("GameSet");
                gm.GameEnd();


                GameObject winner = collision.gameObject;
                if(winner.GetComponent<Health>().main_char)
                {
                    Pocket pc = winner.GetComponent<Pocket>();

                    gm.UpdateBestScore(pc.money);

                }
                else
                {
                    gm.YouLoose();
                }



                GameCameraManager gameCameraManager = FindObjectOfType<GameCameraManager>();
                gameCameraManager.proCamera2DCinematics.AddCinematicTarget(winner.transform, 0.5f, 3.0f, 3.0f);
                gameCameraManager.proCamera2DCinematics.Play();

                Health[] healths = FindObjectsOfType<Health>();

                foreach(Health _h in healths)
                {
                    if(_h.transform != winner.transform)
                    {
                        _h.Die();
                    }
                }
            }
        }
    }
}
