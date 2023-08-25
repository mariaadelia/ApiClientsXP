using System.Text.RegularExpressions;

namespace Tests.XPTesteTecnico
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("teste@gmail.com")]
        [DataRow("testegmail.com")]
        [DataRow("teste@gmailcom")]
        [DataRow("teste@gmail..com")]
        [DataRow("teste@@gmail.com")]
        [DataRow("teste")]
        public void ChecarEmail(string email)
        {
            bool emailCorreto = Regex.IsMatch(email, @"^([\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z)");

            Assert.IsTrue(emailCorreto);
    }

        [DataTestMethod]
        [DataRow("11971111111")]
        [DataRow("t555")]
        [DataRow("teste")]
        [DataRow("1133339999")]
        public void ChecarTelefone(string fone)
        {
            bool foneValido = Regex.IsMatch(fone, @"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$");

            Assert.IsTrue(foneValido);
        }
    }
}