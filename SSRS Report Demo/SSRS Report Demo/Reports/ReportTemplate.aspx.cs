using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSRS_Report_Demo.Reports
{
    public partial class ReportTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    String reportFolder = System.Configuration.ConfigurationManager.AppSettings["SSRSReportsFolder"].ToString();

                    rvSiteMapping.Height = Unit.Pixel(Convert.ToInt32(Request["Height"]) - 58);
                    rvSiteMapping.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    rvSiteMapping.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer");
                    rvSiteMapping.ServerReport.ReportPath = String.Format("/{0}/{1}", reportFolder, Request["ReportName"].ToString());

                    List<ReportParameter> parameters = new List<ReportParameter>();
                    parameters.Add(new ReportParameter("NextValue", "0"));
                    rvSiteMapping.ServerReport.SetParameters(parameters);
                    rvSiteMapping.ShowParameterPrompts = false;
                    rvSiteMapping.ShowPromptAreaButton = false;
                    rvSiteMapping.ServerReport.Refresh();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}