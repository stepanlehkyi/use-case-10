using use_case_10;

namespace StringValidatorTests {
  public class StringValidatorTests {
    private StringValidator _validator;

    [SetUp]
    public void SetUp() {
      _validator = new StringValidator(8);
    }

    [Test]
    public void TestLength() {
      string tooShort = "Ab#1";
      string tooLong = "Abcdefg#1H";
      string justRight = "AbcdE&12";

      Assert.IsFalse(_validator.IsStringValid(tooShort), "Expected validation to fail for string shorter than 8 characters");
      Assert.IsFalse(_validator.IsStringValid(tooLong), "Expected validation to fail for string longer than 8 characters");
      Assert.IsTrue(_validator.IsStringValid(justRight), "Expected validation to pass for string exactly 8 characters long");
    }

    [Test]
    public void TestMissingElements() {
      string noUpper = "abcdefg#1";
      string noLower = "ABCDEFGH#1";
      string noSpecial = "Abcdefg1";
      string noDigit = "Abcdefg#";

      Assert.IsFalse(_validator.IsStringValid(noUpper), "Expected validation to fail for string missing an uppercase letter");
      Assert.IsFalse(_validator.IsStringValid(noLower), "Expected validation to fail for string missing a lowercase letter");
      Assert.IsFalse(_validator.IsStringValid(noSpecial), "Expected validation to fail for string missing a special character");
      Assert.IsFalse(_validator.IsStringValid(noDigit), "Expected validation to fail for string missing a digit");
    }

    [Test]
    public void TestWhitespace() {
      string leadingWhitespace = " Abcdef#1";
      string trailingWhitespace = "Abcdef#1 ";
      string innerWhitespace = "Abc de#1";

      Assert.IsFalse(_validator.IsStringValid(leadingWhitespace), "Expected validation to fail for string with leading whitespace");
      Assert.IsFalse(_validator.IsStringValid(trailingWhitespace), "Expected validation to fail for string with trailing whitespace");
      Assert.IsFalse(_validator.IsStringValid(innerWhitespace), "Expected validation to fail for string with inner whitespace");
    }
    [Test]
    public void AdditionalTestCases() {
      // Inputs with various special characters
      Assert.IsTrue(_validator.IsStringValid("Aa1!@#$%"), "Expected validation to pass for string with various special characters");
      // Input with non-ASCII characters
      Assert.IsFalse(_validator.IsStringValid("≈Â1#2345"), "Expected validation to fail for string with non-ASCII characters");
      // Input with no lowercase character
      Assert.IsFalse(_validator.IsStringValid("A1!@#$%"), "Expected validation to fail for string with no lowercase character");
      // Input with no uppercase character
      Assert.IsFalse(_validator.IsStringValid("a1!@#$%"), "Expected validation to fail for string with no uppercase character");
      // Input with no digit
      Assert.IsFalse(_validator.IsStringValid("Aa!@#$%"), "Expected validation to fail for string with no digit");
      // Input with all lowercase characters
      Assert.IsFalse(_validator.IsStringValid("abcdefgh"), "Expected validation to fail for string with all lowercase characters");
      // Input with all uppercase characters
      Assert.IsFalse(_validator.IsStringValid("ABCDEFGH"), "Expected validation to fail for string with all uppercase characters");
    }
  }

}