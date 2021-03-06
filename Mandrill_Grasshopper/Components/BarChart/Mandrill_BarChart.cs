﻿using System;
using Grasshopper.Kernel;
using Mandrill_Resources.Properties;
using D3jsLib.BarChart;

namespace Mandrill_Grasshopper.Components.BarChart
{
    public class Mandrill_BarChart : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Mandrill_BarChart class.
        /// </summary>
        public Mandrill_BarChart()
          : base("Bar Chart", "Chart",
              "Bar Chart",
              Resources.CategoryName, Resources.SubCategoryBarChart)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Data", "D", Resources.Chart_DataDesc, GH_ParamAccess.item);
            pManager.AddGenericParameter("Style", "S", Resources.Chart_StyleDesc, GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Chart", "C", Resources.Chart_ChartDesc, GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            BarData data = null;
            BarStyle style = null;

            if (!DA.GetData<BarData>(0, ref data)) return;
            if (!DA.GetData<BarStyle>(1, ref style)) return;

            D3jsLib.BarChart.BarChart chart = new D3jsLib.BarChart.BarChart(data, style);

            DA.SetData(0, chart);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Resources.Charts_BarChart_Chart;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{ee010b44-c79b-4564-9ac7-6ef633c63166}"); }
        }

        public override GH_Exposure Exposure
        {
            get
            {
                return GH_Exposure.primary;
            }
        }
    }
}