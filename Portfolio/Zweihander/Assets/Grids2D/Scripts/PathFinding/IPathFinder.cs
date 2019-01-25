using System;
using System.Collections.Generic;
using System.Text;

namespace Grids2D.PathFinding {

	public delegate int OnCellCross(int location);

	interface IPathFinder {

		HeuristicFormula Formula {
			get;
			set;
		}

		bool Diagonals {
			get;
			set;
		}

		bool HeavyDiagonals {
			get;
			set;
		}

		bool HexagonalGrid {
			get;
			set;
		}

		int HeuristicEstimate {
			get;
			set;
		}

		int MaxSteps {
			get;
			set;
		}
		
		int MaxSearchCost {
			get;
			set;
		}

		int CellGroupMask {
			get;
			set;
		}

		List<PathFinderNode> FindPath (PathFindingPoint start, PathFindingPoint end, out int cost, bool evenLayout);
		void SetCalcMatrix(Cell[] grid);

		OnCellCross OnCellCross { get; set; }

	}
}
