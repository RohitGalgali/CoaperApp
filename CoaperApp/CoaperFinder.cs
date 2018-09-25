using System;
using System.Windows.Forms;
using CoAP;
using PeterO.Cbor;
using LinkFormatParser;
using System.Net;
using System.Text;

namespace CoaperApp
{
    public partial class CoaperFinder : Form
    {
        public CoaperFinder()
        {
            InitializeComponent();

            PortTextBox.Text = PortNumber.ToString();

            UriTextBox.Text = URIValue;
        }

        public CBORObject CborModel { get; set; }

        public IPAddress UserIPAddress { get; set; }

        private string _UriValue = "/.well-known/core";
        public string URIValue { get { return _UriValue.TrimEnd('/'); } set { _UriValue = value; } } 

        public int PortNumber { get; set; } = 5683;

        private void DiscoverButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddressBarTextBox.Text))
            {
                MessageBox.Show("Enter Address");
                return;
            }
            else
            {
                IPAddress addr = ParseIPAddress(AddressBarTextBox.Text);
                if (addr != null)
                {
                    UserIPAddress = addr;
                    Request req = new Request(Method.GET, true);
                    req.URI = new Uri("coap://" + addr.ToString() + ":" + PortNumber + URIValue);
                    req.Respond += DiscoveryResponseRecieved;
                    req.Send();
                }
                else
                {
                    MessageBox.Show("Invalid Address");
                }
            }
        }

        private void DiscoveryResponseRecieved(object sender, ResponseEventArgs e)
        {
            LinkCollection collection = new LinkCollection(e.Response.PayloadString);

            BeginInvoke(new Action(() => GetTreeViewFromCollection(CoapTreeView, collection)));

        }

        private void GetTreeViewFromCollection(TreeView view, LinkCollection collection)
        {
            view.Nodes.Clear();
            foreach (var link in collection)
            {
                view.Nodes.Add(link.Uri);
            }
        }


        private void GetButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddressBarTextBox.Text))
            {
                MessageBox.Show("Enter Address");
                return;
            }
            else
            {
                IPAddress addr = ParseIPAddress(AddressBarTextBox.Text);
                if (addr != null)
                {
                    UserIPAddress = addr;
                    Request req = new Request(Method.GET, true);
                    req.URI = new Uri("coap://" + addr.ToString() + ":" + PortNumber.ToString() + PadUri(URIValue));
                    req.Respond += ResponseRecieved;
                    req.Send();
                }
                else
                {
                    MessageBox.Show("Invalid Address");
                }
            }
        }

        private string PadUri(string uRIValue)
        {
            if (uRIValue.StartsWith("/"))
            {
                return uRIValue;
            }
            else
            {
                string val = uRIValue.PadLeft(uRIValue.Length + 1, '/');
                return val;
            }
        }

        private void ResponseRecieved(object sender, ResponseEventArgs e)
        {
            if (e.Response.ContentType == 60) // 60 -> cbor
            {
                try
                {
                    CborModel = CBORObject.DecodeFromBytes(e.Response.Payload);
                }
                catch (PeterO.Cbor.CBORException)
                {
                    //Take some action    
                }
                BeginInvoke(new Action(() => PayloadDataTextBox.Text = CborModel.ToJSONString()));

            }
            else if (e.Response.ContentType == 0) // 0 - text/plain
            {
                BeginInvoke(new Action(() => PayloadDataTextBox.Text = e.Response.Payload.ToString()));
            }

            else if(e.Response.ContentType == 40)
            {
                LinkCollection collection = new LinkCollection(e.Response.PayloadString);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in collection)
                {
                    stringBuilder.AppendLine(item.Uri);
                    
                }
                BeginInvoke(new Action(() => PayloadDataTextBox.Text = stringBuilder.ToString()));
            }

        }

        private void CoapTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            URIValue = e.Node.FullPath;
            UriTextBox.Text = URIValue;
        }
        private static IPAddress ParseIPAddress(string address)
        {
            IPAddress addr;
            if(IPAddress.TryParse(address, out addr))
            {
                return addr;
            }
            else
            {
                return null;
            }
            
        }

    }
}
