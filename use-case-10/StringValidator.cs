using System.Text.RegularExpressions;

namespace use_case_10 {
  public class StringValidator {
    private readonly Regex _validator;

    public StringValidator(uint length) {
      string specialChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~\\\\";
      string pattern = $"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[{specialChars}])[^\\s]{{{length},{length}}}$";
      _validator = new Regex(pattern);
    }

    public bool IsStringValid(string inputString) {
      return _validator.IsMatch(inputString);
    }
  }
}