using Supreme.Core;
using System;
using System.IO;
using System.Net;

namespace Supreme.ViewModel
{
    public abstract class BaseViewModel : NotifyModel, IDisposable
    {
        #region Constructor

        //public BaseViewModel(string displayName, bool isDialog)
        //    : base()
        //{
        //    if (displayName != null && displayName.Length > 30)
        //    {
        //        DisplayName = displayName.Substring(0, 27) + "...";
        //    }
        //    else
        //    {
        //        DisplayName = displayName;
        //    }
        //    IsDialog = isDialog;
        //}

        #endregion Constructor

        #region Property

        private string _displayName;
        public string DisplayName { get { return _displayName; } protected set { if (_displayName != value) { _displayName = value; NotifyPropertyChanged(); } } }

        public bool IsDialog { get; private set; }

        private int _SelectedIndex;
        public int SelectedIndex { get { return _SelectedIndex; } set { if (_SelectedIndex != value) { _SelectedIndex = value; NotifyPropertyChanged(); NotifySelectedIndexChanged(); } } }

        private bool? _DialogResult;
        public bool? DialogResult { get { return _DialogResult; } protected set { if (_DialogResult != value) { _DialogResult = value; NotifyPropertyChanged(); } } }

        #endregion Property

        #region Event

        public event EventHandler CloseRequested;
        protected void NotifyCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SelectedIndexChanged;
        protected void NotifySelectedIndexChanged()
        {
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion




        #region Command


        #endregion Command

        #region Method

        internal virtual string DownloadHtml(string urlAddress)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = "";
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(response.CharacterSet));
                    }

                    data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();
                }
                return data;
            }
            catch(Exception e)
            {
                return "";
            }
           
        }



        public virtual void Dispose()
        {

        }

        #endregion Method
    }
}
