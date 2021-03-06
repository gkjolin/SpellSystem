#if PLAYMAKER

using HutongGames.PlayMaker;

namespace Shadex
{
    /// <summary>
    /// Find the player instance.
    /// </summary>
    [ActionCategory("Spell System")]
    [HutongGames.PlayMaker.Tooltip("Find the player gameobject.")]
    public class GetPlayer : FsmStateAction
    {
		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Tooltip("Store player gameobject to be found")]
		public FsmGameObject player;

        /// <summary>
        /// Actually find the player instance.
        /// </summary>
		public override void OnEnter()
		{
            if (player.Value == null)
            {
                player.Value = GlobalFuncs.FindPlayerInstance();
            }
        }

        /// <summary>
        /// Only run for one frame.
        /// </summary>
        /// <remarks>
        /// is this needed?
        /// </remarks>
        public override void OnUpdate()
        {
            Finish();
        }
    }
}

#endif