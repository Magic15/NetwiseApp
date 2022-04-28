using NetwiseApp.Consts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwiseApp.Helpers
{
    public class CatHelper
    {
        private CatClient _catClient;
        public CatHelper()
        {
            _catClient = new CatClient(ApiUrl.CatFactsApiUrl);
        }

        public GetAndSaveCatFactToFile(string path)
        {
            /*
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.Append("Some line of text");
            //File.AppendAllText(_filePath, stringbuilder.ToString());
            FileHelper fileHelper = new FileHelper(path);
            //CatClient
            */
        }
    }
}
