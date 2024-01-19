using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOG.Roby
{
    public static class EventManager
    {
        /// <summary>
        ///   Delegates for Custom Events
        /// </summary>
        public delegate void LeaderCardSelected_delegate( LeaderCard  currentCard , bool toggleState);


        /// <summary>
        ///  Custom Events
        /// </summary>
        public static event LeaderCardSelected_delegate LeaderCardSelected_Event;




        /// <summary>
        ///  Event Invokers
        /// </summary>
        public static void onLeaderCardSelected( LeaderCard card, bool toggleState)
        {
            LeaderCardSelected_Event?.Invoke( card, toggleState );
        }

    }
}
