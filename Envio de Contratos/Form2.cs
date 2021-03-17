using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Envio_de_Contratos
{
   public partial class Form2 : Form
   {
      public Form2()
      {
         InitializeComponent();
      }

      private void Form2_Load(object sender, EventArgs e)
      {
         DatabaseProviderFactory factory = new DatabaseProviderFactory();
       
         Database database = factory.Create("SQLExpress");
         DataTable dataTable = database.ExecuteDataSet("uSPGetPersonByID", 1).Tables[0];
         
      }
   }
}
