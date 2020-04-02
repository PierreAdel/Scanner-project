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
            word = My_Code[0].ToString();
        }


        public void Start_Scan() {
            while (pointer<My_Code.Length)
            {
                try
                {
                    
                   

                    if (Token.Is_Single_Char(word[0], ref token))
                    {
                        if (My_Code.Length-pointer < 2) goto skip_comment_check;
          if (Token.Is_Comment(word + My_Code[pointer+1].ToString() + My_Code[pointer + 1].ToString(), ref token))
                        {
                            goto skip_char;
                        }
                        skip_comment_check: Output[rows, 0] = My_Code[pointer].ToString();
                        Output[rows++, 1] = token.TokenName;
                        word = My_Code[++pointer].ToString();
                        continue;
                    }
 skip_char:                   if (!(pointer == My_Code.Length - 1))
                    {
                        word += My_Code[++pointer];
                    }  
                    if (Token.Is_Double_Char(word, ref token))
                    {
                        Output[rows, 0] = word;
                        Output[rows++, 1] = token.TokenName;
                        word = My_Code[++pointer].ToString();
                        continue;
                    }
                    
                    if (Token.Is_Comment(word, ref token))
                    {

                        Output[rows, 0] = "/**";
                        for (int i = pointer + 1; i < Token.Get_Comment_End(My_Code, pointer+1); i++)
                        {
                            Output[rows, 0] += My_Code[i ];

                        }
                        Output[rows++, 1] = token.TokenName;
                        pointer = Token.Get_Comment_End(My_Code, ++pointer);
                        word = My_Code[pointer].ToString();
                        continue;
                    }
                    
                    if (Token.Is_Keyword(word, ref token))
                    {
                        Output[rows, 0] = word;
                        Output[rows++, 1] = token.TokenName;
                        
                        word = My_Code[++pointer].ToString();
                        continue;
                    }
                   
                    if (Token.Is_String(word, ref token))
                    {
                        Output[rows, 0] = word;
                        Output[rows++, 1] = token.TokenName;
                        pointer += word.Length-1;
                        word = My_Code[pointer].ToString();
                        continue;
                    }
                    
                    if (Token.Is_Number(word, ref token))
                    {
                        Output[rows, 0] = word;
                        Output[rows++, 1] = token.TokenName;
                        if (pointer==My_Code.Length-1)
                        {
                            break;
                        }
                        
                        word = My_Code[++pointer].ToString();
                        continue;
                    }
                    //if (Token.Is_Identifier(word, ref token))
                    //{
                    //    Output[rows, 0] = word;
                    //    Output[rows++, 1] = token.TokenName;
                    //    if (pointer == My_Code.Length - 1)
                    //    {
                    //        break;
                    //    }

                    //    word = My_Code[++pointer].ToString();
                    //    continue;
                    //}
                }

                catch (Exception e)
                {
                    Console.WriteLine("no more code");
                }
                


            }
            for (int i = 0; i < My_Code.Length; i++)
            {
                Console.WriteLine(Output[i, 0] + "," + Output[i, 1]);

            }

        }




    }
}
