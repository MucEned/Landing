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
        [SerializeField] private Image loadingScreen;

        private void Awake()
        {
            if(Instance != null)
            {
                Debug.LogError("We are have 2 LoadManager!!!");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            SceneManager.sceneLoaded += FadeLoadingScreen;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= FadeLoadingScreen;
        }
        public void LoadScene(string name)
        {
            StartCoroutine(Load(name));
            TriggerLoadingScreen();
        }
        IEnumerator Load(string name)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            while(!operation.isDone)
            {
                yield return null;
            }
        }
        private void TriggerLoadingScreen()
        {
            loadingScreen.DOColor(Color.black, 0);
            loadingScreen.gameObject.SetActive(true);
        }
        private void FadeLoadingScreen(Scene scene, LoadSceneMode mode)
        {
            loadingScreen.DOFade(0, 3);
            Invoke("TurnOffLoadingScreen", 3.25f);
        }
        private void TurnOffLoadingScreen()
        {
            loadingScreen.gameObject.SetActive(false);
        }
    }
}