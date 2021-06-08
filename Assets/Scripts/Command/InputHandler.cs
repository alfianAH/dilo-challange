using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Command
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Toggle moveWithKeyboardToggle;
        
        private PlayerMovement playerMovement;
        private readonly Queue<Command> commands = new Queue<Command>();

        #region MonoBehaviour Methods

        private void Awake()
        {
            playerMovement = PlayerMovement.Instance;
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.IsGameOver || !GameManager.Instance.startTheGame) return;
            
            // If move with keyboard toggle is on, ...
            if(moveWithKeyboardToggle.isOn)
            {
                // Move with keyboard
                // Get input for move command
                Command moveWithKeyboardCommand = MovementWithKeyboardHandler();
                ExecuteCommand(moveWithKeyboardCommand);
            }
            else
            {
                // Move with mouse
                // Get input for move command
                Command moveWithMouseCommand = MovementWithCursorHandler();
                ExecuteCommand(moveWithMouseCommand);
            }
        }

        #endregion

        #region Player Movement
        
        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="executedCommand">Executed command</param>
        private void ExecuteCommand(Command executedCommand)
        {
            // If command is not null, ...
            if (executedCommand != null)
            {
                // Execute the command
                commands.Enqueue(executedCommand);
                executedCommand.Execute();
            }
        }
        
        /// <summary>
        /// Handle keyboard input for player movement
        /// W    : Up
        /// A    : Left
        /// S    : Down
        /// D    : Right
        /// </summary>
        /// <returns>MoveCommand</returns>
        private Command MovementWithKeyboardHandler()
        {
            // Up movement
            if (Input.GetKey(KeyCode.W))
            {
                return new MoveCommand(playerMovement, 0, 1);
            }
            
            // Left movement
            if (Input.GetKey(KeyCode.A))
            {
                return new MoveCommand(playerMovement, -1, 0);
            }
            
            // Down movement
            if (Input.GetKey(KeyCode.S))
            {
                return new MoveCommand(playerMovement, 0, -1);
            }
            
            // Right movement
            if (Input.GetKey(KeyCode.D))
            {
                return new MoveCommand(playerMovement, 1, 0);
            }
            
            // Idle
            return new MoveCommand(playerMovement, 0, 0);
        }
        
        /// <summary>
        /// Handle movement with mouse position
        /// </summary>
        /// <returns>MoveCommand according to mouse position</returns>
        private Command MovementWithCursorHandler()
        {
            // If mouse is available, ...
            if (Input.mousePresent)
            {
                float horizontal = Input.mousePosition.x;
                float vertical = Input.mousePosition.y;
                return new MoveCommand(playerMovement, horizontal, vertical);
            }
            
            return new MoveCommand(playerMovement, 0, 0);
        }

        #endregion
    }
}