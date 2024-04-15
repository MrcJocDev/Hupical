using UnityEngine;

namespace AirResistance2
{
	[System.Serializable]
	public class AirResistanceDefaults : ScriptableObject
	{
		public float defaultAirDensity = 1.225f;
		public float defaultDensityVariation = 0.5f;

		private void OnValidate()
		{
			defaultAirDensity = Mathf.Max(0, defaultAirDensity);
			defaultDensityVariation = Mathf.Clamp(defaultDensityVariation, 0, 1);
		}
	}
}