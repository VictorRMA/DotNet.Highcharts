using System;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Helpers;

namespace DotNet.Highcharts.Options
{
	/// <summary>
	/// A wrapper object for all the series options in specific states.
	/// </summary>
	public class PlotOptionsLineStates
	{
		/// <summary>
		/// Options for the hovered series
		/// </summary>
		public PlotOptionsLineStatesHover Hover { get; set; }

	}

}