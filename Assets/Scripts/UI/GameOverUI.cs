using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class GameOverUI : MonoBehaviour
    {
        private Text text;
        private Animator animation;
        bool IsTime = true;
        float x = 0;

        void Awake()
        {
            animation = GetComponent<Animator>();
            text = GetComponent<Text>();
            animation.enabled = false;

        }
 
        public void GameOverText()
        {
            animation.enabled = true;
        }
    }
}
