#if PLAYMAKER
using HutongGames.PlayMaker;

namespace Shadex
{
    /// <summary>
    /// Get the total value for the skill from the leveling system.
    /// </summary>
    [ActionCategory("Spell System")]
    [HutongGames.PlayMaker.Tooltip("Get the skill value.")]
    public class GetSkillValue : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Direct link to the leveling system")]
        public CharacterBase levelingSystem;

        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Source gameobject to find the leveling system from")]
        public FsmGameObject Source;

        [UIHint(UIHint.FsmEnum)]
		[HutongGames.PlayMaker.Tooltip("The skill name")]
		public BaseSkill SkillName;

		[UIHint(UIHint.Variable)]
		[HutongGames.PlayMaker.Tooltip("The skill value")]
		public FsmFloat SkillValue;

		public bool everyFrame;

        /// <summary>
        /// Link to the leveling system, get the initial stats.
        /// </summary>
        public override void OnEnter()
        {
            if (levelingSystem == null)
            {
                if (Source.Value != null)
                {
                    levelingSystem = Source.Value.GetComponent<CharacterBase>();
                }
            }
            DoGetStat();
        }

        /// <summary>
        /// Update the stats, every frame optional.
        /// </summary>
		public override void OnUpdate()
		{
			DoGetStat();

			if (!everyFrame)
				Finish();
		}

        /// <summary>
        /// Actually get the stats.
        /// </summary>        
		private void DoGetStat()
		{
            if (levelingSystem)
            {
                SkillValue.Value = levelingSystem.GetSkillTotal(SkillName);
            }
		}

    }
}
#endif