using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Enum;

namespace SimpleGame.Domain.Models
{
    [Serializable]
    public class BasicGame : Game
    {
        public event EventHandler OnChanged;
        public Guid ID
        { get; set; }
        public Player ActivePlayer
        { get; set; }

        public Board Board
        { get; set; }

        public State GameState
        { get; set; }

        public string Output
        { get; set; }

        public PlayerContainer Players
        { get; set; }

        public GameStatus GameStatus
        { get { return GameState.Status; } }

        public int MaxSize
        {
            get;private set;
        }
        public void SetState(State state)
        {
            this.GameState = state;
            this.GameState.Init(this);
        }
        public void Join(Player player)
        {
            GameState.Join(this, player);
            OnChanged(this, new EventArgs());
        }

        public void Leave(Player player)
        {
            GameState.Leave(this, player);
        }

        public void Play(Player player, Space space, Position position)
        {
            GameState.Play(this, player, space, position);
        }

        protected virtual void Updated(EventArgs e)
        {

        }
        public BasicGame(Board board, PlayerContainer playerContainer, int maxSize)
        {
            Board = board;
            Players = playerContainer;
            MaxSize = maxSize;
        }

        
    }
}
