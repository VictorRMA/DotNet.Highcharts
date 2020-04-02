using System;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Helpers;

namespace DotNet.Highcharts.Options
{
	/// <summary>
	/// Options for the drill up button that appears when drilling down on a series. The text for the button is defined in <a href='#lang.drillUpText'>lang.drillUpText</a>.
	/// </summary>
	public class DrilldownDrillUpButton
	{
		/// <summary>
		/// Positioning options for the button within the <code>relativeTo</code> box. Available properties are <code>x</code>, <code>y</code>, <code>align</code> and <code>verticalAlign</code>.
		/// </summary>
		public Position Position { get; set; }

		/// <summary>
		/// What box to align the button to. Can be either 'plotBox' or 'spacingBox'.
		/// Default: plotBox
		/// </summary>
		public string RelativeTo { get; set; }

		/// <summary>
		/// A collection of attributes for the button. The object takes SVG attributes like  <code>fill</code>, <code>stroke</code>, <code>stroke-width</code> or <code>r</code>, the border radius. The theme also supports <code>style</code>, a collection of CSS properties for the text. Equivalent attributes for the hover state are given in <code>theme.states.hover</code>.
		/// </summary>
		public Object Theme { get; set; }

	}

}