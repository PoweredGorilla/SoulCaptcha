using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SoulCaptcha {
    public class SceneNavigator : MonoBehaviour {

        public UnityAction sceneLoaded;

        static SceneNavigator instance;

        public static SceneNavigator Instance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<SceneNavigator>();
                }
                return instance;
            }
        }

        void Reset() {
            gameObject.name = "SceneNavigator";
        }

        public void Change(string sceneName) {
            SceneManager.LoadScene(sceneName);
            if (sceneLoaded != null) {
                sceneLoaded();
            }
        }
    }
}
