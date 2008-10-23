using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CustomControl
{
	public partial class RegexTextBox : System.Windows.Forms.TextBox
	{
		#region Construction / Destruction
		public RegexTextBox()
		{
			InitializeComponent();
            CausesValidation = true;
			customPattern = "^()$";
			oldValue = this.Text;
		}
		#endregion

		#region Fields
		private string customPattern;
		private string oldValue;
		#endregion

		#region Properties
		[Category("Regular Expression")]
		[DisplayName("Custom Pattern"), Browsable(true)]
		[Description("The custom string pattern that used to validate the contents of this Text Box.")]		
		public string CustomPattern
		{
			get 
			{
				return customPattern; 
			}
			set 
			{
				customPattern = value; 
			}
		}

		[Browsable(false)]
		public bool Valid
		{
			get
			{
				return IsValid(this.Text);
			}
		}

		[Browsable(false)]
		public string OldValue
		{
			get
			{
				return oldValue;
			}
		}
		#endregion

		#region Methods
		private bool IsValid(String contentString)
		{
			bool isValid = false;
			try
			{
				if (!String.IsNullOrEmpty(contentString))
				{
					Regex currentRegex = new Regex(customPattern);
					Match currentMatch = currentRegex.Match(contentString, 0, contentString.Length);
					if (currentMatch.Success &&
						currentMatch.Index == 0 &&
						currentMatch.Length == contentString.Length)
					{
						isValid = true;
					}
				}				
			}
            catch 
			{
				throw;
			}
			return isValid;
		}
		#endregion

		#region Event Handlers
		protected override void OnValidating(CancelEventArgs e)
		{
			base.OnValidating(e);
		}

		protected override void OnEnter(EventArgs e)
		{
			oldValue = this.Text;
			base.OnEnter(e);
		}
		#endregion
	}
}

