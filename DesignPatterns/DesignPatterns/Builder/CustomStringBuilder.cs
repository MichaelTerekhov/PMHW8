using System;
using System.Linq;

namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private const int defaultBuffSize = 16;
        private const int defaultBuffIncrease = 2;

        private char[] str;
        private int size;
        private int charCount;

        private bool NeedToResize(string text) => charCount + text.Length > size;
        private void ConcatString(string text) => Array.Copy(text.ToCharArray(), 0, str, charCount, text.Length);
        private void UpdateCharNumber(int num) => charCount += num;
        private void Resize(string text)
        {
            int oldSize = size;
            size *= defaultBuffIncrease;
            var newStr = new char[size];
            Array.Copy(str, 0, newStr, 0, str.Length);
            str = newStr;
        }

        public CustomStringBuilder()
        {
            size = defaultBuffSize;
            str = new char[defaultBuffSize];
        }

        public CustomStringBuilder(string text) : this()
        {
            Append(text);
        }

        public ICustomStringBuilder Append(string text)
        {
            while (NeedToResize(text))
                Resize(text);
            ConcatString(text);
            UpdateCharNumber(text.Length);
            return this;
        }

        public ICustomStringBuilder Append(char ch)
        {
            while (NeedToResize(ch.ToString()))
                Resize(ch.ToString());
            ConcatString(ch.ToString());
            UpdateCharNumber(ch.ToString().Length);
            return this;
        }

        public ICustomStringBuilder AppendLine()
        {
            Append("\n");
            return this;
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            Append(str + "\n");
            return this;
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            Append(ch.ToString() + "\n");
            return this;
        }

        public string Build()
        {
            if (charCount == 0)
                return String.Empty;
            str = str.Where(x => x != 0).ToArray();
            return new string(str);
        }

    }
}