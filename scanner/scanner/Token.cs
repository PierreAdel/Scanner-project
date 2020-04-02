using System;
using System.Collections.Generic;
using System;

namespace scanner
{
    class Token
    {
        String tokenName;

        public string TokenName { get => tokenName; set => tokenName = value; }

        public Token( )
        {
            this.TokenName = null ;
        }

        public void printTokenName()
        {
            Console.WriteLine(TokenName);
        }



        public static Boolean Is_Single_Char(char c, ref Token token) {

            switch (c) {
                case ';':
                    token.TokenName = "SEMI";


                    return true;
                case ',':

                    token.TokenName = "COMMA";


                    return true;
                case '(':
                    token.TokenName = "LPAREN";


                    return true;
                case ')':
                    token.TokenName = "RPAREN";


                    return true;
                case '+':
                    token.TokenName = "PLUS";


                    return true;
                case '-':
                    token.TokenName = "MINUS";


                    return true;
                case '*':
                    token.TokenName = "MULT";


                    return true;
                case '/':
                    token.TokenName = "DIV";


                    return true;

            }
            return false;
        }



        public static Boolean Is_Double_Char(String s,ref Token token)
        {

            switch (s)
            {
                case ":=":
                    token.TokenName = "EQ";


                    return true;
                case "==":
                    token.TokenName = "TESTEQ";


                    return true;
                case "!=":
                    token.TokenName = "TESTNOTEQ";


                    return true;

            }
            return false;
        }
        public static Boolean Is_Identifier(String s, ref Token token) {
            if (!(Char.IsLetter(s[0]))) {
                return false;


            }
            for (int i = 1; i < s.Length; i++)
            {
                if (!(Char.IsLetterOrDigit(s[i])))
                {
                    return false;
                }
            }
            token.TokenName = "IDENTIFIER";
            return true;
        }
        public static Boolean Is_Number(String s, ref Token token)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i])))
                {
                    return false;
                }
            }
            token.TokenName = "Number";
            return true;

        }
        public static Boolean Is_String(String s, ref Token token)
        {
            {

                if (s[0] == '\"' && s[s.Length-1] == '\"')
                {
                    token.TokenName = "String";
                    return true;
                }
                return false;
            }

        }

        public static Boolean Is_Comment(String s, ref Token token)
        {

            if (s.Length>2&&s[0].Equals('/') && s[1].Equals('*') && s[2].Equals('*'))
            {
                token.TokenName = "Comment";
                return true;
            }

            return false;

        }
        public static int Get_Comment_End(String s,int pointer)
        {
            for (; pointer < s.Length; pointer++)
            {

            
            if (s.Length-pointer>2&& s[pointer].Equals('*') && s[pointer+1].Equals('*') && s[pointer+2].Equals('/'))
            {
                    return pointer + 3;
            }
            }
            return s.Length;

        }
        public static int Get_String_End(String s, int pointer)
        {
            for (; pointer < s.Length; pointer++)
            {


                if ( s[pointer].Equals('\"'))
                {
                    return pointer + 1;
                }
            }
            return s.Length;

        }
        public static Boolean Is_Keyword(String s, ref Token token) {
            switch (s)
            {
                case "WRITE" : token.TokenName = "RESERVED";
                return true;

                case "IF":
                    token.TokenName = "RESERVED";
                    return true;
                case "READ":
                    token.TokenName = "RESERVED";
                    return true;
                case "ELSE":
                    token.TokenName = "RESERVED";
                    return true;
                case "END":
                    token.TokenName = "RESERVED";
                    return true;
                case "MAIN":
                    token.TokenName = "RESERVED";
                    return true;
                case "BEGIN":
                    token.TokenName = "RESERVED";
                    return true;
                case "STRING":
                    token.TokenName = "RESERVED";
                    return true;

                case "INT":
                    token.TokenName = "RESERVED";
                    return true;
                case "REAL":
                    token.TokenName = "RESERVED";
                    return true;
                case "RETURN":
                    token.TokenName = "RESERVED";
                    return true;


            }

            return false;
        
        }






        }
}
