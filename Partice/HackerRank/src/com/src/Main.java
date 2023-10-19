package com.src;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		String Input = "Hello";
		
		// and the output we want olleh
		
		reverseString(Input);

	 String input1 = "aAbBc" ;
	  // outputA: 1 B: 1 C: 1

	 Solve2(input1);
		
		String input2 = "A man a plan a canal Panama";
		checkpalindrome(input2);
		
		String input3 = "Hello   World!\n\t How are you?";

		solveQuestion4(input3);
		
		String sentence = "The quick brown fox jumped over the lazy dog";

		
		solveQuestion5(sentence);
		
		String sentence1 = "Hello world, how are you?";

		solveQuestion6(sentence1);
		
	}

	private static void solveQuestion6(String sentence1) {
		// TODO Auto-generated method stub
String[] array = sentence1.split(" ") ;
		
		StringBuilder ans = new StringBuilder();
		
		for(int i = array.length-1 ; i>=0 ; i--) {
			ans.append(array[i]);
			
		}
		
		System.out.println(ans.toString());
	}

	private static void solveQuestion5(String sentence) {
		// TODO Auto-generated method stub
		

		String[] characters = sentence.split(" ");
		
		int length=0 ;
		int index = 0 ;
		for(int i=0 ; i<characters.length ; i++) {
			
			if(length<characters[i].length()) {
				length = characters[i].length();
				index = i ;
			}
			
		}
		System.out.println(characters[index]);
	
		
	}

	private static void solveQuestion4(String input3) {
		// TODO Auto-generated method stub
		
		String[] characters = input3.split("");
	
		StringBuilder answer =  new StringBuilder();
		
		for(int i=0 ; i<characters.length ; i++) {
			if(characters[i].equals(" ") || characters[i].equals("\n") || characters[i].equals("\t")) {
				
				
			}else {
				answer.append(characters[i]);
			}
		}
		
		System.out.println(answer.toString());
		
		
	}

	private static void checkpalindrome(String s) {
		// TODO Auto-generated method stub
		  
		 // Check if the given string is a palindrome

	    // Remove non-alphanumeric characters and convert to lowercase
	    String cleanedString = s.replaceAll("[^a-zA-Z0-9]", "").toLowerCase();

	    int left = 0;
	    int right = cleanedString.length() - 1;

	    while (left < right) {
	        if (cleanedString.charAt(left) != cleanedString.charAt(right)) {
//	            return false;
	        }
	        left++;
	        right--;
	    }

//	    return true;
		
		
	}

	private static void Solve2(String input1) {
		// TODO Auto-generated method stub
		
		String[] array = input1.split("") ;
		
		HashMap<String, Integer> map = new HashMap<>();
		 
		for(int i =0 ; i<array.length ; i++) {
			
		
		
			map.put(array[i].toUpperCase(),map.getOrDefault(array[i],1));
		
		}
		
		for (Map.Entry<String, Integer> entry : map.entrySet()) {
            System.out.println("Element " + entry.getKey() + " occurs " + entry.getValue() + " times.");
        }
		
	}

	private static void reverseString(String input) {
		// TODO Auto-generated method stub
		
		String[] array = input.split("") ;
		
		StringBuilder ans = new StringBuilder();
		
		for(int i = array.length-1 ; i>=0 ; i--) {
			ans.append(array[i]);
			
		}
		
		System.out.println(ans.toString());
		
	}

}


