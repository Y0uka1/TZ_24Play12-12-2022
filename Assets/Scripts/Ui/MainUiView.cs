using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class MainUiView:MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button retryButton;

        public Button RetryButton => retryButton;

        public Button StartButton => startButton;
    }
}