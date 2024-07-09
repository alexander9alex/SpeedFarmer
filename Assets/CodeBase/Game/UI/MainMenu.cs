using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase.Game.UI
{
   public class MainMenu : MonoBehaviour
   {
      [SerializeField] private Button _playButton;
      [SerializeField] private Button _settingsButton;
      [SerializeField] private Button _exitButton;
      
      private IGameStateMachine _gameStateMachine;

      public void Construct(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
         _playButton.onClick.AddListener(LoadGame);
         // _settingsButton.onClick.AddListener(создать меню настроек);
         _exitButton.onClick.AddListener(QuitGame);
      }
      
      private void LoadGame() => 
         _gameStateMachine.Enter<LoadGameState>();

      private void QuitGame() => 
         Application.Quit();
   }
}