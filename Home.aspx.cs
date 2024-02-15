using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PreventiviAuto
{
    public partial class Home : System.Web.UI.Page
    {
        public static List<string> listaOptional=new List<string>();
        public List<int> prezzoOptional=new List<int>();    
        public static string nomeModello;
        public string nomeOptional;
        public static int totale;
        public static int garanzia;
        static string connectionString = ConfigurationManager.ConnectionStrings["Modello"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT NomeModello FROM ModelloAuto", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string modello = reader["NomeModello"].ToString();
                DropDownList1.Items.Add(modello);
                
            }
            conn.Close();
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT NomeOptional,PrezzoOptional FROM Optional", conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string optional = reader2["NomeOptional"].ToString();
                DropDownList2.Items.Add(optional);
            }
            conn.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            nomeModello = DropDownList1.SelectedItem.Text;
            DropDownList1.Enabled = false;
            SqlCommand cmd = new SqlCommand($"SELECT * FROM ModelloAuto WHERE NomeModello='{nomeModello}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) 
            {
                lblModello.Text=nomeModello;
                lblMarca.Text = reader["Marca"].ToString();
            }
            conn.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            nomeOptional = DropDownList2.SelectedItem.Text;
            listaOptional.Add(nomeOptional);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Optional WHERE NomeOptional='{nomeOptional}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) 
            {
                
                BulletedList1.Items.Add(nomeOptional + " Prezzo:" + reader["PrezzoOptional"].ToString());
                totale += Convert.ToInt32(reader["PrezzoOptional"]);
                lblTotale.Text = totale.ToString();
            }
            conn.Close();   
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO Preventivo (AnniGaranzia, TotalePreventivo) VALUES ({RadioButtonList1.SelectedItem.Value}, {totale}); SELECT SCOPE_IDENTITY()", conn);
            int idPreventivo = Convert.ToInt32(cmd.ExecuteScalar());

            foreach (string elemento in listaOptional)
            {
                Response.Write(nomeModello);
                SqlCommand cmd2 = new SqlCommand($"INSERT INTO ModelloAuto_Optional (NomeModello, NomeOptional, idPreventivo) VALUES ('{nomeModello}', '{elemento}', '{idPreventivo}')", conn);
                cmd2.ExecuteNonQuery();
            }
            conn.Close();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            totale -= garanzia;
            garanzia = 120 * int.Parse(RadioButtonList1.SelectedItem.Value);
            totale += garanzia;
            lblTotale.Text = totale.ToString();
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Preventivo WHERE NomeOptional='{nomeOptional}'", conn);
        }
    }
}