﻿// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    /// <summary>
    /// The boolean parameter control.
    /// </summary>
    public partial class BooleanParameterControl : ParameterControlBase, IParameterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanParameterControl"/> class.
        /// </summary>
        public BooleanParameterControl()
        {
            InitializeComponent();
            ButtonVisible = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether button visible.
        /// </summary>
        public bool ButtonVisible
        {
            get { return false; }

            set { }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public string Caption
        {
            get { return checkBox1.Text; }

            set { checkBox1.Text = value; }
        }

        /// <summary>
        /// The get table.
        /// </summary>
        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        public object GetValue()
        {
            return checkBox1.Checked;
        }
    }
}