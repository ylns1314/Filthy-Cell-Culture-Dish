//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using Gamelogic.Grids;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System.Threading;
namespace AssemblyCSharp
{
	public class Cell
	{
		private DiamondPoint point;
		public Dictionary<Player ,int> pops;
		public Cell (DiamondPoint DP)
		{
			point = DP;
			pops = new Dictionary<Player ,int>();
			foreach (Player pl in Global.players)
				pops.Add (pl, 0);
		}

		public void update(){
			// Search NearbyCells
			foreach (Cell neighbor in this.getNeighbors()) {
				foreach (Player pl in Global.players)
					if(((double)neighbor.getPop(pl) / (double)Formula.GrowthCap(pl.getGrowthValue())) > 
					  Formula.spreadThreshold(pl.getExplorationValue()))
						pops[pl]+= growthChecker((int)(1.0*Formula.GrowthRate(pl.getGrowthLevel())*neighbor.pops[pl]*(Formula.GrowthCap(pl.getGrowthLevel())-pops[pl])/100.0),pl);
			}
			List<Player> keys = new List<Player> (pops.Keys);
			// Update Population
			foreach (Player pl in Global.players)
			{
				pops[pl]+= growthChecker((int)(Formula.GrowthRate(pl.getGrowthLevel())*pops[pl]*(Formula.GrowthCap(pl.getGrowthLevel())-pops[pl])),pl);
				foreach (Player epl in Global.players){
					if(!pl.isPeaceWith(epl))
						pops[pl] += this.growthChecker(PopDance(pl, epl, pops[pl], pops[epl]), pl);
				}
				// race distinction
				if(pops[pl] <= 0)
					pops[pl] = 0;
				if(pops[pl] >=Formula.GrowthCap(pl.getGrowthLevel()))
					pops[pl] =(int)Formula.GrowthCap(pl.getGrowthLevel());

			}

		//	UpdateColor ();
		}

		public void UpdateColor() {
			List<Color> colorList = new List<Color> ();
			// Update Color
			foreach (Player player in this.getPlayerList())
				colorList.Add (Formula.ColorLighter(player.getColor(), ((float)this.getPop (player)/(float)Formula.GrowthCap (player.getGrowthValue ()))));
			foreach (Color item in colorList)
				Debug.Log (item);
			//			Debug.Log ("ha: "+Formula.ColorMixer(colorList));
			Global.grid [point].GetComponent<SpriteCell> ().Color = Formula.ColorMixer(colorList);
		}

		public int PopDance(Player Player1, Player PlayerX, int Pop1, int PopX) {
			return Formula.LosePop(Player1, PlayerX, Pop1, PopX) + 
				Formula.GainPop(Player1, PlayerX, Pop1, PopX);
		}

		public void explore(Player pl){
			pops[pl] += this.growthChecker(Formula.ExplorePop(pl), pl);
			UpdateColor ();
		}

		private List<Cell> getNeighbors(){
			List<Cell> ret = new List<Cell> ();

			var neighbors = Global.grid.GetNeighbors(point);
			
			foreach (DiamondPoint neighbor in neighbors)
			{
				if (neighbor == null)
				{
					Debug.LogError("cell null");
				}
				else
				{
					Cell tempCell;
					Global.oldbinder.TryGetValue (neighbor, out tempCell);
					ret.Add(tempCell);
				}
			}

			return ret;
		}

		private int growthChecker(int growth, Player pl) {
			if ((pops[pl] + growth) <= Formula.GrowthCap (pl.getGrowthLevel ()))
				return growth;
			else
				return Formula.GrowthCap (pl.getGrowthLevel()) - pops[pl];
		}

		public List<Player> getPlayerList() {
			List<Player> ret = new List<Player> ();
			foreach (var pop in pops)
				ret.Add (pop.Key);
			return ret;
		}

		public int getPop(Player pl) {
			int pop=0;
			pops.TryGetValue (pl, out pop);
				return pop;
		}



	}
}

