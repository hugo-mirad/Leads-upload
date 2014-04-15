using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductionBL;

namespace AutoFillForm
{
    public partial class EnterNotes : Form
    {
        SubmitionDetailsBL objSubmitionDetailsBL = new SubmitionDetailsBL();
        public EnterNotes()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int addnotecarid = Convert.ToInt32(GlobalNoteCarId.notecarid);
            string note = textBox1.Text;
            int AddedBy = 4;

            DataSet dsnt = objSubmitionDetailsBL.MultiSaveNotes(addnotecarid, note, AddedBy);
            if (dsnt.Tables[0].Columns.Count > 0)
            {
                if (dsnt.Tables[0].Rows.Count > 0)
                {
                    Main objm = new Main();
                    Globalnotestext.notetext = dsnt.Tables[0].Rows[0]["Note"].ToString();
                 objm.textBox4.Text=dsnt.Tables[0].Rows[0]["Note"].ToString();
         
                  
                }
            }
           
        }
    }

    public static class Globalnotestext
    {
        public static string _notetext = "";

        public static string notetext
        {
            get { return _notetext; }
            set { _notetext = value; }
        }
    }

}
