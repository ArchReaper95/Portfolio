using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Grids2D.Geom;

namespace Grids2D {

	public enum CELL_SIDE {
		TopLeft = 0,
		Top = 1,
		TopRight = 2,
		BottomRight = 3,
		Bottom = 4,
		BottomLeft = 5
	}


	public partial class Cell: IAdmin {
		/// <summary>
		/// Optional cell name.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The territory to which this cell belongs to. You can change it using CellSetTerritory method.
		/// </summary>
		public int territoryIndex = -1;
		public Region region { get; set; }
		public Vector2 center;
		public bool visible { get; set; }

		/// <summary>
		/// Optional value that can be set with CellSetTag. You can later get the cell quickly using CellGetWithTag method.
		/// </summary>
		public int tag;
		public int row, column;

		/// <summary>
		/// If this cell blocks path finding.
		/// </summary>
		public bool canCross = true;
		int[] _crossCost;
		
		/// <summary>
		/// Used by pathfinding in Cell mode. Cost for crossing a cell for each side. Defaults to 1.
		/// </summary>
		/// <value>The cross cost.</value>
		public int[] crossCost {
			get { return _crossCost; }
			set { _crossCost = value; }
		}

		
		/// <summary>
		/// Group for this cell. A different group can be assigned to use along with FindPath cellGroupMask argument.
		/// </summary>
		public int group = 1;


		public Cell(string name, Vector2 center) {
			this.name = name;
			this.center = center;
		}

		public Cell(Vector2 center): this("", center) { }
		
		public Cell(): this("", Vector2.zero) { }
		
		public Cell (string name): this(name, Vector2.zero) { }

		
		/// <summary>
		/// Assigns a crossing cost for a given hexagonal side
		/// </summary>
		/// <param name="side">Side.</param>
		/// <param name="cost">Cost.</param>
		public void SetSideCrossCost(CELL_SIDE side, int cost) {
			if (_crossCost==null) _crossCost = new int[6];
			_crossCost[(int)side] = cost;
		}
		
		/// <summary>
		/// Sets the same crossing cost for all sides of the hexagon.
		/// </summary>
		public void SetAllSidesCost(int cost) {
			if (_crossCost==null) _crossCost = new int[6];
			for (int k=0;k<6;k++) { _crossCost[k] = cost; }
		}
		

	}
}

