using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UIManager;

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
        }
        public void LoadScene(string name)
        {
            StartCoroutine(Load(name));
        }
        IEnumerator Load(string name)
        {
            loadingScreen.StartTransition();
            yield return new WaitForSeconds(0.5f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            while(!operation.isDone)
            {
                yield return null;
            }
            loadingScreen.EndTransition();
        }
    }
}