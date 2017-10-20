using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloXamarinAndroid
{
    [Activity(Label = "Compras", MainLauncher = true, Icon = "@drawable/shoppingcart64")]
    public class MainActivity : Activity
    {
        int count = 1;
        double TotalAgua, TotalRefri, TotalBolo, TotalBurger, TotalCompra;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            int[] vlrspinner = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Button btnCalcular = FindViewById<Button>(Resource.Id.btncalcular);
            EditText txtagua = FindViewById<EditText>(Resource.Id.precoagua);
            EditText txtrefri = FindViewById<EditText>(Resource.Id.precorefri);
            EditText txtbolo = FindViewById<EditText>(Resource.Id.precobolo);
            EditText txtburger = FindViewById<EditText>(Resource.Id.precoburger);

            Spinner spnagua = FindViewById<Spinner>(Resource.Id.qtdagua);
            Spinner spnrefri = FindViewById<Spinner>(Resource.Id.qtdrefri);
            Spinner spnbolo = FindViewById<Spinner>(Resource.Id.qtdbolo);
            Spinner spnburger = FindViewById<Spinner>(Resource.Id.qtdburger);

            //int valor = Convert.ToInt32(spnagua.SelectedItem);

            ArrayAdapter _adaptervlrspinner = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, vlrspinner);
            _adaptervlrspinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnagua.Adapter = _adaptervlrspinner;
            spnrefri.Adapter = _adaptervlrspinner;
            spnbolo.Adapter = _adaptervlrspinner;
            spnburger.Adapter = _adaptervlrspinner;

            double PrecoAgua, PrecoRefri, PrecoBolo, PrecoBurger;
            
            int QtdAgua, QtdRefri, QtdBolo, QtdBurger;

            btnCalcular.Click += delegate
            {
                try
                {
                    PrecoAgua = double.Parse(txtagua.Text.Replace(".", ","));
                    PrecoRefri = double.Parse(txtrefri.Text.Replace(".", ","));
                    PrecoBolo = double.Parse(txtbolo.Text.Replace(".", ","));
                    PrecoBurger = double.Parse(txtburger.Text.Replace(".", ","));

                    // pegar valores spinners
                    QtdAgua = Convert.ToInt32(spnagua.SelectedItem);
                    QtdRefri = Convert.ToInt32(spnrefri.SelectedItem);
                    QtdBolo = Convert.ToInt32(spnbolo.SelectedItem);
                    QtdBurger = Convert.ToInt32(spnburger.SelectedItem);
                    //--------------------


                    TotalAgua = PrecoAgua * QtdAgua;
                    TotalRefri = PrecoRefri * QtdRefri;
                    TotalBolo = PrecoBolo * QtdBolo;
                    TotalBurger = PrecoBurger * QtdBurger;

                    TotalCompra = TotalAgua + TotalRefri + TotalBolo + TotalBurger;

                    Carregar();

                }
                catch (System.Exception ex)
                {
                    if(ex.Message == "Input string was not in a correct format.")
                    {
                        AlertDialog.Builder builder = new AlertDialog.Builder(this);
                        builder.SetTitle("Erro");
                        builder.SetMessage("Campos não preenchidos.");
                        builder.SetNeutralButton("ok", (s, e) => { builder.Dispose(); });
                        builder.SetCancelable(true);
                        
                        builder.Create();
                        builder.Show();
                        //Toast.MakeText(this, "Campos não preenchidos.", ToastLength.Long).Show();
                    }
                }
            };
        }
            public void Carregar()
            {
                Intent objIntent = new Intent(this, typeof(CompraActivity));
                objIntent.PutExtra("TotalAgua", TotalAgua);
                objIntent.PutExtra("TotalRefri", TotalRefri);
                objIntent.PutExtra("TotalBolo", TotalBolo);
                objIntent.PutExtra("TotalBurger", TotalBurger);
                objIntent.PutExtra("TotalCompra", TotalCompra);
                StartActivity(objIntent);
            }
            
        
    }
}

