using Player;

namespace Command
{
    public abstract class Command
    {
        public abstract void Execute();
    }
    
    /// <summary>
    /// Player movement command
    /// </summary>
    public class MoveCommand : Command
    {
        private readonly PlayerMovement playerMovement;
        private readonly float horizontal, vertical;
        
        /// <summary>
        /// MoveCommand's constructor
        /// </summary>
        /// <param name="playerMovement">Player movement</param>
        /// <param name="horizontal">Horizontal axis value</param>
        /// <param name="vertical">Vertical axis value</param>
        public MoveCommand(PlayerMovement playerMovement, float horizontal, float vertical)
        {
            this.playerMovement = playerMovement;
            this.horizontal = horizontal;
            this.vertical = vertical;
        }
        
        public override void Execute()
        {
            playerMovement.Move(horizontal, vertical);
        }
    }
}