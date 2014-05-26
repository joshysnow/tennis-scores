using System;

namespace Interpreter
{
    internal enum PlayerPosition
    {
        Server,
        Receiver
    }

    internal class Player : ICloneable
    {
        /// <summary>
        /// The character to represent the player in a sequence.
        /// </summary>
        public char CharIdentifier
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates if the player is serving or receiving.
        /// </summary>
        public PlayerPosition Position
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor. Initialises the players character identifier
        /// which, symbolises a point awarded for this player if
        /// it appears in the sequence read by the interpreter.
        /// </summary>
        /// <param name="identifier">The character to award a point for this player.</param>
        public Player(char identifier)
        {
            CharIdentifier = identifier;
        }

        /// <summary>
        /// Creates a shallow clone of the player.
        /// </summary>
        /// <returns>A clone of the player.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        public static void SwapPositions(Player one, Player two)
        {
            if (one.Position == PlayerPosition.Server)
            {
                one.Position = PlayerPosition.Receiver;
                two.Position = PlayerPosition.Server;
            }
            else
            {
                one.Position = PlayerPosition.Server;
                two.Position = PlayerPosition.Receiver;
            }
        }
    }
}
