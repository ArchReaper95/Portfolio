using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Grids2D.PathFinding;

namespace Grids2D {

				public partial class Grid2D : MonoBehaviour {

								IPathFinder finder;
								bool needRefreshRouteMatrix;

								void ComputeRouteMatrix () {

												if (!needRefreshRouteMatrix)
																return;

												// prepare matrix
//			if (routeMatrix == null) {
//				needRefreshRouteMatrix = true;
//				routeMatrix = new byte[_cellColumnCount * _cellRowCount];
//			}
//
//			if (!needRefreshRouteMatrix) return;
//
//			// Compute route
//			for (int j=0; j<_cellRowCount; j++) {
//				int jj = j * _cellColumnCount;
//				for (int k=0; k<_cellColumnCount; k++) {
//					int cellIndex = jj + k;
//					if (cells[cellIndex].canCross && cells[cellIndex].visible) {	// set navigation bit
//						routeMatrix [cellIndex] = 1;
//					} else {		// clear navigation bit
//						routeMatrix [cellIndex] = 0;
//					}
//				}
//			}

												if (finder == null) {
																if ((_cellColumnCount & (_cellColumnCount - 1)) == 0) {	// is power of two?
																				finder = new PathFinderFast (cells.ToArray (), _cellColumnCount, _cellRowCount);
																} else {
																				finder = new PathFinderFastNonSQR (cells.ToArray (), _cellColumnCount, _cellRowCount);
																}
												} else {
																finder.SetCalcMatrix (cells.ToArray ());
												}
												needRefreshRouteMatrix = false;
								}

								/// <summary>
								/// Used by FindRoute method to satisfy custom positions check
								/// </summary>
								int FindRoutePositionValidator (int location) {
												int cost = 1;
												if (OnPathFindingCrossCell != null) {
																cost = OnPathFindingCrossCell (location);
												}
												return cost;
								}

				}

}