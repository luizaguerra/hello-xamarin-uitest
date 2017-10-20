using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloXamarinAndroid
{
    [Activity(Label = "Compras")]
    public class CompraActivity : Activity
    {
        double defaultValue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            
            SetContentView(Resource.Layout.Compra);

            EditText txtTotalPagarAgua = FindViewById<EditText>(Resource.Id.totalpagaragua);
            EditText txtTotalPagarRefri = FindViewById<EditText>(Resource.Id.totalpagarrefri);
            EditText txtTotalPagarBolo = FindViewById<EditText>(Resource.Id.totalpagarbolo);
            EditText txtTotalPagarBurger = FindViewById <EditText>(Resource.Id.totalpagarburger);
            EditText txtTotalCompra = FindViewById<EditText>(Resource.Id.totalcompra);

            {
                try
                {
                    txtTotalPagarAgua.Text = string.Format("{0:0.00}", Intent.GetDoubleExtra("TotalAgua", defaultValue));
                    txtTotalPagarRefri.Text = string.Format("{0:0.00}", Intent.GetDoubleExtra("TotalRefri", defaultValue));
                    txtTotalPagarBolo.Text = string.Format("{0:0.00}", Intent.GetDoubleExtra("TotalBolo", defaultValue));
                    txtTotalPagarBurger.Text = string.Format("{0:0.00}", Intent.GetDoubleExtra("TotalBurger", defaultValue));
                    
                    txtTotalCompra.Text = string.Format("{0:0.00}", Intent.GetDoubleExtra("TotalCompra", defaultValue));

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };
        }
    }
}

