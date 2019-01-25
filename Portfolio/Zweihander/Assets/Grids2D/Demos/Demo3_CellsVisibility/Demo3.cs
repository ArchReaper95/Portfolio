﻿using UnityEngine;
using System.Collections;

namespace Grids2D {
	public class Demo3 : MonoBehaviour {

		Grid2D grid;
		GUIStyle labelStyle;

		void Start () {
			// setup GUI styles
			labelStyle = new GUIStyle ();
			labelStyle.alignment = TextAnchor.MiddleCenter;
			labelStyle.normal.textColor = Color.black;

			// hide all cells
			grid = Grid2D.instance;
			grid.cells.ForEach( (cell) => cell.visible = false );
			grid.Redraw();
			
			// listen to events
			grid.OnCellClick += (int cellIndex) => toggleCellVisible(cellIndex);

		}

		void OnGUI () {
			GUI.Label (new Rect (0, 5, Screen.width, 30), "Click on any position to toggle cell visibility.", labelStyle);
		}

		void toggleCellVisible(int cellIndex) {
			grid.cells[cellIndex].visible = !grid.cells[cellIndex].visible;
			grid.Redraw();
		}


	}
}
