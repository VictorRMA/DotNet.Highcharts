using System;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Helpers;

namespace DotNet.Highcharts.Options
{
	/// <summary>
	/// Options for displaying a message like 'No data to display'. This feature requires the file <code>no-data-to-display.js</code> to be loaded in the page. The actual text to display is set in the <a href='#lang.noData'>lang.noData</a> option.
	/// </summary>
	public class NoData
	{
		/// <summary>
		/// An object of additional SVG attributes for the no-data label.
		/// </summary>
		public Object Attr { get; set; }

		/// <summary>
		/// The position of the no-data label, relative to the plot area. 
		/// Default: { "x": 0, "y": 0, "align": "center", "verticalAlign": "middle" }
		/// </summary>
		public Position Position { get; set; }

		/// <summary>
		/// CSS styles for the no-data label. 
		/// Default: { "fontSize": "12px", "fontWeight": "bold", "color": "#60606a" }
		/// </summary>
		[JsonFormatter("{{ {0} }}")]
		public string Style { get; set; }

	}

}