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
		public static int numberOfPlayers = 2;
		public readonly static int numTech = 50;
		public readonly static int baseCapacity = 100;
		public static bool explored;

		public static int[,] techCost;
		public static DiamondGrid<SpriteCell> grid;
//		public static Dictionary<DiamondPoint ,int> pops;
		public static int numTurns = 0;
		public static int currentPlayer = 0;
		public static List<Player> players = new List<Player>();
//		public static List<Cell> cells = new List<Cell>();
		public static Player winner;
		public static Player firstPlayer;

		public static int largestPop = 0;
		public static int largestTerritory = 0;

		public Global ()
		{
			techCost = new int[5,numTech];
		}


		public static void updateDemo(){
		}

		public static void updateWinStatus(){
		}
	}
}

