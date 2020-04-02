using System;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Helpers;

namespace DotNet.Highcharts.Options
{
	/// <summary>
	/// The side for the frame around a 3D chart.
	/// </summary>
	public class ChartOptions3dFrameSide
	{
		/// <summary>
		/// The color of the panel.
		/// Default: transparent
		/// </summary>
		public Color? Color { get; set; }

		/// <summary>
		/// The thickness of the panel.
		/// Default: 1
		/// </summary>
		public Number? Size { get; set; }

	}

}