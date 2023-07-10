using System.Text.RegularExpressions;

namespace use_case_10 {
  public class StringValidator {
    private readonly Regex _validator;

    public StringValidator(uint length, string specialChars) {
      string escapedSpecialChars = Regex.Escape(specialChars);
      string pattern = $"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[{escapedSpecialChars}])(?!.*\\s).{{1,{length}}}$";
      _validator = new Regex(pattern, RegexOptions.Compiled);
    }

    public bool IsStringValid(string inputString) {
      return _validator.IsMatch(inputString);
    }
  }
  }