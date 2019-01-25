using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Grids2D.Geom;

namespace Grids2D {

	public partial class Territory: IAdmin {

		public string name { get; set; }
		public Region region { get; set; }
		public Vector2 capitalCenter;
		public List<Cell> cells;
		public Color fillColor = Color.gray;
		public bool visible { get; set; }

		public Territory (string name) {
			this.name = name;
			visible = true;
			cells =  new List<Cell>();
		}

		public Territory(): this("") { }

	}

}