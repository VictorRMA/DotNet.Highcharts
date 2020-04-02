﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Microsoft.AspNetCore.Html;

namespace DotNet.Highcharts
{
    public class Highcharts : IHtmlString
    {
        internal string Name { get; private set; }
        internal string ContainerName { get; private set; }

        internal IDictionary<string, string> JsVariables { get; private set; }
        internal IDictionary<string, string> JsFunctions { get; private set; }

        internal GlobalOptions Options { get; private set; }

        internal string FunctionName { get; private set; }

        Chart _Chart;
        Credits _Credits;
        Drilldown _Drilldown;
        Labels _Labels;
        Legend _Legend;
        Loading _Loading;
        Navigation _Navigation;
        NoData _NoData;
        PlotOptions _PlotOptions;
        Pane _Pane;
        Pane[] _PaneArray;
        Series _Series;
        Series[] _SeriesArray;
        Subtitle _Subtitle;
        Title _Title;
        Tooltip _Tooltip;
        XAxis _XAxis;
        XAxis[] _XAxisArray;
        YAxis _YAxis;
        YAxis[] _YAxisArray;
        Exporting _Exporting;

        /// <summary>
        /// The chart object is the JavaScript object representing a single chart in the web page.
        /// </summary>
        /// <param name="name">The object name of the chart and related container</param>
        /// <see cref="http://www.highcharts.com/ref/"/>
        public Highcharts(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name of the chart must be specified.");

            Name = name;
            ContainerName = "{0}_container".FormatWith(name);
            JsVariables = new Dictionary<string, string>();
            JsFunctions = new Dictionary<string, string>();
        }

        /// <summary>
        /// Global options that don't apply to each chart. These options, like the lang options, must be set using the Highcharts.setOptions method.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Highcharts SetOptions(GlobalOptions options)
        {
            Options = options;
            return this;
        }

        /// <summary>
        /// Options regarding the chart area and plot area as well as general chart options.
        /// </summary>
        /// <param name="chart"></param>
        /// <returns></returns>
        public Highcharts InitChart(Chart chart)
        {
            _Chart = chart;
            return this;
        }

        /// <summary>
        /// Highchart by default puts a credits label in the lower right corner of the chart. 
        /// This can be changed using these options.
        /// </summary>
        public Highcharts SetCredits(Credits credits)
        {
            _Credits = credits;
            return this;
        }

        /// <summary>
        /// Options for drill down, the concept of inspecting increasingly high resolution data through clicking on chart items like columns or pie slices.
        /// The drilldown feature requires the drilldown.js file to be loaded, found in the modules directory of the download package, or online at code.highcharts.com/modules/drilldown.js.
        /// </summary>
        /// <param name="drilldown">The drilldown options.</param>
        /// <returns></returns>
        public Highcharts SetDrilldown(Drilldown drilldown)
        {
            _Drilldown = drilldown;
            return this;
        }

        /// <summary>
        /// Options for the exporting module.
        /// </summary>
        /// <param name="exporting"></param>
        /// <returns></returns>
        public Highcharts SetExporting(Exporting exporting)
        {
            _Exporting = exporting;
            return this;
        }

        /// <summary>
        /// HTML labels that can be positioined anywhere in the chart area.
        /// </summary>
        /// <param name="labels"></param>
        /// <returns></returns>
        public Highcharts SetLabels(Labels labels)
        {
            _Labels = labels;
            return this;
        }

        /// <summary>
        /// The legend is a box containing a symbol and name for each series item or point item in the chart.
        /// </summary>
        /// <param name="legend"></param>
        /// <returns></returns>
        public Highcharts SetLegend(Legend legend)
        {
            _Legend = legend;
            return this;
        }

        /// <summary>
        /// The loading options control the appearance of the loading screen that covers the plot area on chart operations. 
        /// This screen only appears after an explicit call to chart.showLoading(). It is a utility for developers to 
        /// communicate to the end user that something is going on, for example while retrieving new data via an XHR connection. 
        /// The "Loading..." text itself is not part of this configuration object, but part of the lang object.
        /// </summary>
        /// <param name="loading"></param>
        /// <returns></returns>
        public Highcharts SetLoading(Loading loading)
        {
            _Loading = loading;
            return this;
        }

