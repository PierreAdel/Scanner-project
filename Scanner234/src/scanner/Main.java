
package scanner;
import java.util.Scanner;
import java.util.*; 

public class Main {
    /*private boolean eq(String)
    {
    
    
    }*/
    public static void main(String[] args) {
        
           
        
        
        
        
        Scanner obj = new Scanner(System.in);
        String string= "null";
        System.out.println("Enter your code in TINY language to be scanned");
        // string ba7ot fih elli el user beyda5alo
        string=obj.nextLine();
       // 3amlt character array 7ateet fiha el string 
       char[] charArray = new char[string.length()];
        for (int i = 0; i < string.length(); i++) { 
            charArray[i] = string.charAt(i); 
        } 
        // m3aya character array el user mda5alha esmaha charArray
        Token token;
        Code_Scanner scanner = new Code_Scanner(charArray);
        while(scanner.pointer<string.length()){ // removed <= and solved index out of bound  
             
            token = scanner.tokenize();
           
         //   System.out.print(scanner.pointer);
            token.printTokenName();
            
        }
        
        
        
    }
    
}



