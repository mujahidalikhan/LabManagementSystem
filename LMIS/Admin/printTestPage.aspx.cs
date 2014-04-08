using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;


namespace LMIS.Admin
{
    public partial class printTestPage : System.Web.UI.Page
    {
        protected override void Render(HtmlTextWriter writer)
        {
            MemoryStream mem = new MemoryStream();
            StreamWriter twr = new StreamWriter(mem);
            HtmlTextWriter myWriter = new HtmlTextWriter(twr);
            base.Render(myWriter);
            myWriter.Flush();
            myWriter.Dispose();
            StreamReader strmRdr = new StreamReader(mem);
            strmRdr.BaseStream.Position = 0;
            string pageContent = strmRdr.ReadToEnd();
            strmRdr.Dispose();
            mem.Dispose();
            writer.Write(pageContent);
            CreatePDFDocument(pageContent);


        }

        public void CreatePDFDocument(string strHtml)
        {




        }

        public void ShowPdf(string strFileName)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
            Response.ContentType = "application/pdf";
            Response.WriteFile(strFileName);
            Response.Flush();
            Response.Clear();
        }
    }
}