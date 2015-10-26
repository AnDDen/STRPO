using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Task1.Components
{
    public partial class AddEditControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void MarkValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int m = int.Parse(args.Value);
                args.IsValid = (m >= 0 && m <= 5);
            }
            catch (Exception) {
                args.IsValid = false;
            }
        }

        public string Name 
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }

        public string Surname
        {
            get
            {
                return textBoxSurname.Text;
            }
            set
            {
                textBoxSurname.Text = value;
            }
        }

        public string ThirdName
        {
            get
            {
                return textBoxThirdName.Text;
            }
            set
            {
                textBoxThirdName.Text = value;
            }
        }
        
        IDictionary<string, int> disciplines;

        public IDictionary<string, int> Disciplines
        {
            get
            {
                return disciplines;
            }
            set
            {
                disciplines = value;
                if (DropDownDiscipline.Items.Count == 0)
                {
                    foreach (string s in disciplines.Keys)
                        DropDownDiscipline.Items.Add(s);
                }
            }
        }

        public int CurrentDiscipline
        {
            get
            {
                return disciplines.Values.ElementAt(DropDownDiscipline.SelectedIndex);
            }
            set
            {
                DropDownDiscipline.SelectedValue = disciplines.First((x) => { return x.Value == value; }).Key;
            }
        }

        public int Mark
        {
            get
            {
                return Convert.ToInt32(textBoxMark.Text);
            }
            set
            {
                textBoxMark.Text = value.ToString();
            }
        }

        public event EventHandler Submit;
        public event EventHandler Cancel;

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                OnSubmit(e);
        }

        protected void OnSubmit(EventArgs e)
        {
            if (Submit != null)
                Submit(this, e);
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancel(e);
        }

        protected void OnCancel(EventArgs e)
        {
            if (Cancel != null)
                Cancel(this, e);
        }
    }
}