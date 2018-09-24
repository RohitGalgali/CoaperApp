using System;
using System.Windows.Forms;
using CoAP;
using PeterO.Cbor;
using LinkFormatParser;
using System.Net;

namespace CoaperApp
{
    public partial class CoaperFinder : Form
    {
        public CoaperFinder()
        {
            InitializeComponent();
        }

        public CBORObject CborModel { get; set; }

        public IPAddress UserIPAddress { get; set; }

        public string URIValue { get; set; }

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
                    req.URI = new Uri("coap://" + addr.ToString() + ":5683/.well-known/core");
                    req.Respond += DiscoveryResponseRecieved;
                    req.ContentType = 0;
                    req.ContentFormat = 0;
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
            if (string.IsNullOrEmpty(AddressBarTextBox.Text) && UserIPAddress != null)
            {
                MessageBox.Show("Enter Address");
                return;
            }
            else
            {
                //IPAddress addr = ParseIPAddress(AddressBarTextBox.Text);
                //if (addr != null)
                //{
                   // UserIPAddress = addr;
                    Request req = new Request(Method.GET, true);
                    req.URI = new Uri("coap://" + AddressBarTextBox.Text.TrimEnd('/'));
                    req.Respond += ResponseRecieved;
                   
                    req.Send();
                //}
                //else
                //{
                //    MessageBox.Show("Invalid Address");
                //}
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
        }

        private void CoapTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            URIValue = e.Node.FullPath;
            AddressBarTextBox.Text = UserIPAddress + ":5683/" + URIValue;
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
