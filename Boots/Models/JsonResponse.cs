using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boots.Models
{
    public class JsonResponse
    {
        public string FileName { get; set; }
        public string FileDownloadUri { get; set; }
        public string FileType { get; set; }
        public int Size { get; set; }
        public string BarcodeResult { get; set; }
        public string TextResult { get; set; }        
    }
}