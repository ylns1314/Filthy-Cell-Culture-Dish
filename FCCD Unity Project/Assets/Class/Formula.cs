// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public static class Formula
	{
		public static double GrowthRate(int level) {
			return ((double) level) * 0.1 + 0.2;
		}

		public static int GrowthCap(int level) {
			if (level <= 0)
				return Global.baseCapacity;
			return Global.baseCapacity * level * 10;
		}

		public static int LosePop(Player Player1, Player PlayerX, int Pop1, int PopX) {
			return (int)(((double)(Player1.getDefenseValue() - PlayerX.getAttackValue())/
			              (double)(Player1.getAttackValue() + PlayerX.getAttackValue() + Player1.getDefenseValue() + PlayerX.getDefenseValue()) - 0.05) * (double)(Pop1 * PopX));
		}

		public static int GainPop(Player Player1, Player PlayerX, int Pop1, int PopX) {
			return (int)(((double)(Player1.getAttackValue() - PlayerX.getDefenseValue())/
			        (double)(Player1.getAttackValue() + PlayerX.getAttackValue() + Player1.getDefenseValue() + PlayerX.getDefenseValue()) + 0.05) * (double)(Pop1 * PopX));
		}

		public static double spreadThreshold(int level) {
			if (level < 0)
				return 0.9;
			if (level > 6)
				return 0.3;
			else
				return 0.9 - ((double) level) * 0.1;
		}

		// float r range from 0 ~ 1 (100%)
		public static Color ColorLighter(Color origin, float r) {
			if (r == 0.0f)
				return new Color(1.0f, 1.0f, 1.0f);
			float rate = 2.0f - r;
			rate = (float)Math.Sqrt (rate);
			float newr = (origin.r * rate > 1.0f) ? 1.0f : origin.r * rate;
			float newg = (origin.g * rate > 1.0f) ? 1.0f : origin.g * rate;
			float newb = (origin.b * rate > 1.0f) ? 1.0f : origin.b * rate;
			return new Color(newr, newg, newb);
		}

		public static Color ColorMixer(List<Color> origins) {
			float newr = 0.0f;
			float newg = 0.0f;
			float newb = 0.0f;
			int count = 0;

			foreach (Color color in origins) {
				newr += color.r;
				newg += color.g;
				newb += color.b;
				count ++;
			}

			if(count == 0)
				return new Color(1.0f, 1.0f, 1.0f);

			newr = newr / (float)count;
			newg = newg / (float)count;
			newb = newb / (float)count;
//			Debug.LogError ("newb: "+newb);

			return new Color(newr, newg, newb);
		}

	}
}