        /// <summary>
        /// A collection of options for buttons and menus appearing in the exporting module.
        /// </summary>
        /// <param name="navigation"></param>
        /// <returns></returns>
        public Highcharts SetNavigation(Navigation navigation)
        {
            _Navigation = navigation;
            return this;
        }

        /// <summary>
        /// Options for displaying a message like "No data to display". This feature requires the file no-data-to-display.js to be loaded in the page. The actual text to display is set in the lang.noData option.
        /// </summary>
        /// <param name="noData">The no data options.</param>
        /// <returns></returns>
        public Highcharts SetNoData(NoData noData)
        {
            _NoData = noData;
            return this;
        }
        
        /// <summary>
        /// Applies only to polar charts and angular gauges. This configuration object holds general options for the combined X and Y axes set. Each xAxis or yAxis can reference the pane by index.
        /// </summary>
        /// <param name="pane">The pane options.</param>
        /// <returns></returns>
        public Highcharts SetPane(Pane pane)
        {
            _Pane = pane;
            return this;
        }

        /// <summary>
        /// Applies only to polar charts and angular gauges. This configuration object holds general options for the combined X and Y axes set. Each xAxis or yAxis can reference the pane by index.
        /// </summary>
        /// <param name="paneArray">Array of pane options.</param>
        /// <returns></returns>
        public Highcharts SetPane(Pane[] paneArray)
        {
            _PaneArray = paneArray;
            return this;
        }

        /// <summary>
        /// The plotOptions is a wrapper object for config objects for each series type. The config objects for each series 
        /// can also be overridden for each series item as given in the series array.
        /// Configuration options for the series are given in three levels. Options for all series in a chart are given in 
        /// the plotOptions.series object. Then options for all series of a specific type are given in the plotOptions of 
        /// that type, for example plotOptions.line. Next, options for one single series are given in the series array.
        /// </summary>
        /// <param name="plotOptions"></param>
        /// <returns></returns>
        public Highcharts SetPlotOptions(PlotOptions plotOptions)
        {
            _PlotOptions = plotOptions;
            return this;
        }

        /// <summary>
        /// The actual series to append to the chart. In addition to the members listed below, any member of the plotOptions 
        /// for that specific type of plot can be added to a series individually. For example, even though a general lineWidth 
        /// is specified in plotOptions.series, an individual lineWidth can be specified for each series.
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        public Highcharts SetSeries(Series series)
        {
            _Series = series;
            return this;
        }

        /// <summary>
        /// The actual series to append to the chart. In addition to the members listed below, any member of the plotOptions 
        /// for that specific type of plot can be added to a series individually. For example, even though a general lineWidth 
        /// is specified in plotOptions.series, an individual lineWidth can be specified for each series.
        /// </summary>
        /// <param name="seriesArray">Array of series options.</param>
        /// <returns></returns>
        public Highcharts SetSeries(Series[] seriesArray)
        {
            _SeriesArray = seriesArray;
            return this;
        }

        /// <summary>
        /// The chart's subtitle
        /// </summary>
        /// <param name="subtitle">The subtitle options.</param>
        /// <returns></returns>
        public Highcharts SetSubtitle(Subtitle subtitle)
        {
            _Subtitle = subtitle;
            return this;
        }

        /// <summary>
        /// The chart's main title.
        /// </summary>
        /// <param name="title">The title options.</param>
        /// <returns></returns>
        public Highcharts SetTitle(Title title)
        {
            _Title = title;
            return this;
        }

        /// <summary>
        /// Options for the tooltip that appears when the user hovers over a series or point.
        /// </summary>
        /// <param name="tooltip">The tooltip options.</param>
        /// <returns></returns>
        public Highcharts SetTooltip(Tooltip tooltip)
        {
            _Tooltip = tooltip;
            return this;
        }

