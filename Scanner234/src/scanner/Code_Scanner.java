
package scanner;


public class Code_Scanner {
    
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
         else if(MyCode[pointer]== '*' && (MyCode[pointer-1] != '/' || MyCode[pointer-1] != '*')){
              System.out.print("Token:   " + MyCode[pointer] +"    Token Name:   ");
            pointer++;
            return MULT;   
        }
         else if(MyCode[pointer]== '/' && MyCode[pointer+1] != '*'){
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
           pointer++;
            System.out.print("Token: ");
            while(MyCode[pointer]!='"')
            {
                System.out.print(MyCode[pointer]);
                pointer++;
                
            }
            System.out.print("  Token Name: ");
            return QUOTEDSTRING;    
        }
        //COMMENT
        else if(MyCode[pointer]== '/'&& MyCode[pointer+1]=='*'&& MyCode[pointer+2]=='*'){
            pointer=pointer+3;
            if(MyCode[pointer] != '*'&& MyCode[pointer+1] !='*'&& MyCode[pointer+2] !='/')
                System.out.print("Token: " + "/**" );
            while(MyCode[pointer] != '*'&& MyCode[pointer+1] !='*'&& MyCode[pointer+2] !='/')
            {
                System.out.print(MyCode[pointer]);
                pointer++;
            } 
            System.out.print(MyCode[pointer] );
            System.out.print( "**/" + "  Token Name: ");
            return COMMENT;   
           }
        //NUMBER - me7tag yetgarab 3shan nezbot el if aw while loop bs elexception mbwz eldonia
        else if(Character.isDigit(MyCode[pointer]))
        {   
            System.out.print(MyCode[pointer]);
            pointer++;
            System.out.print("Token: ");
//            while(Character.isDigit(MyCode[pointer]) || ((MyCode[pointer]== '.') && Character.isDigit(MyCode[pointer+1])))
            if(Character.isDigit(MyCode[pointer]) || ((MyCode[pointer]== '.') && Character.isDigit(MyCode[pointer+1])))
            {
                System.out.print(MyCode[pointer]);
                if((MyCode[pointer]== '.') )
                    
                        { System.out.print(pointer+1);
                            for (int i = pointer+2; i < pointer+7; i++) {        
                            if(Character.isDigit(MyCode[i]))
                                        System.out.print(MyCode[i]);}
                            
                   }}
            System.out.print("  Token Name: ");
            return NUMBER;
        }     
       return null;
    }
   
}