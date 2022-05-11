using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlDataAdapter = MySql.Data.MySqlClient.MySqlDataAdapter;


namespace ASP.Eploie.sql
{
  
    public partial class Index : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlConnection con;
        private object GridVi;

        public object GridView1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!Page.IsPostBack)
            {
                DropDownListPosition.Items.Add(new ListItem("Select the position"));
                DropDownListPosition.Items.Add(new ListItem("WebDeveloper"));
                DropDownListPosition.Items.Add(new ListItem("Assistance WebDeveloper"));
                DropDownListPosition.Items.Add(new ListItem("Programmer"));
                DropDownListPosition.Items.Add(new ListItem("Other"));
                DropDownListPosition.SelectedIndex = 0;
                DropDownListengime.Items.Add(new ListItem("Select Engine"));
                DropDownListengime.Items.Add(new ListItem("Linkedin"));
                DropDownListengime.Items.Add(new ListItem("Jobboon"));
                DropDownListengime.Items.Add(new ListItem("Indeed"));
                DropDownListengime.Items.Add(new ListItem("Emploie Quebec"));
                DropDownListengime.Items.Add(new ListItem("Other"));
                DropDownListengime.SelectedIndex = 0;

            }
        }
        void Cleare()
        {

            TextBoxcompany.Text = TextBoxdate.Text = TextBoxresult.Text = "";
            DropDownListPosition.SelectedIndex = 0;
            DropDownListengime.SelectedIndex = 0;

            Buttonsave.Text = "Save";
        }

        protected void TextBoxcompany_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            Cleare();
        }

        protected void Buttonsave_Click(object sender, EventArgs e)
        {

        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        protected void ButtonClear_Click1(object sender, EventArgs e)
        {
            Cleare();
        }

        protected void Buttonsave_Click1(object sender, EventArgs e)
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=emploie; password=SYSTEM;");
            con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT into  emploie.new_table( companie, post, engine, date, result)" +
                " Values(@companie, @post, @engine, @date, @result)", con);
            cmd.Parameters.AddWithValue("@companie", TextBoxcompany.Text);
            cmd.Parameters.AddWithValue("@post", DropDownListPosition.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@engine", DropDownListengime.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@date", TextBoxdate.Text);
            cmd.Parameters.AddWithValue("@result", TextBoxresult.Text);
            cmd.ExecuteNonQuery();
            Response.Write("<Script language 'javascript'>alert('Data successfuly insert in database')</script>");
            con.Close();
        }
        void Grid()
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=emploie; password=SYSTEM;");
            cmd = new MySql.Data.MySqlClient.MySqlCommand("Select * from emploie.new_table ", con);
            MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            cmd.Connection = con;
            con.Open();
            mySqlDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            GridV.DataSource = dataTable;
            GridV.DataBind();
            con.Close();




        }

        protected void Buttonshow_Click(object sender, EventArgs e)
        {
            Grid();
        }
        void Delete()
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=emploie; password=SYSTEM;");
            con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("Delete from emploie.new_table   where companie='" + TextBoxcompany.Text + "'", con);
            cmd.ExecuteNonQuery();
            Response.Write("<Script language 'javascript'>  alert('Data successfully deleted in data base')</Script>");
            con.Close();

        }

        protected void Buttondelet_Click(object sender, EventArgs e)
        {
            Delete();
        }
        void Search()
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=emploie; password=SYSTEM;");
           
            cmd = new MySql.Data.MySqlClient.MySqlCommand("Select * from emploie.new_table   where companie='" + TextBoxcompany.Text + "'", con);
            MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            cmd.Connection = con;
            con.Open();
            mySqlDataAdapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@companie", TextBoxcompany.Text);
            DataTable data1 = new DataTable();
            mySqlDataAdapter.Fill(data1);
            GridV.DataSource = data1;
            GridV.DataBind();
            con.Close();

        }

        protected void Buttonsearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void GridV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int c = 0;
        protected void GridV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                c++;
                DateTime dt;
                if(DateTime.TryParse(e.Row.Cells[4].Text, out dt))
                {
                    if (dt < DateTime.Now)
                    {
                        e.Row.BackColor = Color.AliceBlue;
                    }

                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = string.Format("Total of items=", c);
                e.Row.Cells[1].Text = string.Format("{0}", c);
            }

        }
       void Updatea()
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=emploie; password=SYSTEM;");

            cmd = new MySql.Data.MySqlClient.MySqlCommand("UpDate emploie.new_table set result='" + TextBoxresult.Text + "' where companie='" + TextBoxcompany.Text + "'", con);
            MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<Script language 'javascript'>  alert('Data successfully UpDated in data base')</Script>");
            con.Close();
           

        }

        protected void Buttonuodate_Click(object sender, EventArgs e)
        {

            Updatea();
        }
    }

    internal class DataTable : System.Data.DataTable
    {
    }
}