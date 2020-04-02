using System;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Helpers;

namespace DotNet.Highcharts.Options
{
	/// <summary>
	/// Provides the option to draw a frame around the charts by defining a bottom, front and back panel. 
	/// </summary>
	public class ChartOptions3dFrame
	{
		/// <summary>
		/// Defines the back panel of the frame around 3D charts.
		/// </summary>
		public ChartOptions3dFrameBack Back { get; set; }

		/// <summary>
		/// The bottom of the frame around a 3D chart.
		/// </summary>
		public ChartOptions3dFrameBottom Bottom { get; set; }

		/// <summary>
		/// The side for the frame around a 3D chart.
		/// </summary>
		public ChartOptions3dFrameSide Side { get; set; }

	}

}