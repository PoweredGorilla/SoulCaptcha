using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulCaptcha {
    public class InputManager : MonoBehaviour {
        public enum SceneType {
            TITLE,
            CHARA_SELECT,
            MAIN,
            PAUSE,
            SCORE,
            GAME_OVER
        }

        public SceneType sceneType;

        bool charaChanged = false;

        void Reset() {
            gameObject.name = "InputManager";
        }

        // Update is called once per frame
        void Update() {
            if (sceneType == SceneType.TITLE) {
                CallProcessOnTitle();
            }
            if (sceneType == SceneType.CHARA_SELECT) {
                CallProcessOnCharaSelect();
            }
        }

        void CallProcessOnTitle() {
            if (Input.GetButtonDown("Fire")) {
                SceneNavigator.Instance.Change("CharaSelect");
            }
        }

        void CallProcessOnCharaSelect() {
            float axis = Input.GetAxisRaw("Horizontal");
            if (axis > 0 && !charaChanged) {
                CharaSelector.Instance.Next();
                charaChanged = true;
            }
            else if (axis < 0 && !charaChanged) {
                CharaSelector.Instance.Previous();
                charaChanged = true;
            }
            else if (axis == 0) {
                charaChanged = false;
            }

            if (Input.GetButtonDown("Fire")) {
                SceneNavigator.Instance.Change("Main");
            }
        }
    }
}
