
package scanner;


public class Token {
    String tokenName;
    public Token (String name){
        this.tokenName=name;    
    }
    
    public void printTokenName(){
       System.out.println(tokenName);
    }   
    
}
