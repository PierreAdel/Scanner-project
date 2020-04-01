package scanner;
public class Code_Scanner {
    char[] arr = new char[1000];
    public int indx =0;
    // GROUP 1 single character tokens
    Token SEMI = new Token("SEMI");
    Token COMMA = new Token("COMMA");
    Token LPAREN = new Token("LPAREN");
    Token RPAREN = new Token("RPAREN");
    Token PLUS = new Token("PLUS");
    Token MINUS = new Token("MINUS");
    Token MULT = new Token("MULT");
    Token DIV = new Token("DIV");
    // GROUP 2 double character tokens
    Token EQ = new Token("EQ");
    Token TESTEQ = new Token("TESTEQ");
    Token TESTNOTEQ = new Token("TESTNOTEQ");
    // GROUP 3 keywords
    Token WRITE = new Token("WRITE");
    Token READ = new Token("READ");
    Token IF = new Token("IF");
    Token ELSE = new Token("ELSE");
    Token RETURN = new Token("RETURN");
    Token BEGIN = new Token("BEGIN");
    Token END = new Token("END");
    Token MAIN = new Token("MAIN");
    Token STRING = new Token("STRING");
    Token INT = new Token("INT");
    Token REAL = new Token("REAL");
    // GROUP 4 other states
    Token QUOTEDSTRING = new Token("QUOTEDSTRING");
    Token NUMBER = new Token("NUMBER");
    Token COMMENT = new Token("COMMENT");
    Token IDENTIFIER = new Token("IDENTIFIER");   
    
    char[] MyCode= new char[10000];
    
    public  Code_Scanner(char[] charArray){
        this.MyCode=charArray;
        
    }
    
    public static int pointer = 0;
    
    public  Token tokenize(){
        
        //  check on single character tokens
        if(MyCode[pointer]== ';'){
            System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return SEMI;   
        }
        else if(MyCode[pointer]== ','){
             System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return COMMA;   
        }
         else if(MyCode[pointer]== '('){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return LPAREN;   
        }
         else if(MyCode[pointer]== ')'){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return RPAREN;   
        }
         else if(MyCode[pointer]== '+'){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return PLUS;   
        }
         else if(MyCode[pointer]== '-'){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return MINUS;   
        }
         else if(MyCode[pointer]== '*'){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return MULT;   
        }
         else if(MyCode[pointer]== '/'){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return DIV;   
        }
         // double character tokens
         else if(MyCode[pointer]== ':'&& MyCode[pointer+1]=='='){
              System.out.print("Token:   " + MyCode[pointer]+ MyCode[pointer+1] +"    Token Name:   ");
            pointer=pointer+2;
            return EQ;   
        }
        else if(MyCode[pointer]== '='&& MyCode[pointer+1]=='='){
            System.out.print("Token:   " + MyCode[pointer]+ MyCode[pointer+1] +"    Token Name:   ");
            pointer=pointer+2;
            return TESTEQ;   
        }
        else if(MyCode[pointer]== '!'&& MyCode[pointer+1]=='='){
            System.out.print("Token:   " + MyCode[pointer]+ MyCode[pointer+1] +"    Token Name:   ");
            pointer=pointer+2;
            return TESTNOTEQ;   
        }
        //quoted string
        else if(MyCode[pointer]== '"'){
            while(MyCode[pointer]!='"')
            {
                pointer++;
            }
            return QUOTEDSTRING;   
        }
        //COMMENT
        else if(MyCode[pointer]== '/'&& MyCode[pointer+1]=='*'&& MyCode[pointer+2]=='*'){
            pointer=pointer+3;
            while(MyCode[pointer]== '*'&& MyCode[pointer+1]=='*'&& MyCode[pointer+2]=='/')
            {
                pointer++;
            }
            return COMMENT;   
        }
        //NUMBER
        else if(Character.isDigit(MyCode[pointer]))
        {
            
        }
        // Keyword
        else if(Character.isAlphabetic(MyCode[pointer]))
        {
            while(Character.isAlphabetic(MyCode[pointer]) )
            {
                arr[indx] = MyCode[pointer];
                pointer++;
                indx++;
            }
            if(Character.isDigit(MyCode[pointer]))
            {
                return IDENTIFIER;
            }
          if(arr.equals("WRITE"))
                return WRITE;
          if(arr.equals("IF")) 
                return IF;
           if(arr.equals("READ"))
                return READ;
           if(arr.equals("ELSE"))
               return ELSE;
            if(arr.equals("END"))
                return END;
            if(arr.equals("MAIN"))
                 return MAIN;
             if(arr.equals("BEGIN"))
                     return BEGIN;
             if(arr.equals("STRING")) 
                   return STRING;
             if(arr.equals("INT"))
                   return INT;
             if(arr.equals("REAL"))
                   return REAL;
             if(arr.equals("RETURN"))
                     return RETURN;
    
          
        }
        
        
    //    else return BEGIN;
        return null;
      
        
         
    }
}
