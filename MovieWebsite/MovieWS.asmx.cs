using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;

namespace MovieWebsite
{
    /// <summary>
    /// Summary Synopsis for MovieWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MovieWS : System.Web.Services.WebService
    {

        //done
        [WebMethod]
        public void AddMovie(string Title, string Director, string Synopsis,
                int Id)
        {
            String filename = Path.Combine(HttpRuntime.AppDomainAppPath, "Movies.xml");
            XmlNode nodeTitle, nodeDirector, nodeSynopsis, nodeId;
            XmlDocument MovieDoc = new XmlDocument();
            MovieDoc.Load(filename);

            XmlNode root = MovieDoc.LastChild;
            XmlNode movies = MovieDoc.CreateElement("movie");
            root.AppendChild(movies);

            if (Title.Length > 0 && Director.Length > 0 && Synopsis.Length > 0 && Id >= 0)
            {
                nodeId = MovieDoc.CreateElement("Id");
                nodeId.InnerText = Id.ToString();
                movies.AppendChild(nodeId);

                nodeTitle = MovieDoc.CreateElement("title");
                nodeTitle.InnerText = Title;
                movies.AppendChild(nodeTitle);

                nodeDirector = MovieDoc.CreateElement("director");
                nodeDirector.InnerText = Director;
                movies.AppendChild(nodeDirector);

                nodeSynopsis = MovieDoc.CreateElement("synopsis");
                nodeSynopsis.InnerText = Synopsis;
                movies.AppendChild(nodeSynopsis);

                MovieDoc.Save(filename);
                Context.Response.StatusCode = 201;
            }
        }
        //done
        [WebMethod]
        public void GetDetails()
        {
            String filename = Path.Combine(HttpRuntime.AppDomainAppPath, "Movies.xml");
            XmlDocument MovieDoc = new XmlDocument();
            MovieDoc.Load(filename);
            XmlNode root = MovieDoc.LastChild;
            XmlNodeList Movie_menus = root.SelectNodes("movie");

            var MovieList = new List<Movie_class>();

            foreach (XmlNode n in Movie_menus)
            {
                var Movie_object = new Movie_class()
                {
                    Id = int.Parse(n.SelectSingleNode("Id").InnerText),
                    Director= n.SelectSingleNode("director").InnerText,
                    Title = n.SelectSingleNode("title").InnerText,
                    Synopsis = n.SelectSingleNode("synopsis").InnerText
                };

                MovieList.Add(Movie_object);
            }
            var result = new JavaScriptSerializer().Serialize(MovieList);
            Context.Response.Write(result);
        }

        //done
        [WebMethod]
        public void EditDetails(int Id, string New_Title, string New_Director, string New_Synopsis)
        {
            String fileName = Path.Combine(HttpRuntime.AppDomainAppPath, "Movies.xml");
            XmlDocument MovieDoc = new XmlDocument();
            MovieDoc.Load(fileName);
            XmlNode root = MovieDoc.LastChild;
            XmlNodeList Movie_menus = root.SelectNodes("movie");

            foreach (XmlNode n in Movie_menus)
            {
                if (n.SelectSingleNode("Id").InnerText == Id.ToString())
                {
                    n.SelectSingleNode("director").InnerText = New_Director;
                    n.SelectSingleNode("title").InnerText = New_Title;
                    n.SelectSingleNode("synopsis").InnerText = New_Synopsis;
                }
                MovieDoc.Save(fileName);
            }

        }

        //done
        [WebMethod]
        public void DeleteDetails(int Id)
        {
            String fileName = Path.Combine(HttpRuntime.AppDomainAppPath, "Movies.xml");
            XmlDocument MovieDoc = new XmlDocument();
            MovieDoc.Load(fileName);
            XmlNode root = MovieDoc.LastChild;
            XmlNodeList Movie_menus = root.SelectNodes("movie");

            foreach (XmlNode n in Movie_menus)
            {
                if (n.SelectSingleNode("Id").InnerText == Id.ToString())
                {
                    root.RemoveChild(n);
                }
                MovieDoc.Save(fileName);
            }
        }

    }
}