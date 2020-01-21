using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;
namespace AndroidWebView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        WebView webView;
        EditText txtURL;
        Button btnLoad;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.SetWebViewClient(new WebViewClient());
            WebSettings webSettings = webView.Settings;
            webSettings.JavaScriptEnabled = true;
            txtURL = FindViewById<EditText>(Resource.Id.txtUrl);
            btnLoad = FindViewById<Button>(Resource.Id.btnAccess);


            btnLoad.Click += (s, e)=>{
                if (!txtURL.Text.Contains("http://"))
                {
                    string adress = txtURL.Text;
                    txtURL.Text = string.Format("http://{0}", adress);
                }

                webView.LoadUrl(txtURL.Text);
              };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}