        /// <summary>
        /// The X axis or category axis. Normally this is the horizontal axis, though if the chart is inverted this is the vertical axis.
        /// In case of multiple axes, the xAxis node is an array of configuration objects.
        /// </summary>
        /// <param name="xAxis">The X axis options.</param>
        /// <returns></returns>
        public Highcharts SetXAxis(XAxis xAxis)
        {
            _XAxis = xAxis;
            return this;
        }
        
        /// <summary>
        /// The X axis or category axis. Normally this is the horizontal axis, though if the chart is inverted this is the vertical axis.
        /// In case of multiple axes, the xAxis node is an array of configuration objects.
        /// </summary>
        /// <param name="xAxisArray">Array of X axis options.</param>
        /// <returns></returns>
        public Highcharts SetXAxis(XAxis[] xAxisArray)
        {
            _XAxisArray = xAxisArray;
            return this;
        }

        /// <summary>
        /// The Y axis or value axis. Normally this is the vertical axis, though if the chart is inverted this is the horiontal axis.
        /// In case of multiple axes, the yAxis node is an array of configuration objects.
        /// </summary>
        /// <param name="yAxis">The Y axis options.</param>
        /// <returns></returns>
        public Highcharts SetYAxis(YAxis yAxis)
        {
            _YAxis = yAxis;
            return this;
        }

        /// <summary>
        /// Sets the y axis.
        /// </summary>
        /// <param name="yAxisArray">Array Y axis options.</param>
        /// <returns></returns>
        public Highcharts SetYAxis(YAxis[] yAxisArray)
        {
            _YAxisArray = yAxisArray;
            return this;
        }

        /// <summary>
        /// Add the javascript variable to the same jQuery document ready where chart is initialized.
        /// Variables are added before the chart.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value of the variable.</param>
        /// <returns></returns>
        public Highcharts AddJavascripVariable(string name, string value)
        {
            JsVariables.Add(name, value);
            return this;
        }

        /// <summary>
        /// Add javascript function to the same jQuery document ready where chart is initialized.
        /// The functions are added after the chart.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <param name="body">The body of the function.</param>
        /// <param name="variables">The variables of the function.</param>
        /// <returns></returns>
        public Highcharts AddJavascripFunction(string name, string body, params string[] variables)
        {
            JsFunctions.Add("function {0}({1}){{".FormatWith(name, string.Join(", ", variables)), body);
            return this;
        }

        public Highcharts InFunction(string name)
        {
            FunctionName = name;
            return this;
        }

        /// <summary>
        /// Returns DIV element for the chart in an HTML-encoded string.
        /// </summary>
        /// <returns></returns>
        public HtmlString ChartContainerHtmlString()
        {
            return new HtmlString("<div id='{0}'></div>".FormatWith(ContainerName));
        }

        /// <summary>
        /// Returns JavaScript code for the chart in an HTML-encoded string.
        /// </summary>
        /// <returns></returns>
        public HtmlString ChartScriptHtmlString()
        {
            StringBuilder scripts = new StringBuilder();

            scripts.AppendLine("<script type='text/javascript'>");
            if (Options != null)
                scripts.AppendLine("Highcharts.setOptions({0});".FormatWith(JsonSerializer.Serialize(Options)));

            scripts.AppendLine("var {0};".FormatWith(Name));
            scripts.AppendLine(!string.IsNullOrEmpty(FunctionName) ? string.Format("function {0}() {{", FunctionName) : "$(document).ready(function() {");
            scripts.AppendHighchart(this);
            scripts.AppendLine(!string.IsNullOrEmpty(FunctionName) ? "}" : "});");

            scripts.AppendLine("</script>");

            return new HtmlString(scripts.ToString());
        }

        #region IHtmlString Members

        public string ToHtmlString()
        {
            return ChartContainerHtmlString().ToString() + ChartScriptHtmlString();
        }

        #endregion

