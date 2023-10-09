﻿namespace Skyline.DataMiner.Utils.InteractiveAutomationScript
{
	using System;
	using System.Globalization;
	using System.Linq;

	using Skyline.DataMiner.Automation;

	/// <summary>
	///     Widget to show/edit a datetime.
	/// </summary>
	public class DateTimePicker : TimePickerBase
	{
		private readonly AutomationDateTimePickerOptions dateTimePickerOptions;

		private bool changed;
		private bool focusLost;

		private DateTime dateTime;
		private DateTime previous;
		private bool displayServerTime = false;

		/// <summary>
		///     Initializes a new instance of the <see cref="DateTimePicker" /> class.
		/// </summary>
		/// <param name="dateTime">Value displayed in the datetime picker.</param>
		public DateTimePicker(DateTime dateTime) : base(new AutomationDateTimePickerOptions())
		{
			Type = UIBlockType.Time;
			DateTime = dateTime;
			dateTimePickerOptions = (AutomationDateTimePickerOptions)DateTimeUpDownOptions;
			ValidationText = "Invalid Input";
			ValidationState = UIValidationState.NotValidated;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="DateTimePicker" /> class.
		/// </summary>
		public DateTimePicker() : this(DateTime.Now)
		{
		}

		/// <summary>
		///     Triggered when a different datetime is picked.
		///     WantsOnChange will be set to true when this event is subscribed to.
		/// </summary>
		public event EventHandler<DateTimePickerChangedEventArgs> Changed
		{
			add
			{
				OnChanged += value;
				BlockDefinition.WantsOnChange = true;
			}

			remove
			{
				OnChanged -= value;
				if (OnChanged == null || !OnChanged.GetInvocationList().Any())
				{
					BlockDefinition.WantsOnChange = false;
				}
			}
		}

		/// <summary>
		///     Triggered when the user loses focus of the DateTimePicker.
		///     WantsOnFocusLost will be set to true when this event is subscribed to.
		/// </summary>
		public event EventHandler<DateTimePickerFocusLostEventArgs> FocusLost
		{
			add
			{
				OnFocusLost += value;
				BlockDefinition.WantsOnFocusLost = true;
			}

			remove
			{
				OnFocusLost -= value;
				if (OnFocusLost == null || !OnFocusLost.GetInvocationList().Any())
				{
					BlockDefinition.WantsOnFocusLost = false;
				}
			}
		}

		private event EventHandler<DateTimePickerChangedEventArgs> OnChanged;

		private event EventHandler<DateTimePickerFocusLostEventArgs> OnFocusLost;

		/// <summary>
		/// 	Gets or sets a value indicating whether gets or sets whether the displayed time is the server time or local time.
		/// </summary>
		public bool DisplayServerTime
		{
			get
			{
				return displayServerTime;
			}

			set
			{
				displayServerTime = value;
				DateTime = dateTime;
			}
		}

		/// <summary>
		///     Gets or sets the datetime displayed in the datetime picker.
		/// </summary>
		public DateTime DateTime
		{
			get
			{
				return dateTime;
			}

			set
			{
				dateTime = value;
				if (DisplayServerTime)
				{
					BlockDefinition.InitialValue = value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
				}
				else
				{
					BlockDefinition.InitialValue = value.ToString(AutomationConfigOptions.GlobalDateTimeFormat, CultureInfo.InvariantCulture);
				}
			}
		}

		/// <summary>
		///     Gets or sets a value indicating whether the calendar pop-up will close when the user clicks a new date.
		/// </summary>
		public bool AutoCloseCalendar
		{
			get
			{
				return dateTimePickerOptions.AutoCloseCalendar;
			}

			set
			{
				dateTimePickerOptions.AutoCloseCalendar = value;
			}
		}

		/// <summary>
		///     Gets or sets the maximum timestamp.
		/// </summary>
		public DateTime Maximum
		{
			get
			{
				return DateTimeUpDownOptions.Maximum ?? DateTime.MaxValue;
			}

			set
			{
				DateTimeUpDownOptions.Maximum = value;
			}
		}

		/// <summary>
		///     Gets or sets the minimum timestamp.
		/// </summary>
		public DateTime Minimum
		{
			get
			{
				return DateTimeUpDownOptions.Minimum ?? DateTime.MinValue;
			}

			set
			{
				DateTimeUpDownOptions.Minimum = value;
			}
		}

		/// <summary>
		///     Gets or sets the tooltip.
		/// </summary>
		/// <exception cref="ArgumentNullException">When the value is <c>null</c>.</exception>
		public string Tooltip
		{
			get
			{
				return BlockDefinition.TooltipText;
			}

			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				BlockDefinition.TooltipText = value;
			}
		}

		/// <summary>
		///     Gets or sets the display mode of the calendar inside the date-time picker control.
		///     Default: <c>CalendarMode.Month</c>.
		/// </summary>
		public CalendarMode CalendarDisplayMode
		{
			get
			{
				return dateTimePickerOptions.CalendarDisplayMode;
			}

			set
			{
				dateTimePickerOptions.CalendarDisplayMode = value;
			}
		}

		/// <summary>
		///     Gets or sets a value indicating whether the calendar control drop-down button is shown.
		///     Default: <c>true</c>.
		/// </summary>
		public bool HasDropDownButton
		{
			get
			{
				return dateTimePickerOptions.ShowDropDownButton;
			}

			set
			{
				dateTimePickerOptions.ShowDropDownButton = value;
			}
		}

		/// <summary>
		///     Gets or sets a value indicating whether the time picker is shown within the calender control.
		///     Default: <c>true</c>.
		/// </summary>
		public bool IsTimePickerVisible
		{
			get
			{
				return dateTimePickerOptions.TimePickerVisible;
			}

			set
			{
				dateTimePickerOptions.TimePickerVisible = value;
			}
		}

		/// <summary>
		///     Gets or sets a value indicating whether the spin box of the calender control is shown.
		///     Default: <c>true</c>.
		/// </summary>
		public bool HasTimePickerSpinnerButton
		{
			get
			{
				return dateTimePickerOptions.TimePickerShowButtonSpinner;
			}

			set
			{
				dateTimePickerOptions.TimePickerShowButtonSpinner = value;
			}
		}

		/// <summary>
		///     Gets or sets a value indicating whether the spin box of the calender is enabled.
		///     Default: <c>true</c>.
		/// </summary>
		public bool IsTimePickerSpinnerButtonEnabled
		{
			get
			{
				return dateTimePickerOptions.TimePickerAllowSpin;
			}

			set
			{
				dateTimePickerOptions.TimePickerAllowSpin = value;
			}
		}

		/// <summary>
		///     Gets or sets the time format of the time picker.
		///     Default: <c>DateTimeFormat.ShortTime</c>.
		/// </summary>
		public DateTimeFormat TimeFormat
		{
			get
			{
				return dateTimePickerOptions.TimeFormat;
			}

			set
			{
				dateTimePickerOptions.TimeFormat = value;
			}
		}

		/// <summary>
		///     Gets or sets the time format string used when TimeFormat is set to <c>DateTimeFormat.Custom</c>.
		/// </summary>
		/// <remarks>Sets <see cref="TimeFormat" /> to <c>DateTimeFormat.Custom</c>.</remarks>
		public string CustomTimeFormat
		{
			get
			{
				return dateTimePickerOptions.TimeFormatString;
			}

			set
			{
				TimeFormat = DateTimeFormat.Custom;
				dateTimePickerOptions.TimeFormatString = value;
			}
		}

		/// <summary>
		/// 	Gets or sets the state indicating if a given input field was validated or not and if the validation was valid.
		/// 	This should be used by the client to add a visual marker on the input field.
		/// </summary>
		/// <remarks>Available from DataMiner 10.0.5 onwards.</remarks>
		public UIValidationState ValidationState
		{
			get
			{
				return BlockDefinition.ValidationState;
			}

			set
			{
				BlockDefinition.ValidationState = value;
			}
		}

		/// <summary>
		/// 	Gets or sets the text that is shown if the validation state is invalid.
		/// 	This should be used by the client to add a visual marker on the input field.
		/// </summary>
		/// <remarks>Available from DataMiner 10.0.5 onwards.</remarks>
		public string ValidationText
		{
			get
			{
				return BlockDefinition.ValidationText;
			}

			set
			{
				BlockDefinition.ValidationText = value;
			}
		}

		/// <summary>
		///     Load any changes made through user interaction.
		/// </summary>
		/// <param name="uiResults">
		///     Represents the information a user has entered or selected in a dialog box of an interactive
		///     Automation script.
		/// </param>
		/// <remarks><see cref="InteractiveWidget.DestVar" /> should be used as key to get the changes for this widget.</remarks>
		protected internal override void LoadResult(UIResults uiResults)
		{
			string isoString = uiResults.GetString(DestVar);
			bool wasOnFocusLost = uiResults.WasOnFocusLost(this);

			DateTime result = DateTime.Parse(isoString);

			if (BlockDefinition.WantsOnChange && (result != DateTime))
			{
				changed = true;
				previous = DateTime;
			}

			if (BlockDefinition.WantsOnFocusLost)
			{
				focusLost = wasOnFocusLost;
			}

			DateTime = result;
		}

		/// <summary>
		///     Raises zero or more events of the widget.
		///     This method is called after <see cref="InteractiveWidget.LoadResult" /> was called on all widgets.
		/// </summary>
		/// <remarks>It is up to the implementer to determine if an event must be raised.</remarks>
		protected internal override void RaiseResultEvents()
		{
			if (changed)
			{
				OnChanged?.Invoke(this, new DateTimePickerChangedEventArgs(DateTime, previous));
			}

			if (focusLost)
			{
				OnFocusLost?.Invoke(this, new DateTimePickerFocusLostEventArgs(DateTime));
			}

			changed = false;
			focusLost = false;
		}

		/// <summary>
		///     Provides data for the <see cref="Changed" /> event.
		/// </summary>
		public class DateTimePickerChangedEventArgs : EventArgs
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="DateTimePickerChangedEventArgs"/> class.
			/// </summary>
			/// <param name="dateTime">The new value.</param>
			/// <param name="previous">The previous value.</param>
			internal DateTimePickerChangedEventArgs(DateTime dateTime, DateTime previous)
			{
				DateTime = dateTime;
				Previous = previous;
			}

			/// <summary>
			///     Gets the new datetime value.
			/// </summary>
			public DateTime DateTime { get; private set; }

			/// <summary>
			///     Gets the previous datetime value.
			/// </summary>
			public DateTime Previous { get; private set; }
		}

		/// <summary>
		///     Provides data for the <see cref="FocusLost" /> event.
		/// </summary>
		public class DateTimePickerFocusLostEventArgs : EventArgs
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="DateTimePickerFocusLostEventArgs"/> class.
			/// </summary>
			/// <param name="dateTime">The new value.</param>
			internal DateTimePickerFocusLostEventArgs(DateTime dateTime)
			{
				DateTime = dateTime;
			}

			/// <summary>
			///     Gets the new datetime value.
			/// </summary>
			public DateTime DateTime { get; private set; }
		}
	}
}