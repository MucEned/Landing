using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace Managers
{
    public class LoadManager : MonoBehaviour
    {
        public static LoadManager Instance;
        [SerializeField] private TransitionController loadingScreen;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            if(Instance != null)
            {
                Debug.LogWarning("We are have 2 LoadManager!!!");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            //SceneManager.sceneUnloaded += FadeLoadingScreen;
        }
        private void OnDisable()
        {
            //SceneManager.sceneUnloaded -= FadeLoadingScreen;
        }
        public void LoadScene(string name)
        {
            StartCoroutine(Load(name));
        }
        IEnumerator Load(string name)
        {
            loadingScreen.StartTransition();
            yield return new WaitForSeconds(1f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            //operation.allowSceneActivation = false;
            while(!operation.isDone)
            {
                yield return null;
            }
            loadingScreen.EndTransition();
        }
    }
}