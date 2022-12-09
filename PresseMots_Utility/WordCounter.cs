using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PresseMots_Utility
{
    public  class WordCounter
    {
        public virtual  int Count(string input) {

            string pattern = "[^\\w]";
            var wordCount = Regex.Split(input ?? String.Empty, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline).Where(s => !string.IsNullOrWhiteSpace(s)).Count();
            return wordCount;

        }

        public  virtual int Count(IWordCountable wordCountable) {
            return Count(wordCountable.Content);
        }
            
            
            

    }
}
