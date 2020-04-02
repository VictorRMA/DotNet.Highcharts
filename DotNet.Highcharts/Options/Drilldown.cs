using System;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Attributes;
using DotNet.Highcharts.Helpers;

namespace DotNet.Highcharts.Options
{
	/// <summary>
	/// <p>Options for drill down, the concept of inspecting increasingly high resolution data through clicking on chart items like columns or pie slices.</p><p>The drilldown feature requires the <code>drilldown.js</code> file to be loaded, found in the <code>modules</code> directory of the download package, or online at <a href='http://code.highcharts.com/modules/drilldown.js'>code.highcharts.com/modules/drilldown.js</a>.</p>
	/// </summary>
	public class Drilldown
	{
		/// <summary>
		/// Additional styles to apply to the X axis label for a point that has drilldown data. By default it is underlined and blue to invite to interaction. Defaults to:<pre>activeAxisLabelStyle: { cursor: 'pointer', color: '#0d233a', fontWeight: 'bold', textDecoration: 'underline'}</pre>
		/// </summary>
		[JsonFormatter("{{ {0} }}")]
		public string ActiveAxisLabelStyle { get; set; }

		/// <summary>
		/// Additional styles to apply to the data label of a point that has drilldown data. By default it is underlined and blue to invite to interaction. Defaults to:<pre>activeAxisLabelStyle: { cursor: 'pointer', color: '#0d233a', fontWeight: 'bold', textDecoration: 'underline'}</pre>
		/// </summary>
		[JsonFormatter("{{ {0} }}")]
		public string ActiveDataLabelStyle { get; set; }

		/// <summary>
		/// <p>Set the animation for all drilldown animations. Animation of a drilldown occurs when drilling between a column point and a column series, or a pie slice and a full pie series. Drilldown can still be used between series and points of different types, but animation will not occur.</p>  <p>The animation can either be set as a boolean or a configuration object. If <code>true</code>, it will use the 'swing' jQuery easing and a duration of 500 ms. If used as a configuration object, the following properties are supported:  </p><dl> <dt>duration</dt> <dd>The duration of the animation in milliseconds.</dd>  <dt>easing</dt> <dd>When using jQuery as the general framework, the easing can be set to <code>linear</code> or <code>swing</code>. More easing functions are available with the use of jQuery plug-ins, most notably the jQuery UI suite. See <a href='http://api.jquery.com/animate/'>the jQuery docs</a>. When using  MooTools as the general framework, use the property name <code>transition</code> instead  of <code>easing</code>.</dd> </dl>
		/// </summary>
		[JsonFormatter(addPropertyName: false, useCurlyBracketsForObject: false)]
		public Animation Animation { get; set; }

		/// <summary>
		/// Options for the drill up button that appears when drilling down on a series. The text for the button is defined in <a href='#lang.drillUpText'>lang.drillUpText</a>.
		/// </summary>
		public DrilldownDrillUpButton DrillUpButton { get; set; }

		/// <summary>
		/// An array of series configurations for the drill down. Each series configuration uses the same syntax as the <a href='#series'>series</a> option set. These drilldown series are hidden by default. The drilldown series is linked to the parent series' point by its <code>id</code>.
		/// </summary>
		public Series[] Series { get; set; }

	}

}