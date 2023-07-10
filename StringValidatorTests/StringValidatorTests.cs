using use_case_10;

namespace StringValidatorTests {
  public class StringValidatorTests {
    private StringValidator _validator;

    [SetUp]
    public void Setup() {
      _validator = new StringValidator(8, @"""!\""#$%&'()*+,-./:;<=>?@[\\]^_`{|}~""");
    }

    [Test]
    public void TestLength() {
      string tooShort = "Ab#1";
      string tooLong = "Aaaaaaaaabbbbbbbb#1";
      string justRight = "Abcdef#1";

      Assert.IsFalse(_validator.IsStringValid(tooShort));
      Assert.IsFalse(_validator.IsStringValid(tooLong));
      Assert.IsTrue(_validator.IsStringValid(justRight));
    }

    [Test]
    public void TestMissingElements() {
      string noUpper = "abcdefg#1";
      string noLower = "ABCDEFGH#1";
      string noSpecial = "Abcdefg1";
      string noDigit = "Abcdefg#";

      Assert.IsFalse(_validator.IsStringValid(noUpper));
      Assert.IsFalse(_validator.IsStringValid(noLower));
      Assert.IsFalse(_validator.IsStringValid(noSpecial));
      Assert.IsFalse(_validator.IsStringValid(noDigit));
    }

    [Test]
    public void TestWhitespace() {
      string leadingWhitespace = " Abcdef#1";
      string trailingWhitespace = "Abcdef#1 ";
      string innerWhitespace = "Abc de#1";

      Assert.IsFalse(_validator.IsStringValid(leadingWhitespace));
      Assert.IsFalse(_validator.IsStringValid(trailingWhitespace));
      Assert.IsFalse(_validator.IsStringValid(innerWhitespace));
    }

    [Test]
    public void TestComplexCases() {
      string mixedValidAndInvalid = "A1bc def#";
      string repeatedCharacters = "AAAbbb#1";
      string onlySpecialAndDigits = "#123456!";
      string specialAtBeginning = "#Ab1cdeF";
      string specialAtEnd = "AbcdEF1#";
      string orderDifferent = "1#AbcdEF";

      Assert.IsFalse(_validator.IsStringValid(mixedValidAndInvalid));
      Assert.IsTrue(_validator.IsStringValid(repeatedCharacters));
      Assert.IsFalse(_validator.IsStringValid(onlySpecialAndDigits));
      Assert.IsTrue(_validator.IsStringValid(specialAtBeginning));
      Assert.IsTrue(_validator.IsStringValid(specialAtEnd));
      Assert.IsTrue(_validator.IsStringValid(orderDifferent));
    }
  }
}