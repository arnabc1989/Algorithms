import java.util.*;

public class Solution {
    public static boolean isValidParenthesis(String expression) {
        // Write your code here.
        Stack<Character> stack= new Stack<Character>();
        for(char c:expression.toCharArray()){
            if(c=='(' || c=='{' ||c=='[')
            {
                stack.push(c);
            }

            else if(c==')' && !stack.isEmpty() && stack.peek()=='(')
            {
                stack.pop();
            }
            else if(c=='}' && !stack.isEmpty() && stack.peek()=='{')
            {
                stack.pop();
            }
            else if(c==']' && !stack.isEmpty() && stack.peek()=='[')
            {
                stack.pop();
            }
            else
            {
                return false;
            }
        }
        return stack.isEmpty();
    }
}