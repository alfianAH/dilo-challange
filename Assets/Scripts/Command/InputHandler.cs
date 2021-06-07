using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Command
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private readonly Queue<Command> commands = new Queue<Command>();

        #region MonoBehaviour Methods

        private void Awake()
        {
            playerMovement = PlayerMovement.Instance;
        }

        private void FixedUpdate()
        {
            // Get input for move command
            Command moveCommand = MovementInputHandler();
            // If moveCommand is not null, ...
            if (moveCommand != null)
            {
                // Execute moveCommand
                commands.Enqueue(moveCommand);
                moveCommand.Execute();
            }
        }

        #endregion

        #region Player Movement
        
        /// <summary>
        /// Handle input for player movement
        /// W    : Up
        /// A    : Left
        /// S    : Down
        /// D    : Right
        /// </summary>
        /// <returns>MoveCommand</returns>
        private Command MovementInputHandler()
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

        #endregion
    }
}