using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using GameEvents;
namespace GameUX
{
    public class CinemachineCamShake : MonoBehaviour
    {
        private CinemachineVirtualCamera cm;
        private CinemachineBasicMultiChannelPerlin cbmcp;
        private float shakeTimer;
        private float defaultFrequencyGain;
        private float defaulAmplitudeGain;
        private float currentFrequencyGain;
        private float currentAmplitudeGain;
        private float lastShakeTime;
        private void Start()
        {
            cm = GetComponent<CinemachineVirtualCamera>();
            cbmcp = cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            defaultFrequencyGain = cbmcp.m_FrequencyGain;
            defaulAmplitudeGain = cbmcp.m_AmplitudeGain;

            AllEvents.OnPlayerLanding += OnPlayerLand;
            AllEvents.OnDevilDead += OnDevilDead;
            AllEvents.OnDevilReachBarrier += OnDevilReachBarrier;
            AllEvents.OnPlayerDeadByCeiling += OnPlayerDeadByCeiling;
        }
        void OnDestroy()
        {
            AllEvents.OnPlayerLanding -= OnPlayerLand;
            AllEvents.OnDevilDead -= OnDevilDead;
            AllEvents.OnDevilReachBarrier -= OnDevilReachBarrier;
            AllEvents.OnPlayerDeadByCeiling -= OnPlayerDeadByCeiling;
        }

        // Update is called once per frame
        void Update()
        {
            if (shakeTimer >= 0)
                shakeTimer -= Time.deltaTime;
            else
            {
                cbmcp.m_FrequencyGain = defaultFrequencyGain;
                Mathf.Lerp(currentFrequencyGain, defaultFrequencyGain, lastShakeTime);
                Mathf.Lerp(currentAmplitudeGain, defaulAmplitudeGain, lastShakeTime);
            }
        }
        private void OnEndGame()
        {
            Shake(1, 0.3f);
        }
        private void OnPlayerLand()
        {
            Shake(1, 0.1f);
        }
        private void OnDevilDead()
        {
            Shake(0.5f, 0.1f);
        }
        private void Shake(float intensity, float time)
        {
            cbmcp.m_FrequencyGain = intensity;
            cbmcp.m_AmplitudeGain = intensity;

            currentFrequencyGain = cbmcp.m_FrequencyGain;
            currentAmplitudeGain = cbmcp.m_AmplitudeGain;

            shakeTimer = time;
            lastShakeTime = shakeTimer;
        }
        private void OnDevilReachBarrier()
        {
            Shake(0.5f, 0.5f);
        }
        private void OnPlayerDeadByCeiling()
        {
            Shake(1.5f, 5f);
        }
    }
}
