using System;

namespace SIMSA.ViewModels
{
	public class EntryVM : ViewModelBase
	{
		string text;
		readonly Action changed;
		public string Caption { get; }
		
		public EntryVM(string caption, string text, Action changed)
		{
			this.text = text;
			this.changed = changed;
			Caption = caption;
		}
		public string Text
		{
			get => text;
			set
			{
				if (text != value)
				{
					text = value;
					changed();
					PropertyChange("Text");
				}
			}
		}
	}
}
