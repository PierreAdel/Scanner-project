using System;
using System.Collections.Generic;
using System.Text;

namespace scanner
{
    class Scanner
    {
      private   String My_Code;
        private String word;//da string feeh l word l bndeha l ay function
        private int pointer;//pointer l a7na fen
        private String[,] Output;//2d array 2 columns we no. of row mo3tmd 3la l code ad eh l column l awlany l word wel tany l token we da l variable l anta hatsht8l beeh ya parpory
        private Token token;
        private int rows;//3shan afdl a incremento we a7ot fel 2d array k2no i fe for loop
        

        public Scanner(string My_Code)
        {
            this.My_Code = My_Code;
            this.pointer = 0;
            this.Output = new String[My_Code.Length, 2];
            this.token = new Token();
            this.rows = 0;
            word = null;
        }


        public void Start_Scan() {
            while (pointer<My_Code.Length)
            {
                if (My_Code[pointer].Equals(' '))
                {
                    if (word != null && word.Length > 0)
                    {
                        Get_Word_Token(word);
                    }
                    word = null ;
                    pointer++;
                    continue;
                }



                    if (My_Code[pointer]=='\"')
                    {
                       
                        if (word != null && word.Length > 0)
                        {
                            Get_Word_Token(word);
                        }
                        word = null;
                        Output[rows, 0] = "\"";
                        for (int i = pointer + 1; i < Token.Get_String_End(My_Code, pointer + 1); i++)
                        {
                            Output[rows, 0] += My_Code[i];

                        }
                        Output[rows++, 1] = "QUOTED STRING";

                        pointer = Token.Get_String_End(My_Code, ++pointer);

                        continue;
                    }
                


                if (My_Code.Length - pointer >2 )
                {
                    if (Token.Is_Comment(My_Code[pointer].ToString() + My_Code[pointer + 1].ToString() + My_Code[pointer + 2].ToString(), ref token))
                    { string token_name = token.TokenName;
                        if (word != null && word.Length > 0)
                        {
                            Get_Word_Token(word);
                        }
                        word = null;
                        Output[rows, 0] = "/";
                        for (int i = pointer +1; i < Token.Get_Comment_End(My_Code, pointer + 1); i++)
                        {
                            Output[rows, 0] += My_Code[i];

                        }
                        Output[rows++, 1] = token_name;
                        
                        pointer = Token.Get_Comment_End(My_Code, ++pointer);
                        
                        continue;
                    }
                }


                if (Token.Is_Single_Char(My_Code[pointer], ref token))
                    {
                    string token_name = token.TokenName;
                    if (word != null && word.Length > 0)
                    {
                        Get_Word_Token(word);
                    }
                    word = null;
                    Output[rows, 0] = My_Code[pointer].ToString();
                        Output[rows++, 1] = token_name;
                    pointer += 1;
                    
                    continue;
                    }
                
                if (My_Code.Length - pointer > 1)
                {
                    if (Token.Is_Double_Char(My_Code[pointer].ToString() + My_Code[pointer + 1].ToString(), ref token))
                    {
                        string token_name = token.TokenName;
                        if (word != null && word.Length > 0)
                        {
                            Get_Word_Token(word);
                        }
                        word = null;
                        Output[rows, 0] = My_Code[pointer].ToString() + My_Code[pointer + 1];
                        Output[rows++, 1] = token_name;
                        pointer += 2;
                       
                        continue;
                    }
                    if (!(Char.IsLetterOrDigit(My_Code[pointer])))
                    {
                        if (word != null && word.Length > 0)
                        {
                            Get_Word_Token(word);
                            word = null;
                            
                           
                        }

                    }
                }
                word += My_Code[pointer++];   

            }


              void Get_Word_Token(string word) {
                if (Token.Is_Keyword(word, ref token))
                {
                    Output[rows, 0] = token.TokenName;
                    Output[rows++, 1] = word ;



                }
                else if (Token.Is_Number(word, ref token))
                {
                    Output[rows, 0] = word;
                    Output[rows++, 1] = token.TokenName;
                }
                else if (Token.Is_Identifier(word, ref token))
                {
                    Output[rows, 0] = word;
                    Output[rows++, 1] = token.TokenName;
                   

                }
               
                else
                {
                    Output[rows, 0] = word;
                    Output[rows++, 1] = "NOT A TOKEN";
            
                }
            }


            //DA 3SHAN LAW L CODE 5LS WE KAN M3ANA WORD
            if (word!=null)
            {

                    Get_Word_Token(word);
                
                word = null;
            }


            for (int i = 0; i < My_Code.Length; i++)
            {
                Console.WriteLine(Output[i, 0] + "," + Output[i, 1]);

            }

        }




    }
}
