using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using log4net;
using CodeStudio;
using System.IO;

namespace YiJingWebUI.Api
{
	/// <summary>
	/// Summary description for saveimgs
	/// </summary>
	public class ImageSaver : IHttpHandler
	{
		private ILog log = LogManager.GetLogger( typeof( ImageSaver ) );

		public void ProcessRequest( HttpContext context ) {
			context.Response.ContentType = "text/plain";

			string token = context.Request["token"];
			HttpPostedFile file = context.Request.Files[0];

			log.DebugFormat( "ImageSaver entry and token is: {0}", token );

			//string timestamp = "";
			if ( !token.Equals( ConfigToken, StringComparison.Ordinal ) ) {
				log.Debug( "invalid token" );
				context.Response.Write( "invalid token" );
				return;
			}
			else if ( context.Request.Files.Count == 0 || file.ContentLength == 0 || file.FileName.Length == 0 ) {
				log.Debug( "no file" );
				context.Response.Write( "no file" );	// failed.
				return;
			}
			else if ( !CheckFileType( Media.GetFileType(file.InputStream) ) ) {
				log.Debug( "File type is not supported" );
				context.Response.Write( "File type is not supported" );
				return;
			}
			else if ( file.ContentLength > ( AllowedMaxImageSize * 1024 ) ) {
				log.Debug( "File is too large" );
				context.Response.Write( "File is too large" );
				return;
			}

			string fileNameForServer = MakeProperFileName( file.FileName );
			//string FileNameForErrorMessage = MakeFileNameForErrorMessage( file.FileName );
			string filePathForClient = String.Format( "/Uploads/Images/{0}/{1}{2}",
													  DateTime.Today.ToString( "yyyyMMdd" ),
													  new RandomEx().Next( 100000000, 999999999 ),
													  Path.GetExtension( file.FileName ) );
			string filePathForServer = context.Server.MapPath( filePathForClient );

			CodeStudio.IO.DirectoryEx.CycleCreateDirectory( Path.GetDirectoryName( filePathForServer ) );

			try {
				file.SaveAs( filePathForServer );
			}
			catch ( Exception ex) {
				log.Error( "Save file occurs a problem.", ex );
				context.Response.Write( "Save file occurs a problem." );
				return;
			}

			log.WarnFormat( "Upload successfully and path is: {0}", filePathForClient );
			context.Response.Write( "success|" + filePathForClient );
		}

		public bool IsReusable {
			get {
				return false;
			}
		}

		private string ConfigToken {
			get {
				return System.Configuration.ConfigurationManager.AppSettings["AppSecret"];
			}
		}

		private int AllowedMaxImageSize {
			get {
				return int.Parse(System.Configuration.ConfigurationManager.AppSettings["AllowedMaxImageSize"]);
			}
		}

		private bool CheckFileType( string ContentType ) {
			bool RetVal = false;
			RetVal = (
				ContentType == "image/jpeg" ||
				ContentType == "image/pjpeg" ||
				ContentType == "image/gif" ||
				ContentType == "image/png" ||
				ContentType == "image/x-png"
			);
			return RetVal;
		}

		public string MakeProperFileName( string FileName ) {
			int index = FileName.LastIndexOf( "\\" );
			string fileName = FileName;
			if ( index > 0 ) {
				fileName = fileName.Substring( index + 1, ( fileName.Length - 1 ) - index );
			}

			Regex rexAllowedChars = new Regex( @"[^0-9A-Z\._-]", RegexOptions.IgnoreCase );
			Match m = rexAllowedChars.Match( fileName );
			while ( m.Success ) {
				fileName = fileName.Replace( m.Value, string.Empty );
				m = rexAllowedChars.Match( fileName );
			}
			if ( fileName.Length > 250 ) {
				// Trim the name down to an acceptable length. 
				// Even though the max length is generally 255, We'll trim it on down to 250. No sense in pushing the limits. 
				// The worry with trimming it down more than that would be the increased likelyhood of name collisions.
				int StartIndex = fileName.Length - 250;
				int ChopLength = fileName.Length - ( fileName.Length - 250 );
				fileName = fileName.Substring( StartIndex, ChopLength );
			}
			if ( fileName.StartsWith( "." ) ) {
				Random Rand = new Random();
				string sRand = Rand.Next( 100000, 100000000 ).ToString();
				fileName = sRand + fileName;
			}
			return fileName;
		}
	}
}