﻿using Autodesk.DesignScript.Runtime;
using D3jsLib;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Charts
{
    /// <summary>
    /// Nodes shared across all chart types.
    /// </summary>
    public class MiscNodes
    {
        private MiscNodes()
        {
        }

        /// <summary>
        /// Returns JSON string of the data object.
        /// </summary>
        /// <param name="data">Any of the Mandrill Chart Data objects.</param>
        /// <param name="pretty">If set to True string will be indented.</param>
        /// <returns name="Json">Json string representation of data.</returns>
        public static string DataToJson(object data, bool pretty = false)
        {
            if (pretty)
            {
                var obj = JsonConvert.DeserializeObject(((D3jsLib.ChartData)data).Data);
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            else
            {
                return ((D3jsLib.ChartData)data).Data;
            }
        }

        /// <summary>
        /// Chart Margins.
        /// </summary>
        /// <param name="Top">Top margin in pixels.</param>
        /// <param name="Bottom">Top margin in pixels.</param>
        /// <param name="Right">Right margin in pixels.</param>
        /// <param name="Left">Left margin in pixels.</param>
        /// <returns name="Margins">Margins</returns>
        public static Margins Margins(int Top = 20, int Bottom = 40, int Right = 20, int Left = 40)
        {
            D3jsLib.Margins m = new D3jsLib.Margins(Top, Bottom, Left, Right);
            return m;
        }

        /// <summary>
        /// Chart domain.
        /// </summary>
        /// <param name="A">Domain start.</param>
        /// <param name="B">Domain end.</param>
        /// <returns name="Domain">Area Chart Domain.</returns>
        /// <search>area, chart, domain</search>
        public static Domain Domain(double A = 0.0, double B = 1.0)
        {
            Domain d = new Domain(A, B);
            return d;
        }

        /// <summary>
        /// Grid Address node.
        /// </summary>
        /// <param name="column">Column integer.</param>
        /// <param name="row">Row integer.</param>
        /// <returns name="Address">Grid Address for chart placement.</returns>
        /// <search>address, mandrill, grid, gridster</search>
        public static GridAddress Address(int column = 1, int row = 1)
        {
            GridAddress address = new GridAddress(row, column);
            return address;
        }

        /// <summary>
        /// Returns null value.
        /// </summary>
        [IsVisibleInDynamoLibrary(false)]
        public static object GetNull()
        {
            return null;
        }

        /// <summary>
        /// Returns a default color in a list.
        /// </summary>
        /// <returns></returns>
        [IsVisibleInDynamoLibrary(false)]
        public static List<DSCore.Color> GetColorList()
        {
            return new List<DSCore.Color>() { DSCore.Color.ByARGB(1, 50, 130, 190) };
        }
    }
}
