using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWebsite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MoviesXML.DocumentContent = File.ReadAllText(Server.MapPath("Movies.xml"));
            MoviesXML.TransformSource = Server.MapPath("Movies.xslt");
        }
    }
}