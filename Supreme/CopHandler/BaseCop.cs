
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Supreme.CopHandler
{
    public abstract class BaseCop
    {
        protected abstract string SiteName { get; set; }
        protected abstract string SiteProductList { get; set; }

        public void ProcessCop()
        {
            FindItem();
            Checkout();
            Payment();
            GetCopStatus();
        }

        public abstract void FindItem();
        public abstract void Checkout();
        public abstract void Payment();
        public abstract void GetCopStatus();

        public async Task<string> DownloadHtmlAsync(string SiteName)
        {
            try
            {
                var request = WebRequest.Create(SiteName);
                var response = await request.GetResponseAsync();
                string data = "";

                using (Stream receiveStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(receiveStream))
                    {
                        data = await readStream.ReadToEndAsync();

                        response.Close();
                        readStream.Close();
                    }
                }

                return data;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
