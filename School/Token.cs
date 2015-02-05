using System;

namespace School
{
    public class Token
    {
        private readonly int type;
        private readonly string text;

        public int Type 
        { 
            get { return type; }
        }

        public string Text
        {
            get { return text; }
        }

        public Token(int type, string text)
        {
            this.type = type;
            this.text = text;
        }

        public override string ToString()
        {
            String tname = SchoolLexer.tokenNames[type];
            return "<'" + text + "'," + tname + ">";
        }
    }
}