        public string GetOptions()
        {
            StringBuilder options = new StringBuilder();
            options.Append(_Chart != null ? "chart: {{ renderTo:'{0}', {1} }}".FormatWith(ContainerName, JsonSerializer.Serialize(_Chart, false)) : "chart: {{ renderTo:'{0}' }}".FormatWith(ContainerName));

            if (_Credits != null)
            {
                options.AppendLine(", ");
                options.Append("credits: {0}".FormatWith(JsonSerializer.Serialize(_Credits)), 2);
            }

            if (_Labels != null)
            {
                options.AppendLine(", ");
                options.Append("labels: {0}".FormatWith(JsonSerializer.Serialize(_Labels)), 2);
            }

            if (_Legend != null)
            {
                options.AppendLine(", ");
                options.Append("legend: {0}".FormatWith(JsonSerializer.Serialize(_Legend)), 2);
            }

            if (_Loading != null)
            {
                options.AppendLine(", ");
                options.Append("loading: {0}".FormatWith(JsonSerializer.Serialize(_Loading)), 2);
            }

            if (_NoData != null)
            {
                options.AppendLine(", ");
                options.Append("nodata: {0}".FormatWith(JsonSerializer.Serialize(_NoData)), 2);
            }

            if (_PlotOptions != null)
            {
                options.AppendLine(", ");
                options.Append("plotOptions: {0}".FormatWith(JsonSerializer.Serialize(_PlotOptions)), 2);
            }

            if (_Pane != null)
            {
                options.AppendLine(", ");
                options.Append("pane: {0}".FormatWith(JsonSerializer.Serialize(_Pane)), 2);
            }

            if (_PaneArray != null)
            {
                options.AppendLine(", ");
                options.Append("pene: {0}".FormatWith(JsonSerializer.Serialize(_PaneArray)), 2);
            }

            if (_Subtitle != null)
            {
                options.AppendLine(", ");
                options.Append("subtitle: {0}".FormatWith(JsonSerializer.Serialize(_Subtitle)), 2);
            }

            if (_Title != null)
            {
                options.AppendLine(", ");
                options.Append("title: {0}".FormatWith(JsonSerializer.Serialize(_Title)), 2);
            }

            if (_Tooltip != null)
            {
                options.AppendLine(", ");
                options.Append("tooltip: {0}".FormatWith(JsonSerializer.Serialize(_Tooltip)), 2);
            }

            if (_XAxis != null)
            {
                options.AppendLine(", ");
                options.Append("xAxis: {0}".FormatWith(JsonSerializer.Serialize(_XAxis)), 2);
            }

            if (_XAxisArray != null)
            {
                options.AppendLine(", ");
                options.Append("xAxis: {0}".FormatWith(JsonSerializer.Serialize(_XAxisArray)), 2);
            }

            if (_YAxis != null)
            {
                options.AppendLine(", ");
                options.Append("yAxis: {0}".FormatWith(JsonSerializer.Serialize(_YAxis)), 2);
            }
            else if (_YAxisArray != null)
            {
                options.AppendLine(", ");
                options.Append("yAxis: {0}".FormatWith(JsonSerializer.Serialize(_YAxisArray)), 2);
            }

            if (_Exporting != null)
            {
                options.AppendLine(", ");
                options.Append("exporting: {0}".FormatWith(JsonSerializer.Serialize(_Exporting)), 2);
            }

            if (_Navigation != null)
            {
                options.AppendLine(", ");
                options.Append("navigation: {0}".FormatWith(JsonSerializer.Serialize(_Navigation)), 2);
            }

            if (_Series != null)
            {
                options.AppendLine(", ");
                options.Append("series: [{0}]".FormatWith(JsonSerializer.Serialize(_Series)), 2);
            }
            else if (_SeriesArray != null)
            {
                options.AppendLine(", ");
                options.Append("series: {0}".FormatWith(JsonSerializer.Serialize(_SeriesArray)), 2);
            }

            if (_Drilldown != null)
            {
                options.AppendLine(", ");
                options.Append("drilldown: {0}".FormatWith(JsonSerializer.Serialize(_Drilldown)), 2);
            }
            options.AppendLine();

            return options.ToString();
        }
    }
}