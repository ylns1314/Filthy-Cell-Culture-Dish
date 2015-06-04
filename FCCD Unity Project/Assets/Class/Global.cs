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

using System.Collections.Generic;
using Gamelogic.Grids;
namespace AssemblyCSharp
{
	public class Global
	{	
		public readonly static int GROWTH =0;
		public readonly static int EXPLORATION = 1;
		public readonly static int ATTACKING = 2;
		public readonly static int DEFENSING = 3;
		public readonly static int ULTIMATE = 4;
		public static int WIDTH =10;
		public static int HEIGHT =10;
		public static int maxTurn = 100;
		public static Boolean explored = false;
		public static Boolean block = false;
		public static int numberOfPlayers = 2;
		public readonly static int numTech = 5;
		public readonly static int baseCapacity = 100;
		public static int winPop;
		public static int[,] techCost;

		public static DiamondGrid<SpriteCell> grid;
		public static Dictionary<DiamondPoint, Cell> binder;
//		public static Dictionary<DiamondPoint ,int> pops;
		public static int numTurns = 0;
		public static int currentPlayer = 0;
		public static List<Player> players = new List<Player>();
		public static List<Cell> cells = new List<Cell>();
		public static Player winner;

		public static int largestPop = 0;
		public static int largestTerritory = 0;
		public static Player largestPopPlayer;
		public static Player largestCellPlayer;


		
		public static void updateCells(){
			foreach (Gamelogic.Grids.DiamondPoint point in grid) {
				Cell tempCell;
				Global.binder.TryGetValue (point, out tempCell);
				tempCell.update();
			}
		}

		public static void updateDemo(){
			int tmpPop = 0;
			int tmpCell = 0;
			foreach (Player player in players) {
				if (tmpPop < player.getPop ()) {
					tmpPop = player.getPop ();
					largestPopPlayer = player;
				}
				if (tmpCell < player.getCells ()) {
					tmpCell = player.getCells ();
					largestCellPlayer = player;
				}
			}
			largestPop = tmpPop;
			largestTerritory = tmpCell;


		}

		static void gameOver ()
		{
			GameStartManager.instance.SendMessage("StartLvl", "GameOver");
		}

		public static void updateWinStatus(){
			foreach (Player pl in players) {
				if (pl.getUltimateValue()==numTech-1||pl.getPop()>=winPop) {
					winner = pl;
					gameOver();
				}
			}
			winner = players [0];
			if (numTurns == maxTurn) {
				foreach (Player pl in players) {
					if (pl.getPop()>winner.getPop()) {
						winner = pl;
					}
				}
				gameOver();
			}
		}
	}
}

