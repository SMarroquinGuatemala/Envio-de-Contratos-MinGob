using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdentityModel.Client;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Envio_de_Contratos
{
   public partial class Form1 : Form
   {
      public  string Empresa { get; set; } = null;
      public  string Planilla { get; set; } = null;
      public  string Puesto { get; set; } = null;
      public  string NumeroDeEmpleado { get; set; } = null;
      public  DateTime? FechaInicial { get; set; } = null;
      public  DateTime? FechaFinal { get; set; } = null;
      public  string NombreEmpleado { get; set; } = null;

      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {      
         try
         {            
            CboEmpresas.Fill();
            cboPlanillas.Fill();
            cboPuesto.Fill();
            //txtNumeroDeEmpleado.Text = "04895";
         }
         catch (Exception ex)
         {
            throw ex;
         }      
      }

      private  static async Task Main( string dpiFirmantePatrono, string razonSocialPatrono, string nombreFirmantePatrono, string calidadFirmanteLegalPatrono, string salario,
                                       string jornada, string actividadEconomica, string formaPago, string plazo, string FechaInicioRelacion,  string fechafin, string horasTiempoParcial, string tarifaTiempoParcial,
                                       string jornadaTiempoParcial, string nombreEmpleado,string dpiEmpleado, string edadEmpleado, string sexoEmpleado, string NumeroDeEmpleado )
         {
            try
            {
          
            /*Esta Ruta será la que devuelve el token de autenticación del usuario.*/
            //string vRutaToken = "https://servicios.mintrabajo.gob.gt:5001";  Desarrollo
            string vRutaToken = "https://sso.mintrabajo.gob.gt"; 
              
            var client = new HttpClient();
               
            var disco = await client.GetDiscoveryDocumentAsync(vRutaToken);

  
            if (disco.IsError)
             
            {
            
               MessageBox.Show("Error al leer url " + disco.Error);
               
               return;
               
            }
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
               Address = disco.TokenEndpoint,
               /*usuario y contraseña para pruebas, se debe cambiar las que tiene asignadas en estas variables.*/
               ClientId = "usrextb68f1",
               ClientSecret = "m*R9!T6MAay#%kTP",
               Scope = "api2"
            });

            if (tokenResponse.IsError)
            {
               MessageBox.Show("Error al ingresar credenciales" + tokenResponse.Error);
               return;
            }
            //Muestro en consola el token generado para el usuario.
            //Console.WriteLine(tokenResponse.Json.GetValue("access_token"));
            //Console.WriteLine("\n\n");
            /*vRutaPost será la ruta que se asigna para realizar el post con los datos del contrato y empleado para la grabación y revuelve jSon con el ticket.*/
            string vRutaPost = "https://recit.mintrabajo.gob.gt/api/contratos/1.0/contratos";
            var cliente = new RestClient(vRutaPost);
            cliente.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + tokenResponse.Json.GetValue("access_token"));
            request.AddHeader("header", "application/json");
            /*Todos los datos agregados como parametos son puramente de ejemplo, deben de colocarse los reales*/
            // request.AddParameter("dpiFirmantePatrono", "1234567893214");
            request.AddParameter("dpiFirmantePatrono", dpiFirmantePatrono);
            // request.AddParameter("razonSocialPatrono", "Sucursal Perez");
            request.AddParameter("razonSocialPatrono", razonSocialPatrono);
            //request.AddParameter("nombreFirmantePatrono", "Firmante Perez Lopez");
            request.AddParameter("nombreFirmantePatrono", nombreFirmantePatrono);
            //request.AddParameter("calidadFirmanteLegalPatrono", "Representante");
            request.AddParameter("calidadFirmanteLegalPatrono", calidadFirmanteLegalPatrono);
            //request.AddParameter("salario", "125.00");
            request.AddParameter("salario", salario);
            //request.AddParameter("jornada", "[1]");
            request.AddParameter("jornada", "[" + jornada + "]");
            
            //request.AddParameter("actividadEconomica", "3");
            request.AddParameter("actividadEconomica", actividadEconomica);
            //request.AddParameter("formaPago", "2");
            request.AddParameter("formaPago", formaPago);
            //request.AddParameter("plazo", "1");
            request.AddParameter("plazo", plazo);
            //request.AddParameter("FechaInicioRelacion", "12/10/2025");
            request.AddParameter("FechaInicioRelacion",   Convert.ToDateTime(FechaInicioRelacion).Date.ToString("yyyy/MM/dd"));
            //request.AddParameter("fechafin", "12/10/2025");
          
            if (string.IsNullOrEmpty(fechafin))
            {
                request.AddParameter("fechaFin", "");
            }
            else
            {
                request.AddParameter("fechaFin",Convert.ToDateTime(fechafin).Date.ToString("yyyy/MM/dd"));
            }
          
            //request.AddParameter("horasTiempoParcial", "150");
            request.AddParameter("horasTiempoParcial", horasTiempoParcial);
            request.AddParameter("tarifaTiempoParcial", "0.00");
            //request.AddParameter("tarifaTiempoParcial",tarifaTiempoParcial);
            //request.AddParameter("jornadaTiempoParcial", "2");
            request.AddParameter("jornadaTiempoParcial", jornadaTiempoParcial.ToString());
            //request.AddParameter("nombreEmpleado", "Peter Mauricio Raminez");
            request.AddParameter("nombreEmpleado", nombreEmpleado);
            //request.AddParameter("dpiEmpleado", "1610146581102");
            request.AddParameter("dpiEmpleado", dpiEmpleado);
            //request.AddParameter("edadEmpleado", "50");
            request.AddParameter("edadEmpleado", edadEmpleado);
            request.AddParameter("nacionalidadEmpleado", "109");
            //request.AddParameter("sexoEmpleado", "H");
            request.AddParameter("sexoEmpleado", sexoEmpleado);
            /**
             * Para el Archivo se debe de colocar la ruta del archivo pdf
             * y en el AddFile en lugar de "archivo.pdf" colocar el nombre del archivo a cargar.
             **/
            if (!System.IO.File.Exists(@"\\nastrfca1\ListadoDeContrataciones\ContratosLaborales\" + NumeroDeEmpleado + ".pdf"))
            {
               MessageBox.Show("El archivo no existe en la carpeta de contratos. Numero de Empleado:" + NumeroDeEmpleado);
               return;
            }
            byte[] data = System.IO.File.ReadAllBytes(@"\\nastrfca1\ListadoDeContrataciones\ContratosLaborales\" + NumeroDeEmpleado + ".pdf");
            ByteArrayContent bytes = new ByteArrayContent(data);

            request.AddFile("file", data, NumeroDeEmpleado + ".pdf", "application/pdf");

            IRestResponse response = cliente.Execute(request);
            if (response.StatusCode.ToString().ToUpper() == "OK")
            {
               /*Recibo y muestro en formato json la respuesta del servidor, en este se muestra el parametro ticket */
               //Console.WriteLine(JArray.Parse(response.Content));
               //List<ResultMinGob> list = new List<ResultMinGob>();
               //list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultMinGob>>(response.Content);
               ResultMinGob resultMinGob = JsonConvert.DeserializeObject<ResultMinGob>(response.Content);
               /*Para obtener el PDF de la constancia transitoria se utiliza la ruta */
               DatabaseProviderFactory factory = new DatabaseProviderFactory();
               // Create a Database object from the factory using the connection string name.
               Database namedDB = factory.Create("Produccion");

               string sql = "insert TblPersonalNumeroDeContrato(NumeroDeEmpleado,FechaDeIngreso,Ticket) values (@PNumeroDeEmpleado,@PFechaDeIngreso,@PTicket)";
               System.Data.Common.DbCommand dbCommand = namedDB.GetSqlStringCommand(sql);
               namedDB.AddInParameter(dbCommand, "PNumeroDeEmpleado", System.Data.DbType.String, NumeroDeEmpleado);
               namedDB.AddInParameter(dbCommand, "PFechaDeIngreso", System.Data.DbType.Date, Convert.ToDateTime(FechaInicioRelacion).Date.ToShortDateString());
               namedDB.AddInParameter(dbCommand, "PTicket", System.Data.DbType.Int64, resultMinGob.ticket);
               namedDB.ExecuteNonQuery(dbCommand);
               string vRutaConstancia =string.Concat("https://recit.mintrabajo.gob.gt/api/contratos/", resultMinGob.ticket.ToString() , "/adjuntos/ConstanciaTransitoria.pdf");
               WebClient webClient = new WebClient();             
               webClient.DownloadFileAsync(new Uri(vRutaConstancia), string.Concat( @"\\NASTRFCA1\ArchivosAdjuntosSistemas\ContratosConstanciaTransitoria\", NumeroDeEmpleado ,"_", resultMinGob.ticket.ToString() , " .pdf"));
               //Inserto Constancias Transitorias
               sql = null;
               sql = "insert DbArchivosAdjuntos.dbo.TblArchivosAdjuntos(Correlativo,Clase,Referencia,TipoDeArchivo,Nombre,Descripcion,Extension,Ruta) values (@PCorrelativo,@PClase,@PReferencia,@PTipoDeArchivo,@PNombre,@PDescripcion,@PExtension,@PRuta)";
               dbCommand = null;
               dbCommand = namedDB.GetSqlStringCommand(sql);
               namedDB.AddInParameter(dbCommand, "PCorrelativo", System.Data.DbType.Int64, resultMinGob.ticket.ToString());
               namedDB.AddInParameter(dbCommand, "PClase", System.Data.DbType.String, "48");
               namedDB.AddInParameter(dbCommand, "PReferencia", System.Data.DbType.String, NumeroDeEmpleado);
               namedDB.AddInParameter(dbCommand, "PTipoDeArchivo", System.Data.DbType.String, "0");   
               namedDB.AddInParameter(dbCommand, "PNombre", System.Data.DbType.String, NumeroDeEmpleado + "_" + resultMinGob.ticket.ToString());
               namedDB.AddInParameter(dbCommand, "PDescripcion", System.Data.DbType.String, vRutaConstancia);
               namedDB.AddInParameter(dbCommand, "PExtension", System.Data.DbType.String, "pdf");
               namedDB.AddInParameter(dbCommand, "PRuta", System.Data.DbType.String, string.Concat( @"\ContratosConstanciaTransitoria\" , NumeroDeEmpleado , "_" + resultMinGob.ticket.ToString()));
               namedDB.ExecuteNonQuery(dbCommand);
               
               vRutaConstancia = string.Empty;
               vRutaConstancia = string.Concat("https://recit.mintrabajo.gob.gt/api/contratos/", resultMinGob.ticket.ToString(), "/adjuntos/ConstanciaDefinitiva.pdf");
               webClient = new WebClient();
               webClient.DownloadFileAsync(new Uri(vRutaConstancia), string.Concat(@"\\NASTRFCA1\ArchivosAdjuntosSistemas\ContratosConstanciaDefinitiva\", NumeroDeEmpleado, "_", resultMinGob.ticket.ToString(), " .pdf"));
               //Inserto Constancias Definitivas
               sql = null;
               sql = "insert DbArchivosAdjuntos.dbo.TblArchivosAdjuntos(Correlativo,Clase,Referencia,TipoDeArchivo,Nombre,Descripcion,Extension,Ruta) values (@PCorrelativo,@PClase,@PReferencia,@PTipoDeArchivo,@PNombre,@PDescripcion,@PExtension,@PRuta)";
               dbCommand = null;
               dbCommand = namedDB.GetSqlStringCommand(sql);
               namedDB.AddInParameter(dbCommand, "PCorrelativo", System.Data.DbType.Int64, resultMinGob.ticket.ToString());
               namedDB.AddInParameter(dbCommand, "PClase", System.Data.DbType.String, "50");
               namedDB.AddInParameter(dbCommand, "PReferencia", System.Data.DbType.String, NumeroDeEmpleado);
               namedDB.AddInParameter(dbCommand, "PTipoDeArchivo", System.Data.DbType.String, "0");
               namedDB.AddInParameter(dbCommand, "PNombre", System.Data.DbType.String, NumeroDeEmpleado + "_" + resultMinGob.ticket.ToString());
               namedDB.AddInParameter(dbCommand, "PDescripcion", System.Data.DbType.String, vRutaConstancia);
               namedDB.AddInParameter(dbCommand, "PExtension", System.Data.DbType.String, "pdf");
               namedDB.AddInParameter(dbCommand, "PRuta", System.Data.DbType.String, string.Concat(@"\ContratosConstanciaDefinitiva\", NumeroDeEmpleado, "_" + resultMinGob.ticket.ToString()));
               namedDB.ExecuteNonQuery(dbCommand);

               MessageBox.Show("Contratos enviados correctamente");
            }
            else
            {
               MessageBox.Show("Error en el envio de contratos " + response.Content.ToString());
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error WS " + ex.Message);
         }
        

      }

      private void btnBuscar_Click(object sender, EventArgs e)
      {
         Busqueda();
         lblRegistros.Text = grdDatos.Rows.Count.ToString();
     }

      public    void Busqueda()
      {
         try
         {
            Empresa = null;
            if (!String.IsNullOrEmpty(CboEmpresas.SelectedValue.ToString()))
            {
               Empresa = CboEmpresas.SelectedValue.ToString();
            }

            Planilla = null;
            if (!String.IsNullOrEmpty(cboPlanillas.SelectedValue.ToString()))
            {
               Planilla = cboPlanillas.SelectedValue.ToString();
            }

            Puesto = null;
            if (!String.IsNullOrEmpty(cboPuesto.SelectedValue.ToString()))
            {
               Puesto = cboPuesto.SelectedValue.ToString();
            }

            NumeroDeEmpleado = null;
            if (!String.IsNullOrEmpty(txtNumeroDeEmpleado.Text))
            {
               NumeroDeEmpleado = txtNumeroDeEmpleado.Text;
            }

            FechaInicial = null;
            if (!String.IsNullOrEmpty(txtFechaInicialIngreso.ToString()))
            {
               FechaInicial = Convert.ToDateTime(txtFechaInicialIngreso.ToString());
            }

            FechaFinal = null;
            if (!String.IsNullOrEmpty(txtFechaFinalIngreso.ToString()))
            {
               FechaFinal = Convert.ToDateTime(txtFechaFinalIngreso.ToString());
            }

            NombreEmpleado = null;
            if (!String.IsNullOrEmpty(txtNombreEmpleado.Text))
            {
               NombreEmpleado = txtNombreEmpleado.Text;
            }


            // Configure the DatabaseFactory to read its configuration from the .config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            // Create a Database object from the factory using the connection string name.
            Database namedDB = factory.Create("Produccion");

            grdDatos.DataSource = namedDB.ExecuteDataSet("UPSContratosMinGob", Empresa, Planilla, Puesto, NumeroDeEmpleado, FechaInicial, FechaFinal, NombreEmpleado).Tables[0];
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error: " + ex.Message);
         }
      }

      private void MnuEnviarContrato_Click(object sender, EventArgs e)
      {
         try
         {
            this.Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow item in grdDatos.SelectedRows)
            {
               if (item.Cells["jornadaColumn"].Value.ToString() == "")
               {
                  MessageBox.Show("No existe jornada para el contrato." + Environment.NewLine + "Numero de Empleado: " + item.Cells["NumeroDeEmpleadoColumn"].Value.ToString());
               }
               else
               {
                  Main(item.Cells["DPIFirmantePatronoColumn"].Value.ToString(),
                          item.Cells["razonSocialPatronoColumn"].Value.ToString(),
                          item.Cells["nombreFirmantePatronoColumn"].Value.ToString(),
                          item.Cells["calidadFirmanteLegalPatronoColumn"].Value.ToString(),
                          item.Cells["SalarioColumn"].Value.ToString(),
                          item.Cells["jornadaColumn"].Value.ToString(),
                          item.Cells["actividadEconomicaColumn"].Value.ToString(),
                          item.Cells["formaPagoColumn"].Value.ToString(),
                          item.Cells["plazoColumn"].Value.ToString(),
                          item.Cells["fechaInicioRelacionColumn"].Value.ToString(),
                          item.Cells["fechaFinColumn"].Value.ToString(),
                          item.Cells["horasTiempoParcialColumn"].Value.ToString(),
                          item.Cells["tarifaTiempoParcialColumn1"].Value.ToString(),
                          item.Cells["jornadaTiempoParcialColumn"].Value.ToString(),
                          item.Cells["nombreEmpleadoColumn"].Value.ToString(),
                          item.Cells["dpiEmpleadoColumn"].Value.ToString(),
                          item.Cells["edadEmpleadoColumn"].Value.ToString(),
                          item.Cells["sexoEmpleadoColumn"].Value.ToString(),
                          item.Cells["NumeroDeEmpleadoColumn"].Value.ToString());
               }

            }

            Busqueda();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error: " + ex.Message);
         }
         finally
         {
            this.Cursor = Cursors.Default;
         }

      }

      private void button1_Click(object sender, EventArgs e)
      {
         Form form = new Form2();
         form.Show();

      }
   }
}

public class ResultMinGob
{
   public int section { get; set; }
   public string author { get; set; }
   public object assigned { get; set; }
   public int activity { get; set; }
   public string isFollowing { get; set; }
   public object onProcess { get; set; }
   public int ticket { get; set; }
   public int thread { get; set; }
   public string processInitials { get; set; }
   public string processName { get; set; }
   public object processStyle { get; set; }
   public string activityName { get; set; }
   public object referenceID { get; set; }
   public object referenceDescription { get; set; }
   public DateTime postedOn { get; set; }
   public string postedBy { get; set; }
   public DateTime ticketStartedOn { get; set; }
   public string ended { get; set; }
   public object ticketEndedOn { get; set; }
   public object priorityName { get; set; }
   public object priorityStyle { get; set; }
   public string ticketTime { get; set; }
   public double ticketTimeSeconds { get; set; }
   public double ticketTimeMS { get; set; }
   public DateTime dataTimeStamp { get; set; }
   public bool stopWatchState { get; set; }
   public int milliSeconds { get; set; }
   public int seconds { get; set; }
   public int processOwner { get; set; }
   public int priority { get; set; }
}



