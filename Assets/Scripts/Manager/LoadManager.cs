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
            //SceneManager.sceneUnloaded += FadeLoadingScreen;
        }
        private void OnDisable()
        {
            //SceneManager.sceneUnloaded -= FadeLoadingScreen;
        }
        public void LoadScene(string name)
        {
            TriggerLoadingScreen();
            StartCoroutine(Load(name));
        }
        IEnumerator Load(string name)
        {
            yield return new WaitForSeconds(0.1f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            //operation.allowSceneActivation = false;
            while(!operation.isDone)
            {
                yield return null;
            }
        }
        private void TriggerLoadingScreen()
        {
            //loadingScreen.DOColor(Color.black, 0);
            loadingScreen.gameObject.SetActive(true);
        }
        private void FadeLoadingScreen(Scene scene)
        {
            loadingScreen.DOFade(0, 1);
            Invoke("TurnOffLoadingScreen", 1);
        }
        private void TurnOffLoadingScreen()
        {
            loadingScreen.gameObject.SetActive(false);
        }
    }
}