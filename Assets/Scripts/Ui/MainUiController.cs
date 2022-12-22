using System;
using General;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class MainUiController:MonoBehaviour
    {
        [SerializeField] private MainUiView view;

        private void Start()
        {
            view.StartButton.onClick.AddListener(OnStartButtonClicked);
            view.RetryButton.onClick.AddListener(OnRetryButtonClicked);
            PlayerController.OnCubesAmountZeroOrLess += ShowRetryButton;
        }

        private void OnDestroy()
        {
            view.StartButton.onClick.RemoveListener(OnStartButtonClicked);
            view.RetryButton.onClick.RemoveListener(OnRetryButtonClicked);
            PlayerController.OnCubesAmountZeroOrLess -= ShowRetryButton;
        }

        private void OnStartButtonClicked()
        {
            view.StartButton.gameObject.SetActive(false);
            CubeSpawnService.StartSpawning();
        }
        
        private void OnRetryButtonClicked()
        {
            SceneManager.LoadScene(0);
        }

        private void ShowRetryButton()
        {
            view.RetryButton.gameObject.SetActive(true);
        }
    }
}