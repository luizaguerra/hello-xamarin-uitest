using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace HelloXamarinAndroid.Test
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        //Instancia tudo que será executado antes de cada teste.
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

        }


        [Test]
        public void Repl()
        {
            app.Repl();
        }


        [Test]
        public void VerificarTotalProdutosTotalNaoFormatado()
        {
            int qtdAgua = 1, qtdRefri = 2, qtdBolo = 3, qtdBurger = 4;
            double precoAgua = 1.30, precoRefri = 6.90, precoBolo = 9.99, precoBurger = 8.60;
            double totalCompra = (qtdAgua * precoAgua) + (qtdRefri * precoRefri) + (qtdBolo * precoBolo) + (qtdBurger * precoBurger);


            app.WaitForElement("qtdagua");
            app.Tap("qtdagua");
            app.Tap("1");
            app.Tap("precoagua");
            app.EnterText("precoagua", "1.30");
            app.DismissKeyboard();

            app.Tap("qtdrefri");
            app.Tap("2");
            app.Tap("precorefri");
            app.EnterText("precorefri", "6.90");
            app.DismissKeyboard();

            app.Tap("qtdbolo");
            app.Tap("3");
            app.Tap("precobolo");
            app.EnterText("precobolo", "9.99");
            app.DismissKeyboard();

            app.Tap("qtdburger");
            app.Tap("4");
            app.Tap("precoburger");
            app.EnterText("precoburger", "8.60");
            app.DismissKeyboard();

            app.Screenshot("Tela Compras");

            app.Tap("btncalcular");

            app.WaitForElement("totalpagaragua");
            app.Screenshot("Tela Resultado");
            Assert.AreEqual((1 * 1.30).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagaragua")).First().Text.Replace(".", ","));
            Assert.AreEqual((2 * 6.90).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagarrefri")).First().Text.Replace(".", ","));
            Assert.AreEqual((3 * 9.99).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagarbolo")).First().Text.Replace(".", ","));
            Assert.AreEqual((4 * 8.60).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagarburger")).First().Text.Replace(".", ","));

            Assert.AreEqual(totalCompra, app.Query(x => x.Marked("totalcompra")).First().Text.Replace(".", ","));
        }


        [Test]
        public void VerificarTotalProdutos()
        {
            int qtdAgua = 1 , qtdRefri = 2, qtdBolo = 3, qtdBurger = 4;
            double precoAgua = 1.30, precoRefri = 6.90, precoBolo = 9.99, precoBurger = 8.60;
            double totalCompra = (qtdAgua * precoAgua) + (qtdRefri * precoRefri) + (qtdBolo * precoBolo) + (qtdBurger * precoBurger);

            
            app.WaitForElement("qtdagua");
            app.Tap("qtdagua");
            app.Tap("1");
            app.Tap("precoagua");
            app.EnterText("precoagua", "1.30");
            app.DismissKeyboard();

            app.Tap("qtdrefri");
            app.Tap("2");
            app.Tap("precorefri");
            app.EnterText("precorefri", "6.90");
            app.DismissKeyboard();

            app.Tap("qtdbolo");
            app.Tap("3");
            app.Tap("precobolo");
            app.EnterText("precobolo", "9.99");
            app.DismissKeyboard();

            app.Tap("qtdburger");
            app.Tap("4");
            app.Tap("precoburger");
            app.EnterText("precoburger", "8.60");
            app.DismissKeyboard();

            app.Screenshot("Tela Compras");

            app.Tap("btncalcular");

            app.WaitForElement("totalpagaragua");
            app.Screenshot("Tela Resultado");
            Assert.AreEqual((1 * 1.30).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagaragua")).First().Text.Replace(".", ","));
            Assert.AreEqual((2 * 6.90).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagarrefri")).First().Text.Replace(".", ","));
            Assert.AreEqual((3 * 9.99).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagarbolo")).First().Text.Replace(".", ","));
            Assert.AreEqual((4 * 8.60).ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalpagarburger")).First().Text.Replace(".", ","));

            Assert.AreEqual(totalCompra.ToString("N2").Replace(".", ","), app.Query(x => x.Marked("totalcompra")).First().Text.Replace(".", ","));
        }
    }
}

